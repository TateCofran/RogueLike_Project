using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBoss : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float speed;
    public float damage;
    public float attackCooldown;
    public float dropExp;
    bool attacked;
    float damageTaken;
    float attackDistance;

    int phase;
    int attacks;
    bool isAlive = true;

    public NavMeshAgent agent;
    public Animator anim;
    GameObject player;

    float distance;

    public GameObject floatingText;
    public GameObject dropLoot;
    BossEnemyUI ui;
    GameManager gameManager;
    PlayerUI playerUI;
    UIBehaviour UIInterface;

    public CapsuleCollider[] arms;

    // Start is called before the first frame update
    private void Awake()
    {
        DesactivateColliderWeapon();

    }
    void Start()
    {
        ui = FindObjectOfType<BossEnemyUI>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
        UIInterface = FindObjectOfType<UIBehaviour>();
        playerUI = FindObjectOfType<PlayerUI>();

        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        phase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive == true)
        {
            attackDistance = Vector3.Distance(transform.position, player.transform.position);
            Rotate();

            if (attackDistance <= agent.stoppingDistance && attackCooldown <= 0)
            {
                Attack();
            }
            else if (attackDistance > agent.stoppingDistance && attacked == false)
            {
                Move();
                attackCooldown -= Time.deltaTime;
            }
        }
    }

    void Move()
    {
        agent.updatePosition = true;
        agent.SetDestination(player.transform.position);

        anim.SetBool("IsWalking", true);
        anim.SetBool("IsAttacking", false);

    }
    void Rotate()
    {
        transform.LookAt(player.transform);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Bullet"))
        {
            TakeDamage();


            
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == ("Weapon Player"))
        {
            TakeDamage();


        }
        if (other.gameObject.tag == ("Magic Player"))
        {
            TakeMagicDamage();

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
        damageTaken = gameManager.playerStats.Damage;
        health -= damageTaken;


        transform.position -= transform.forward * Time.deltaTime;


        ui.SetHealth(health);

        ShowFloatingText();

        if (health <= 250f && health >= 225f)
        {
            phase = 2;
            speed = 4f;


            agent.updatePosition = false;
            anim.Play("Roaring");
            anim.SetBool("IsEnraged", true);
        }
        if (health <= 0)
        {
            Death();
        }
    }
    public void TakeMagicDamage()
    {
        damageTaken = gameManager.playerStats.MagicDamage;
        health -= damageTaken;

        ui.SetHealth(health);
        ShowFloatingText();

        if (health <= 250f && health >= 225f)
        {
            phase = 2;
            speed = 4f;

            agent.stoppingDistance = 10;
            agent.updatePosition = false;
            anim.Play("Roaring");
            anim.SetBool("IsEnraged", true);
        }
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        isAlive = false;
        agent.updatePosition = false;


        anim.SetTrigger("IsDead");
        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        ui.gameObject.SetActive(false);


        Destroy(gameObject, 5f);

        Instantiate(dropLoot, transform.position, Quaternion.identity);
        gameManager.playerBehaviour.PlayerGainExp(dropExp);

        UIInterface.KillsCount();

    }
    void Attack()
    {
        agent.updatePosition = false;
        attacked = true;

        int melee = Random.Range(0, 4);
        switch (melee)
        {
            case 0:
                //Attack 1
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsAttacking", true);
                anim.SetInteger("Attack", 1);
                attackCooldown = 2f;

                attacked = false;
                break;
            case 1:
                if(phase == 2)
                {
                    anim.SetBool("IsWalking", false);
                    anim.SetBool("IsAttacking", true);
                    anim.SetInteger("Attack", 2);
                    attackCooldown = 1f;

                    attacked = false;
                }
                else
                {
                    melee = 0;
                }
                break;
            default:
                melee = 0;
                break;
        }
    }
    void ActivateColliderWeapon()
    {
        for(int i = 0; i < arms.Length; i++)
        {
            arms[i].enabled = true;
        }
    }
    void DesactivateColliderWeapon()
    {
        for (int i = 0; i < arms.Length; i++)
        {
            arms[i].enabled = false;
        }
    }
    void ShowFloatingText()
    {
        GameObject points = Instantiate(floatingText, transform.position, Quaternion.identity, transform) as GameObject;
        points.GetComponent<TextMeshPro>().text = damageTaken.ToString("f0");
    }
}
