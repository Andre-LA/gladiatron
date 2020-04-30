using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class NPC : MonoBehaviour
{
   
   public Transform Player; //pega a posição do player
    public bool PlayerInRange; //if true npc can hear or see Player
    public bool PlayerInsight; //if true npc and see Player (determined with RAY)
    public bool crimeCommited; //if true npc reports crime if PlayerInSight true

    void Update()
    {
        Player = GameObject.FindWithTag("Player").transform;
        //using FindWithTag as Player tag is changed depending on vehicle or not 
        if (PlayerInRange == true) //check if Player is in range
        {
            checkSight(); //check if npc can see Player
        }

        if (PlayerInsight == true && crimeCommited == true)
        {
         
        }
    }

    void checkSight()
    {
        Vector3 pos = transform.position; //determine npc position
        Vector3 target = Player.position; // determine Player position

        RaycastHit hitInfo;
        if (Physics.Raycast(pos, target, out hitInfo, 20f))
        {
            if (hitInfo.transform.tag == "Player")
            {
                PlayerInsight = true;
            }
            else
            {
                PlayerInsight = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerInRange = false;
        }
    }
}