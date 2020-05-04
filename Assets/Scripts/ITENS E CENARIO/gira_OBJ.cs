using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gira_OBJ : MonoBehaviour
{
    public float OBJspeed;
    public float OBJspeedRot;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.left * OBJspeed * Time.deltaTime);

        transform.Rotate( 0,10 * Time.deltaTime * OBJspeedRot, 0);
    }
}
