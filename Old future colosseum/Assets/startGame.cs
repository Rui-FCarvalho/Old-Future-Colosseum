using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public Button btnLiam;
    public Button btnLionidas;
    public Button btnAshiri;
    public Button btnLuna;

    private bool start;
    private bool choose;
    private Text texto;



    // Use this for initialization
    void Start()
    {
    
        start = false;
        choose = false;

        texto = GetComponentInChildren<Text>();
        btnLiam.onClick.AddListener(() => TaskOnClick("Liam"));

        btnLionidas.onClick.AddListener(() => TaskOnClick("Lionidas"));
        btnAshiri.onClick.AddListener(() => TaskOnClick("Ashiri"));
        btnLuna.onClick.AddListener(() => TaskOnClick("Luna"));
        texto.text = "Escolhe player1";
    }

    void TaskOnClick(string Charter)
    {
        if (start != true)
        {
          
            if (choose == false) //Player ONE
            {
             
                switch (Charter)
                {
                    case "Liam": // if a is an integer
                        Debug.Log(" iNICIO LIAM");
                        Instantiate(Resources.Load<GameObject>("Prefabs/Liam"));
                        
                        break;
                    case "Lionidas": // if a is a string
                        Debug.Log("INICIO lIONIDAS");
                        break;

                    case "Ashiri": // if a is an integer
                        Debug.Log(" iNICIO LIAM");
                        break;
                    case "Luna": // if a is a string
                        Debug.Log("INICIO lIONIDAS");
                        break;

                    default:
                        Debug.Log("none of the above");
                        break;

                }
                choose = true;
                texto.text = "Escolhe player2";
            }
           
            else if (choose == true) //Player ONE
            {
           
                switch (Charter)
                {
                    case "Liam": // if a is an integer
                        Debug.Log(" iNICIO LIAM");
                        Instantiate(Resources.Load<GameObject>("Prefabs/Leonidas"), new Vector3(-1, 0, 0),  new Quaternion(0, 125, 0,0));
                        break;
                    case "Lionidas": // if a is a string
                        Debug.Log("INICIO lIONIDAS");
                        Instantiate(Resources.Load<GameObject>("Prefabs/Leonidas"), new Vector3(-1, 0, 0), new Quaternion(0, 125, 0, 0));
                        break;

                    case "Ashiri": // if a is an integer
                        Debug.Log(" iNICIO LIAM");
                        break;
                    case "Luna": // if a is a string
                        Debug.Log("INICIO lIONIDAS");
                        break;

                    default:
                        Debug.Log("none of the above");
                        break;

                }
              

            }
    

        }
    }
}
