using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterItem : MonoBehaviour
{
    [SerializeField] float augmentValueWater = 5;
    [SerializeField] float augmentValueWaterRiver = 0.3f;
    [SerializeField] float maxTimeRiver = 0.15f;
    [SerializeField] bool isZoneWater = false;
    [SerializeField] AudioSource audioSource;

    private bool isStayInThisWater = false;
    PlayerEnergy playerEnergy;



    private float lastTimeIncrementWater;

    void Update()
    {
        if (isStayInThisWater)
        {
            lastTimeIncrementWater += Time.deltaTime;
            if (lastTimeIncrementWater > maxTimeRiver && playerEnergy != null)
            {
                playerEnergy.AugmentWaterValue(augmentValueWaterRiver);
                lastTimeIncrementWater = 0;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (isZoneWater) {
            playerEnergy = collider.GetComponent<PlayerEnergy>();
            isStayInThisWater = true;
        }
        else
        {
            if (collider.tag == "Player")
            {
                collider.GetComponent<PlayerEnergy>().AugmentWaterValue(augmentValueWater);
            }
            gameObject.SetActive(false);
        }

        audioSource.Play();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isStayInThisWater = false;
        audioSource.Stop();
    }
}
