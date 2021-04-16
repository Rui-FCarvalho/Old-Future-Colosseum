using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMaster : MonoBehaviour
{

    // Use this for initialization
    public string nameit;
    public Animator animator;
    private CharacterController controller;
    Vector3 MoveVector;
    public int speed;
    public float VerticalVelocity;

    public Collider[] AttackBoxes;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        nameit = this.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            VerticalVelocity = -1;
        }
        else { VerticalVelocity -= 14 * Time.deltaTime; }

        MoveVector = Vector3.zero;
        MoveVector.x = Input.GetAxis("Horizontal") * speed;
        MoveVector.y = VerticalVelocity;
        controller.Move(MoveVector * Time.deltaTime);

        if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else { animator.SetBool("IsWalking", false); }


        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("IsWalkingReverse", true);
        }
        else { animator.SetBool("IsWalkingReverse", false); }





        if (Input.GetButtonDown("socoL") || Input.GetKeyDown(KeyCode.I))
        {

            animator.SetBool("LowPunch", true);
            //Attack(AttackBoxes[0]);



        }
        else { animator.SetBool("LowPunch", false); }


        if (Input.GetButtonDown("HightKick") || Input.GetKeyDown(KeyCode.O))
        {


            animator.SetBool("HighKick", true);
            
        }
        else { animator.SetBool("HighKick", false); }
    }


}
