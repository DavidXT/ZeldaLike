using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBullet : MonoBehaviour
{
    public int bulletDmg;
    public int bulletSpeed;
    public Transform target;
    public const float timerDestroy = 5f;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player"); //Récupère le joueur en tant que cible
        target = Player.transform;
        Destroy(gameObject, timerDestroy);//Détruit le gameobject après un certain nombre de temps
    }

}
