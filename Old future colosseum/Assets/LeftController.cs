using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftController : MonoBehaviour
{

    private Quaternion targetRotation;
    public GameObject EspadaFlamejante;
    // Use this for initialization
    //public string nameit;
    public Animator animator;
    private CharacterController controller;
    Vector3 MoveVector;
    public int speed;
    public float VerticalVelocity;

   public Camera leoCam;
    public GameObject MyHealthBar;
    public GameObject EnemyHealthBar;

    public Collider[] AttackBoxes;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        targetRotation = transform.rotation;


        leoCam.enabled = false;
        //nameit = this.name;
    }


    // Update is called once per frame
    void Update()
    {


        MoveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            //JUMPING
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            {
                if (Input.GetButtonDown("saltop1"))
                {
                    VerticalVelocity = 0;
                    VerticalVelocity = 350 * Time.deltaTime;
                }
            }
        }
        else
        {
            VerticalVelocity -= 5 * Time.deltaTime;


        }

        if (this.transform.rotation.y > 95 && this.transform.rotation.y < 97)
        {
            MoveVector.x = -Input.GetAxis("HorizontalEsq") * speed;

        }
        else {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Walking") || animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingReverse"))
            {
                MoveVector.x = Input.GetAxis("HorizontalEsq") * speed;
            }
        }

        MoveVector.y = VerticalVelocity;
        controller.Move(MoveVector * Time.deltaTime);

        if (Input.GetAxis("HorizontalEsq") < 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else { animator.SetBool("IsWalking", false); }


        if (Input.GetAxis("HorizontalEsq") > 0)
        {
            animator.SetBool("IsWalkingReverse", true);
        }
        else { animator.SetBool("IsWalkingReverse", false); }





        if (Input.GetButtonDown("LightESQ") /*|| Input.GetKeyDown(KeyCode.I)*/)
        {

            animator.SetBool("LowPunch", true);
            //Attack(AttackBoxes[0]);



        }
        else { animator.SetBool("LowPunch", false); }


        if (Input.GetButtonDown("HeavyESQ") /*|| Input.GetKeyDown(KeyCode.O)*/)
        {


            animator.SetBool("HighKick", true);
      

        }
        else { animator.SetBool("HighKick", false); }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("High Kick"))
        {
            EspadaFlamejante.SetActive(true);
        }
        else { EspadaFlamejante.SetActive(false); }

        if (Input.GetButtonDown("turn1"))
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
            leoCam.enabled = true;
            animator.SetBool("ILose", true);
        }

        if (Input.GetButtonDown("block1"))
        {

            animator.SetTrigger("IsParry");

        }
    }





}
