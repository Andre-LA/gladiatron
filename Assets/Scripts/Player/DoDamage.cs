using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage: MonoBehaviour
{
      float speed = 200f;
      int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerEnter(Collider other)// função para dar dano
    {
        
        //other.gameObject.GetComponent<Health>().TakeDamage(damage);
        

    }

   


}
