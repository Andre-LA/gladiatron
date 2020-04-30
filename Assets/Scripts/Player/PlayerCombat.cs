using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator; //criado para opção de animação

    public Transform attackPoint; //ponto do ataque apartir da arma do personagem
    public LayerMask enemyLayers; 

    public float attackRange = 0.5f; //distancia do ataque
    public int attackDamage = 40; //dano do ataque

    public float attackRate = 2f;
    float nextAttackTime = 0;
    

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack(); //função que foi criada para codigo de ataque
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack() //função criada para atacar
    {
        //Play animação de ataque
        animator.SetTrigger("Attack");
        //Detectar os inimigos no alcance
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        //Ataca-los
        foreach(Collider enemy in hitEnemies)
        {

            enemy.GetComponent<Health>().TakeDamage(attackDamage);
            
        }
    }
    
    void OnDrawGizmosSelected() //utilizado para criar uma esfera de onde o ataque ira partir, para determinar a distancia do ataque
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }

  

}

