using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeViewControl : MonoBehaviour {
    Transform cube;
    public Vector3 offset;

    private Vector3 posicaoini = new Vector3(-0.04f, 7.21f, -2.49f);
    private Quaternion rotaini= Quaternion.Euler(new Vector3(77.42f, 0, 0));

    private Vector3 duelCam = new Vector3(0.08f, 2.6f, -3.05f);
    private Quaternion duelrota = Quaternion.Euler(new Vector3(0, 0, 0));
    //player
    // Use this for initialization
    void Start () {
        cube = GameObject.FindGameObjectWithTag("Center").transform;
        transform.position = posicaoini;
        transform.rotation = rotaini;
        this.transform.position = ComputeCameraPosition(offset);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = duelCam;
            transform.rotation= duelrota;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.position = posicaoini;
            transform.rotation = rotaini;
        }
    }

    private Vector3 ComputeCameraPosition(Vector3 offset)
    {
        return cube.position - cube.forward * offset.z + cube.up * offset.y;
    }
}
