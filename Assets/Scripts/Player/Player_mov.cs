using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player_mov : MonoBehaviour
{
    protected Joystick joystick;
    protected JoystickPointer joystickPtr;
    protected Attack attack;
    protected Joybutton joybutton;
    public float velocidade = 10; //velocidade de movimento
    public float VelMax = 200;
    Animator anim;//chama as animações
    Rigidbody rigidbody;
    protected bool Jump;
    private float JumpTime;//limitando o pulo do Tigas
    public Transform chaoVerificador;
    public Transform attackPoint; //ponto do ataque apartir da arma do personagem
    public LayerMask enemyLayers;

    public float attackRange = 0.5f; //distancia do ataque
    public int attackDamage = 40; //dano do ataque

    public float attackRate = 2f;
    float nextAttackTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joystickPtr = FindObjectOfType<JoystickPointer>();
        attack = FindObjectOfType<Attack>();
        joybutton = FindObjectOfType<Joybutton>();
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f))
        {
            if (hit.transform.CompareTag("Chao"))
            {
                Jump = false;
            }
        }

        /*if (Input.anyKey == false)
        {
            anim.Play("animacao");
        }*/

       Vector3 vel = new Vector3(
           joystick.Horizontal * velocidade + Input.GetAxis("Horizontal") * velocidade,
            0,
            joystick.Vertical * velocidade + Input.GetAxis("Vertical") * velocidade
            );

        
        if (vel.magnitude > 0.1f)//direção do personagem 
        {
            Vector3 direcaoParaOlhar = transform.position + vel * 3;
            transform.LookAt(direcaoParaOlhar);
        }

        //movimentação com animação d emovimento
        rigidbody.velocity = new Vector3(vel.x, rigidbody.velocity.y, vel.z);

        anim.SetBool("movimento", vel.magnitude > 0.1);


        //setando as animaçãoes do player
        bool botoesLivres = !joystickPtr.Pressed && !joybutton.Pressed && !attack.Pressed;

        if (botoesLivres && Input.GetButtonDown("Fire2"))
        {
            Jump = true;

            Pulo();
            anim.SetTrigger("pulo");
        } 
        /*if(Jump &&(!joybutton.Pressed || Input.GetButtonDown("Fire2")))
        {
            Jump = false;
        }*/

       if (botoesLivres && Input.GetButtonDown("Fire1"))
       {
            Ataque();
       }

    }

    public void Pulo()
    {
        if (!Jump)
        {
            rigidbody.velocity += Vector3.up * 3f;
            Jump = true;
            
        }
    }

    public void Ataque()
    {
        anim.SetTrigger("ataque");
        //Detectar os inimigos no alcance
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        //Ataca-los
        foreach (Collider enemy in hitEnemies)
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

    private void FixedUpdate()
    {
        
    }
            /*if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("animacao", true);
        }
        else
        {
            anim.SetBool("animacao", false);
            
        }*/
}
