using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMN3 : BossBullet
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed*Time.deltaTime;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);//La balle va en direction de la cible
    }
    void OnTriggerEnter2D(Collider2D other)//si elle entre en collision
    {
        if (!other.gameObject.CompareTag("Boss") && !other.gameObject.CompareTag("BossBullet"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerController _player = other.gameObject.GetComponent<PlayerController>();
                _player.TakeDamage(bulletDmg);
            }
            Destroy(gameObject);//Detruit la bullet
        }
    }
}
