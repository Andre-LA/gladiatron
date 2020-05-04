using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    public Animator animator; //criado para receber opção de animação para o codigo
    public float velocidade = 20.0f; //informa a velocidade de movimentação em numeros reais
    private Vector3 pos;// criamos a pos para andar nos eixos x y z

	void Start()
	{
		
	}

	void Update()
	{
     //aqui usamos o transfom para andar como menino(não é a classe)
     pos = transform.position;
     pos.x += velocidade * Input.GetAxis("Horizontal") * Time.deltaTime;
     pos.z += velocidade * Input.GetAxis("Vertical") * Time.deltaTime;
     transform.position = pos;

	}

  
}
