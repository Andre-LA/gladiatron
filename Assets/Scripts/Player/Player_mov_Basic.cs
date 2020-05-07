using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov_Basic : MonoBehaviour
{
    public float speed = 5;
    public float turnSpeed = 200;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //movimento do player
        //debug.logo(input.getaxis("Vertical"));
        transform.Translate(0 , 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //rotação do player
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        //verificando se determinadas teclas estão pressionadas ou não
        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }
}
