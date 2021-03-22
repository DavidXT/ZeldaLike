using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roc : MonoBehaviour
{
    public GameObject EnigmeTile2;
    private bool inRange = false;

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && inRange)
        {
            Destroy(EnigmeTile2); //Détruit les panneaux qui bloque la route
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //Check si le player touche le gameobject
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))//Check si le player touche le gameobject
        {
            inRange = false;
        }
    }
}
