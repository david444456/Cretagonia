using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotebook : MonoBehaviour
{
    [SerializeField] GameObject _UIGameObjectActiveNoteBook;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeActiveObjectNotebookGO(true);

        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            ChangeActiveObjectNotebookGO(false);
        }
    }

    public void ChangeActiveObjectNotebookGO(bool newValue) {
        _UIGameObjectActiveNoteBook.SetActive(newValue);
    }
}
