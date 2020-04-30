using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Hit
{
    public string animacao;
    public float tempo = 0.5f;
}

public class Combos : MonoBehaviour
{
    public bool On=true;
    bool Ativado=true;
    [Space(10)]
    public int AtualHit;
    public Hit[] Ataques;
    bool combando;
    int QuantClick;

    public Animator anim;

    public void On_Off()
    {
        Ativado = !Ativado;
        AtualHit = 0;
        On = Ativado;
    }
    public void combo()
    {
        if (!Ativado)
        {
            AtualHit = 0;
            return;
        }



        if (AtualHit < Ataques.Length)
        {
            if (QuantClick < 1)
            {



                if (AtualHit > 0)
                {
                    QuantClick += 1;
                }


                if (!combando)
                {
                    AtualHit += 1;
                    anim.Play(Ataques[AtualHit - 1].animacao);
                    Invoke("resetTempo", Ataques[AtualHit - 1].tempo);
                    combando = true;
                }
                

            }
        }
       
    }
    void resetTempo()
    {
        
        combando = false;
        if ((QuantClick) == 0)
        {
           
            AtualHit = 0;
        }
        if ((QuantClick) == 1)
        {
            QuantClick = 0;
            combo();
        }

        QuantClick = 0;
    }



    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            combo();
        }
    }
}

