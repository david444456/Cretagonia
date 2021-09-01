using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NotebookController : MonoBehaviour
{
    public UnityEvent eventWin = new UnityEvent();
    [SerializeField] int maxCountFossils;
    [SerializeField] Fossil[] allFossil;

    [Header("UI")]
    [SerializeField] Image[] imagesInfoAboutFossils;
    [SerializeField] ParticleSystem particleSystemSmoke;

    [Header("InfoNewFossil")]
    [SerializeField] GameObject GOInfoNewFossil;
    [SerializeField] Text textNameInfo;
    [SerializeField] Text textDescriptionInfo;
    [SerializeField] Image imageFossilInfo;

    List<bool> saveInfoFossilsFound = new List<bool>();

    [SerializeField] AudioSource audioSourceAlert;
    [SerializeField] AudioSource audioSourceFossil;

    PlayerNotebook playerNotebook;
    int countWin = 0;
    void Start()
    {
        playerNotebook = FindObjectOfType<PlayerNotebook>();
        audioSourceAlert = GetComponent<AudioSource>();

        for (int i = 0; i < maxCountFossils; i++) {
            saveInfoFossilsFound.Add(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GOInfoNewFossil.activeInHierarchy) {
            DesactiveFoundOtherFossilGO();
        }
    }

    public void NewFossilFound(Fossil newFossil) {
        particleSystemSmoke.transform.position = playerNotebook.transform.position;
        particleSystemSmoke.Play();

        for (int i = 0; i < maxCountFossils; i++)
        {
            if (allFossil[i].GetUniqueIndex() == newFossil.GetUniqueIndex() 
                && !saveInfoFossilsFound[i]) {
                FoundOtherFossil(i, newFossil);
                countWin++;
            }
        }
    }

    public void DesactiveFoundOtherFossilGO() {
        GOInfoNewFossil.SetActive(false);
        StartCoroutine(WaitForActiveNoteBook());
    }

    [SerializeField] int maxCountToWin = 5;

    IEnumerator WaitForActiveNoteBook() {
        yield return new WaitForSeconds(0.1f);
        playerNotebook.ChangeActiveObjectNotebookGO(true);
        audioSourceAlert.Play();

        if (countWin >= maxCountToWin) {
            eventWin.Invoke();
        }
    }

    private void FoundOtherFossil(int i, Fossil newFossil) {
        saveInfoFossilsFound[i] = true;
        imagesInfoAboutFossils[i].sprite = newFossil.GetSpriteByNotebook();

        //info
        GOInfoNewFossil.SetActive(true);
        textNameInfo.text = newFossil.GetNameFossil();
        textDescriptionInfo.text = newFossil.GetDescFossil();
        imageFossilInfo.sprite = newFossil.GetSpriteInfoNotebook();
        audioSourceFossil.clip = newFossil.GetClipFossil();
        audioSourceFossil.Play();
    }
}
