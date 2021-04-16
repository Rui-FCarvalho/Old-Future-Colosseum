using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightController : MonoBehaviour
{

    public Camera willCam;
    private Quaternion targetRotation;
    public GameObject PeArdente;

    // Use this for initialization
    public string nameit;
    public Animator animator;
    private CharacterController controller;
    Vector3 MoveVector;
    public int speed;
    public float VerticalVelocity;


    public GameObject MyHealthBar;
    public GameObject EnemyHealthBar;

    public Collider[] AttackBoxes;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //MyHealthBar.GetComponent<Scrollbar>();
        nameit = this.name;
        willCam.enabled = false;
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        MoveVector = Vector3.zero;

     
        if (controller.isGrounded)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            {
                if (Input.GetButtonDown("saltop2"))
                {
                    VerticalVelocity = 0;
                    VerticalVelocity = 350 * Time.deltaTime;
                }
            }
            //JUMPING

         
        }
        else
        {
            VerticalVelocity -= 5 * Time.deltaTime;


        }





        if (this.transform.rotation.y > 95 && this.transform.rotation.y < 97)
        {
            MoveVector.x = -Input.GetAxis("HorizontalDir") * speed;
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Walking") || animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingReverse"))
            {
                MoveVector.x = Input.GetAxis("HorizontalDir") * speed;
            }
        }
        MoveVector.y = VerticalVelocity;
        controller.Move(MoveVector * Time.deltaTime);

        if (Input.GetAxis("HorizontalDir") < 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else { animator.SetBool("IsWalking", false); }


        if (Input.GetAxis("HorizontalDir") > 0)
        {
            animator.SetBool("IsWalkingReverse", true);
        }
        else { animator.SetBool("IsWalkingReverse", false); }





        if (Input.GetButtonDown("LightDir") || Input.GetKeyDown(KeyCode.N))
        {

            animator.SetBool("LowPunch", true);





            //Attack(AttackBoxes[0]);



        }
        else { animator.SetBool("LowPunch", false); }




        if (Input.GetButtonDown("HeavyDir") || Input.GetKeyDown(KeyCode.M))
        {


            animator.SetBool("HighKick", true);

        }
        else { animator.SetBool("HighKick", false); }

        if (Input.GetButtonDown("turn2"))
        {
            targetRotation *= Quaternion.AngleAxis(180, Vector3.up);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5 * Time.deltaTime);


        if (EnemyHealthBar.GetComponent<Scrollbar>().size == 0)
        {
            animator.SetBool("IWin", true);
        }

        if (MyHealthBar.GetComponent<Scrollbar>().size == 0)
        {
            MyHealthBar.SetActive(false);
            EnemyHealthBar.SetActive(false);
            willCam.enabled = true;
            animator.SetBool("ILose", true);
         
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("High Kick"))
        {
            PeArdente.SetActive(true);
        }
        else { PeArdente.SetActive(false); }

        if (Input.GetButtonDown("block2"))
            {

            animator.SetTrigger("IsParry");

            }
    }
}


  
        



