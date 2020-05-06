using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform obj;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + obj.forward);
    }
}
