using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevarDano : MonoBehaviour
{
    private string namedequem;
    public Color newColor;
    public GameObject slid;
    private Color meuverde = new Color(144f / 255f, 238f / 255f, 144f / 255f);
    public Animator animator;

    private void Start()
    {

        newColor = new Color();
        namedequem = "base";
        newColor = Color.Lerp(Color.red, meuverde,  slid.GetComponent<Scrollbar>().size);

        ColorBlock cb = slid.GetComponent<Scrollbar>().colors;
        cb.normalColor = newColor;
        slid.GetComponent<Scrollbar>().colors = cb;
    }
    public void OnTriggerEnter(Collider other)
    {
        // namedequem = other.GetComponent<PlayerControllerMaster>().nameit;
        newColor = Color.Lerp(Color.red, meuverde, slid.GetComponent<Scrollbar>().size);

        ColorBlock cb = slid.GetComponent<Scrollbar>().colors;
        cb.normalColor = newColor;
        slid.GetComponent<Scrollbar>().colors = cb;


        if (other.transform.root == this.transform.root)
        {
            namedequem = "sou eu";
        }
        else
            namedequem = other.name;

        /* if (namedequem == "Kick" && !(other.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))&&!(other.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walking")))
        {
            Debug.Log("levei um pontPE");
        }*/
        if ((namedequem == "Light" && (other.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Low Punch")) && !(animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))))
        {
            Debug.Log("levei um murro"+ namedequem);
            slid.GetComponent<Scrollbar>().size -= 0.2f;
            animator.SetTrigger("IsHit");
        }
        

        else if ((namedequem == "Heavy" && (other.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("High Kick"))) && !(animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") && !(animator.GetCurrentAnimatorStateInfo(0).IsName("Parry"))))
        {
            Debug.Log("levei um pontapé"+ namedequem);
            slid.GetComponent<Scrollbar>().size -= 0.3f;
            animator.SetTrigger("IsHit");
        }


        else if (namedequem == "DED")
        {
            slid.GetComponent<Scrollbar>().size -= 1f;
            animator.SetTrigger("IsHit");
        }

        else if((other.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("High Kick") && animator.GetCurrentAnimatorStateInfo(0).IsName("Parry"))){
            other.GetComponentInParent<Animator>().SetTrigger("IsHit");
 
        }

        //Debug.Log(namedequem);


    }
}
