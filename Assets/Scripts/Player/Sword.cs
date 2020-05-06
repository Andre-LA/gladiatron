using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
   
    public int damage = 0;
    // Start is called before the first frame update
    Collider s_ObjectCollider;
    public Animator animator;
    public float attackRate = 1f;
    float nextAttackTime = 0;
    


    void Start()
    {
        s_ObjectCollider = GetComponent<Collider>();
        s_ObjectCollider.isTrigger = false;
        Debug.Log("Trigger on: " + s_ObjectCollider.isTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                OnSpaceDown();

            }else
            {
                s_ObjectCollider.isTrigger = false;
            }
        }

    }

    public void OnSpaceDown()
    {
        s_ObjectCollider.isTrigger = true;
        Debug.Log("Trigger on: " + s_ObjectCollider.isTrigger);
        
    }

   

    void OnTriggerEnter(Collider other)// função para dar dano
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void Attack() //função criada para atacar
    {
        //Play animação de ataque
        animator.SetTrigger("attack");
    }


}
