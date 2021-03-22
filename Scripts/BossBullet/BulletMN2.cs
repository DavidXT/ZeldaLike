using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMN2 : BossBullet
{
    private Rigidbody2D _rb;
    private Vector3 aim;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody2D>();
        aim = (target.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(aim * bulletSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)//si elle entre en collision
    {
        if (other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("BossBullet")) //La bullet traverse tout sauf le joueur
        {
            PlayerController _player = other.gameObject.GetComponent<PlayerController>();
            _player.TakeDamage(bulletDmg);
            Destroy(gameObject);//Detruit la bullet
        }
    }
}
