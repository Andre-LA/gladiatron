using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolverPorDistancia : MonoBehaviour
{
    public Transform cam_disolve;
    public ControladorDissolvimento controlador;
    public float fator, deslocamento;
    

    Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        if (!cam_disolve || !controlador)
            return;
        float distancia = Vector3.Distance(cam_disolve.position, tr.position);
        float distanciaAjustada = (distancia / fator) + deslocamento;
        controlador.MudarValor(distanciaAjustada);

    }
}
