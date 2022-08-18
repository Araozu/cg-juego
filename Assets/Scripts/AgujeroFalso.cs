using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgujeroFalso : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        var objeto = other.gameObject;
        if (objeto.CompareTag("Player"))
        {
            var posY = objeto.transform.position.y;
            objeto.transform.position = new Vector3(0, posY, 0);
        }
    }
}
