using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDissolvimento : MonoBehaviour
{
    [Range(0,1)]
    public float valor;
    /*public Material mat;*/
    public MeshRenderer meshRend;
    public bool AtualizarNoUp, inverter_dissolve;

    private void Start()
    {
        Atualizar();
    }

    void Update()
    {
        if (AtualizarNoUp)
            Atualizar();
    }
    public void MudarValor(float novoValor)
    {
        if (inverter_dissolve)
            valor = Mathf.Abs(1 - Mathf.Clamp01(novoValor));
        else
        valor = Mathf.Clamp01(novoValor);
        Atualizar();
    }
    void Atualizar()
    {
        if (!meshRend)
            return;
        if (meshRend)
            for (int i = 0; i < meshRend.materials.Length; i++)
                meshRend.materials[i].SetFloat("_DissolveCutoff", valor);
    }
}


/*
 *     public float valor;
    public Material mat;
    public MeshRenderer meshRend;

    float valorAnterior;

    private void Start()
    {
        valorAnterior = valor;
    }
    private void Update()
    {
        if (Mathf.Abs(valor - valorAnterior) < 0.01f)
        return;

        valorAnterior = valor;
        if (mat)
            mat.SetFloat("_DissolveCutoff", valor);
        if (meshRend)
            meshRend.materials[0].SetFloat("_DissolveCutOff", valor);
    }
}
*/