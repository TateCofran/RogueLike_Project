using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    protected GameManager gameManager;
    protected GameObject player;
    protected PlayerUI playerUI;
    
    [SerializeField] GameObject floatingText;
    [SerializeField] GameObject dropLoot;
    [SerializeField] EnemyUI enemyUI;
    [SerializeField, HideInInspector] UIBehaviour UIInterface;
    
    [HideInInspector] protected Animator anim;

    //Properties
    public float health;
    public float speed;
    public float damage;
    public float armor;
    public float magicArmor;
    public float dropExp;

    public bool isAlive = true;
    //NavMesh
    [SerializeField] protected NavMeshAgent agent;
    protected bool disableEnemy = false;
    bool attacked = false;
    protected float distance;
    protected float attackCd = 5f;
    float damageTaken;
    public float knockbackForce = 100;

    float hitTime;
    void Start()
    {
        UIInterface = FindObjectOfType<UIBehaviour>();
        playerUI = FindObjectOfType<PlayerUI>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
        
        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        isAlive = true;
    }

    void Update()
    {
      /*  if (!disableEnemy)
        {
            RotateEnemy();
            distance = Vector3.Distance(transform.position, player.transform.position);
           
            if(distance > agent.stoppingDistance)
            {
                Attack();

            }
            else
            {
                MoveEnemy();
            }
        }*/
    }

    //Movement
    protected virtual void MoveEnemy()
    {
        agent.updatePosition = true;
        agent.SetDestination(player.transform.position);

        anim.SetBool("IsHitting", false);
        //anim.SetBool("IsWalking", true);
        //anim.SetBool("IsAttacking", false);

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
            
            //Death();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == ("Weapon Player"))
        {
            TakeDamage();
            //Death();

        }
        if (other.gameObject.tag == ("Magic Player"))
        {
            TakeMagicDamage();
            //Death();
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

        anim.SetBool("IsHitting", true);
        Invoke("HitTime", 0.5f);

        enemyUI.SetHealth(health);
        
        ShowFloatingText();
        
        if(health <= 0)
        {
            Death();
        }
    }
    public void TakeMagicDamage()
    {
        damageTaken = gameManager.playerStats.MagicDamage - magicArmor;
        health -= damageTaken;

        anim.SetBool("IsHitting", true);
        Invoke("HitTime", 0.5f);

        enemyUI.SetHealth(health);
        ShowFloatingText();

        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        disableEnemy = true;
        agent.updatePosition = false;
        isAlive = false;

        anim.SetTrigger("IsDead");
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        Destroy(enemyUI.healthSlider);


        Destroy(gameObject, 5f);

        Instantiate(dropLoot, transform.position, Quaternion.identity);
        gameManager.playerBehaviour.PlayerGainExp(dropExp);

        UIInterface.KillsCount();

    }

    public void HitTime()
    {
        anim.SetBool("IsHitting", false);
    }
    //Attack
    protected virtual void Attack()
    {

        if (attackCd <= 0)
        {
            agent.updatePosition = false;
            attacked = true;
            AttackCooldown();
            //attackCd = 2f;
            //anim.SetBool("IsWalking", false);
            //anim.SetBool("IsAttacking", true);
        }
        else
        {
            attacked = false;
            AttackCooldown();
            //attackCd -= Time.deltaTime;
        }        
    }

    protected virtual void AttackCooldown()
    {
        if(attacked == true)
        {
            float startAttackCooldown = 5;
            startAttackCooldown = attackCd;
        }
        else if(attacked == false)
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
