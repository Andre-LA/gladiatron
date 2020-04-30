using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //utilizado para ativar inteligencia artificial do programa


public class EnemyController : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask playerLayers;

    public float lookRadius = 10f; 
    Transform target;
    NavMeshAgent agent;

    public float attackRange = 0.5f; //distancia do ataque
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0;



    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius) //aqui é usado para dizer a distancia do inimigo que correrá atras do jogador
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
                Attack();
            }
        }

        if (Time.time >= nextAttackTime)
        {
           
           nextAttackTime = Time.time + 1f / attackRate;
           
        }

    }

    void FaceTarget() //função utilizada para objeto virar a face para o jogador
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizsmosSelected() //serve para desenhar uma esfera para indicar algo na tela
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Attack() //função criada para atacar
    {
        //Play animação de ataque
        animator.SetTrigger("Attack");
        //Detectar os inimigos no alcance
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);
        //Ataca-los
        foreach (Collider player in hitPlayer)
        {

            player.GetComponent<Health>().TakeDamage(attackDamage);

        }
    }

    void OnDrawGizmosSelected() //utilizado para criar uma esfera de onde o ataque ira partir, para determinar a distancia do ataque
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }


}
