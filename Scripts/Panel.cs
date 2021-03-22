using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject PanelBox;
    public Text _text;
    public string _enterText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //Check si le player touche le gameobject
        {
            _text.text = _enterText; //Change le texte du panel
            PanelBox.SetActive(true); //Active le panel
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //Check si le player touche le gameobject
        {
            PanelBox.SetActive(false); //Désactive le panel
        }
    }
}
