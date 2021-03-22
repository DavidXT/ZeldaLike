using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum PlayerState{
    walk,attack
}
public class PlayerController : MonoBehaviour
{
    public GameObject prefabArrow;
    public float speed;
    private Rigidbody2D _rb;
    private Vector3 mouvement;
    private Animator _animator;
    public PlayerState currentState;
    public Vector3 arrowDir;
    public int HP;
    public int currentHP;
    public Image HealthBar;
    public GameObject GameOverPanel;

    //Pour éviter les magics numbers
    public const float waitBeforeWalkingAgain = 0.4f;
    public const int valueZero = 0;
    public const int positionY = 180;
    public const int valueSpawn = -1;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currentHP = HP;
        _animator.SetFloat("Horizontal", valueZero);
        _animator.SetFloat("Vertical", valueSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        mouvement = Vector3.zero;
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(PlayerAttack());
            SpawnArrow();
        }
    }

    //Update pour le déplacement pour éviter les bug de vitesse
    private void FixedUpdate()
    {
        if (currentState == PlayerState.walk)
        {
            PlayerAnimationMouvement();
        }
    }

    //Mise à jour de l'animator
    void PlayerAnimationMouvement()
    {
        if (mouvement != Vector3.zero)
        {
            Move();
            _animator.SetFloat("Horizontal", mouvement.x);
            _animator.SetFloat("Vertical", mouvement.y);
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }

    IEnumerator PlayerAttack()
    {
        _animator.SetBool("IsAttacking", true);
        currentState = PlayerState.attack;
        yield return null;
        _animator.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(waitBeforeWalkingAgain); //Lag entre l'attack et le mouvement pour éviter le spam
        currentState = PlayerState.walk;
    }

    void Move() {
        _rb.MovePosition(transform.position + mouvement * speed * Time.deltaTime); //Déplacement du joueur
    }

    private void SpawnArrow()
    {
        float tempHorizontal = _animator.GetFloat("Horizontal"); //Récupère le float pour la direction et la rotation
        float tempVertical = _animator.GetFloat("Vertical"); //Récupère le float pour la direction et la rotation
        Vector3 temp = new Vector3(tempHorizontal, tempVertical, valueZero); //Direction de la flèche
        float tempRotation = Mathf.Atan2(tempHorizontal, tempVertical) * Mathf.Rad2Deg; 
        Vector3 rotationArrow = new Vector3(valueZero, positionY, tempRotation); //Rotation de la flèche
        Arrow arrow = Instantiate(prefabArrow, transform.position, Quaternion.identity).GetComponent<Arrow>(); //Instantiate la flèche
        arrow.Setup(temp, rotationArrow); //Déplacement de la flèche
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            AEnemy _enemy = other.gameObject.GetComponent<AEnemy>(); 
            TakeDamage(_enemy.Damages); //Prend des dégats en cas de contact avec un ennemie
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        HealthBar.fillAmount = (float)currentHP / (float)HP; //Reduit la health bar de l'ennemie
        if (currentHP <= valueZero)
        {
            GameOverPanel.SetActive(true); //Active le panel de game over
            Destroy(this); //Détruit le playercontroller
        }
    }
}
