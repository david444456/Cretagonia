using RPGM.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDig : MonoBehaviour
{
    
    public float radiusSphere = 1;
    [SerializeField] AudioSource audioSource;
    CharacterController2D characterController;
    Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //start animation
            animator.SetTrigger("Dig");
            audioSource.Play();
            ChangeMoveCharacter(true);
        }
    }

    public void FinishAnimationDigZone() {
        //detect dig zone
        RaycastHit[] hitSphere;
        hitSphere = Physics.SphereCastAll(transform.position, radiusSphere, -new Vector3(0,0,1), 100.0f);

        foreach (RaycastHit rc in hitSphere)
        {
            DigZone paint = rc.collider.GetComponent<DigZone>();
            if (paint != null)
            {
                paint.NewRewardDigZone();
                print("Hola!");
            }
        }

        ChangeMoveCharacter(false);
    }

    private void ChangeMoveCharacter(bool newValue) {
        characterController.CantMove = newValue;
    }
}
