using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigm : MonoBehaviour
{
    public GameObject Enigme;
    public GameObject Enigme2;
    public GameObject[] ennemies;
    public GameObject Sign;
    private Panel newText;

    private int valueZero = 0;
    private void Start()
    {
        newText = Sign.GetComponent<Panel>();
    }
    // Update is called once per frame
    void Update()
    {
        //Check le nombre d'ennemies encore en vie 
        UpdateEnnemies();

        //Si nombre d'ennemie = 0 ouvrir le passage vers le boss
        if(ennemies.Length == valueZero)
        {
            newText._enterText = "Bien joué";//Change le texte du panneau
            Destroy(Enigme);//Détruit les panneaux qui bloque le chemin
        }

        //Code cheat pour la démo
        if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(Enigme);
            Destroy(Enigme2);
        }
    }

    public void UpdateEnnemies()
    {
        ennemies = GameObject.FindGameObjectsWithTag("Enemy");//Récupère tout les ennemies
    }
}
