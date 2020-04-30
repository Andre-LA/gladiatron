using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    
    public Transform Stick;         // Joystick.

    // particular
    private Vector3 LemePrimPos;  // Posição inicial do joystick.
    private Vector3 JoyVec;         // Vetor de joystick(direção)
    private float Radius;           // Meio diâmetro do fundo do joystick.

    void Start()
    {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        LemePrimPos = Stick.transform.position;

        // Controle de raio para o tamanho da tela.
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;
    }

    //arrastar
    public void Drag(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        // Encontre a direção para mover o joystick (direita, esquerda, cima, baixo)
        JoyVec = (Pos - LemePrimPos).normalized;

        //Encontre a distância entre a primeira posição do joystick e a posição que estou tocando no momento

        float Dis = Vector3.Distance(Pos, LemePrimPos);

        // Se a distância for menor que o raio, mova o joystick para onde você está tocando no momento.. 
        if (Dis < Radius)
            Stick.position = LemePrimPos + JoyVec * Dis;
        // Se a distância for maior que o raio, mova o joystick apenas do tamanho do raio.
        else
            Stick.position = LemePrimPos + JoyVec * Radius;
    }

    //  Arraste termina..
    public void DragEnd()
    {
        Stick.position = LemePrimPos; //  Mantenha a sua posição original.
                JoyVec = Vector3.zero;          // Direção para zero.

    }
}