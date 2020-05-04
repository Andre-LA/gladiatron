using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shooter : MonoBehaviour
{
    public Rigidbody shooter;
    public Transform pos_tiro;
    public float forca_tiro;
    void Start()
    {
        
    }

    
    void Update()
    {

        if (Input.GetButtonDown("Fire3"))
        {
            Rigidbody Player_shooter_instance;
            Player_shooter_instance = Instantiate(shooter, pos_tiro.position, pos_tiro.rotation) as Rigidbody;
            Player_shooter_instance.AddForce(pos_tiro.forward * forca_tiro);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
