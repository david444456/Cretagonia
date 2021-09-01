using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigZone : MonoBehaviour
{
    [SerializeField] Fossil fossilReward;


    private bool notFoundYet = false;
    void Start()
    {

    }

    public void NewRewardDigZone() {
        // if (notFoundYet) return;
        FindObjectOfType<NotebookController>().NewFossilFound(fossilReward);
        gameObject.SetActive(false);
        print(name);
        notFoundYet = true;
    }

}
