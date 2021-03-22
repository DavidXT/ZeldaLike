using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMob : AEnemy
{
    public float chaseRange;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        checkRange();
    }

    protected override void Attack()
    {
        //Pas d'attack pour le moment
    }

    protected override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,_target.position, moveSpeed * Time.deltaTime);//Déplacement du trashmob
    }

    void checkRange()
    {
        if (Vector3.Distance(_target.position, transform.position) <= chaseRange && Vector3.Distance(_target.position, transform.position) > 0.5)//Check de la range entre le joueur et le trashmob
        {
            Move();
        }
    }
}
