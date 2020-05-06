using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class tiro : MonoBehaviour
{
    public Rigidbody obj_tiro;
    public Transform pos_origem;
    void Start()
    {
        
    }

    //tiro vai sair depois do player
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody tiro_instance;
            tiro_instance = Instantiate(obj_tiro, pos_origem.position, pos_origem.rotation) as Rigidbody;
            tiro_instance.AddForce(pos_origem.forward * 300);
        }
    }
}
