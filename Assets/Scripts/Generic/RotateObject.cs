using UnityEngine;

public class RotateObject : MonoBehaviour
{
	public float velocidade = 0.5f;
	public Vector3 direcao;

	void Update()
	{
		transform.Rotate((direcao * velocidade) * Time.deltaTime);
	}
}
