using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    protected GameManager gameManager;
    protected GameObject player;
    protected PlayerUI playerUI;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] GameObject floatingText;
    [SerializeField] GameObject dropLoot;
    [SerializeField] EnemyUI enemyUI;
    [SerializeField, HideInInspector] UIBehaviour UIInterface;
    private Animator anim;

    //Properties
    public float health;
    public float speed;
    public float damage;
    public float armor;
    public float magicArmor;
    public float dropExp;

    bool disableEnemy = false;
    protected float distance;
    protected float attackCd = 5f;
    float damageTaken;
    public float knockbackForce = 100;

    void Start()
    {
        UIInterface = FindObjectOfType<UIBehaviour>();
        playerUI = FindObjectOfType<PlayerUI>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!disableEnemy)
        {
            RotateEnemy();
            distance = Vector3.Distance(transform.position, player.transform.position);
            if(distance == agent.stoppingDistance)
            {
                Attack();
            }
            else
            {
                MoveEnemy();
            }
        }
    }
    //Movement
    public virtual void MoveEnemy()
    {
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);
    }

    protected virtual void RotateEnemy()
    {
        transform.LookAt(player.transform);
    }

    //Taking Damage Collision
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Bullet"))
        {
            TakeDamage();
            Death();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == ("Weapon Player"))
        {
            TakeDamage();
            Death();

        }
        if (other.gameObject.tag == ("Magic Player"))
        {
            TakeMagicDamage();
            Death();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == ("Player"))
        {

            gameManager.playerStats.Health -= damage;
            playerUI.SetHealth(gameManager.playerStats.Health);
            Debug.Log(gameManager.playerStats.Health);
        }
    }

    //Taking Damage method
    public void TakeDamage()
    {
        damageTaken = gameManager.playerStats.Damage - armor;
        health -= damageTaken;
        
        
        transform.position -= transform.forward * knockbackForce * Time.deltaTime;
        
        anim.Play("Hit");


        enemyUI.SetHealth(health);
        if(floatingText && health > 0)
        {
            ShowFloatingText();
        }
    }
    public void TakeMagicDamage()
    {
        damageTaken = gameManager.playerStats.MagicDamage - magicArmor;
        health -= damageTaken;

        anim.Play("Hit");
        
        enemyUI.SetHealth(health);
        ShowFloatingText();
    }

    public void Death()
    {
        if (health <= 0f)
        {

            Destroy(gameObject);
            Instantiate(dropLoot, transform.position, Quaternion.identity);
            gameManager.playerBehaviour.PlayerGainExp(dropExp);
            Debug.Log("Enemy is dead, you gain " + dropExp);

            UIInterface.KillsCount();
        }
    }

    //Attack
    protected virtual void Attack()
    {
        if(attackCd <= 0)
        {
            agent.isStopped = true;
            //Debug.Log("Attack");
            attackCd = 2f;
        }
        else
        {
            attackCd -= Time.deltaTime;
        }        
    }

    //Show damage dealt to enemy
    void ShowFloatingText()
    {
        GameObject points = Instantiate(floatingText, transform.position, Quaternion.identity, transform) as GameObject;
        points.GetComponent<TextMeshPro>().text = damageTaken.ToString("f0");
    }
}
