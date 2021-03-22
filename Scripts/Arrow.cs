using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    public float arrowLife = 5f;
    public int arrowDmg = 1;
    public Rigidbody2D _rb;
    private void Start()
    {
        Destroy(gameObject, arrowLife);//si la balle est toujours vivantes après 5 secondes, on la détruit
    }

    void OnTriggerEnter2D(Collider2D other)//si elle entre en collision
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
            {
                AEnemy _enemy = other.gameObject.GetComponent<AEnemy>();//Recup les données AEnemy de l'ennemie touché
                _enemy.TakeDamage(arrowDmg); //Inflige des dégats a l'ennemie    
            }
            Destroy(gameObject);//Detruit l'arrow
        }
    }

    //Déplacement de la flèche
    public void Setup(Vector2 velocity, Vector3 direction)
    {
        _rb.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);

    }
}
