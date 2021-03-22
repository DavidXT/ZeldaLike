using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AEnemy : MonoBehaviour
{
    public int HP; //HPMAX
    public int currentHP; //HPACTUEL
    public int Damages; //Dégat au contact
    public float moveSpeed; 
    public float attackRange; 
    public Transform _target;

    //Pour éviter les magics numbers
    public int valueZero = 0;


    protected virtual void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player"); //récupère le gameobject du joueur
        _target = Player.transform;
        currentHP = HP;
    }


    protected abstract void Move();
    protected abstract void Attack();

    //Fonction de prise de dégat
    public virtual void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= valueZero)
        {
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        Destroy(gameObject);//Detruit le game object
    }
}