using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossPhase
{
    Phase1, Phase2, Phase3
}
public class Boss : AEnemy
{
    //Liste des prefabs des bullets
    public GameObject BulletDefault;
    public GameObject MN1;
    public GameObject MN2;
    public GameObject MN3;
    public GameObject MN4;


    public BossPhase currentState;
    public Transform firePoint;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    //Pour éviter les magics numbers
    private const float unTier = 0.34f;
    private const float deuxTier = 0.67f;
    private const int entier1 = 1;
    private const int zero = 0;
    private const int minBullet = 1;
    private const int maxBullet = 5;

    private void Start()
    {
        base.Start();
        currentState = BossPhase.Phase1;
    }

    private void Update()
    {
        Attack();
    }
    protected override void Attack()
    {
        if (fireCountdown <= zero)//Check si le boss peut tirer
        {
            if (currentState == BossPhase.Phase1)//Check la phase du boss 
            {
                //Phase 1
                AttackPhase1();
                if ((float)currentHP/(float)HP <= deuxTier)
                {
                    currentState = BossPhase.Phase2;
                }
            }
            if (currentState == BossPhase.Phase2)
            {
                //Phase 2
                AttackMagicNumbers();
                if ((float)currentHP / (float)HP <= unTier)
                {
                    GameObject bossfield = GameObject.FindGameObjectWithTag("bossField");
                    Destroy(bossfield);
                    currentState = BossPhase.Phase3;
                }
            }
            if (currentState == BossPhase.Phase3)
            {
                //Phase 3
                AttackMagicNumbers();
            }
            fireCountdown = entier1 / fireRate;
        }
        fireCountdown -= Time.deltaTime; 
    }

    protected override void Move()
    {
       //PAS DE MOUVEMENT ATM
    }

    void AttackPhase1()
    {
        //Instantiate des bullets de base si le boss à la porté sur le joueur
        if (Vector3.Distance(_target.position, transform.position) <= attackRange)
        {
            Instantiate(BulletDefault, firePoint.position, Quaternion.identity);
        }
    }

    void AttackMagicNumbers()
    {
        //Instantiate des magics numbers générer aléatoirement
        int RandomAttack = Random.Range(minBullet, maxBullet);
        switch (RandomAttack)
        {
            case 1:
                Instantiate(MN1, firePoint.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(MN2, firePoint.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(MN3, firePoint.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(MN4, firePoint.position, Quaternion.identity);
                break;
        }
    }
}
