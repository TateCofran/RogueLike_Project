using UnityEngine;

public class ClosedEnemy : Enemy
{
    [SerializeField] BoxCollider weapon;

    private void Awake()
    {
        DesactivateColliderWeapon();
    }
    private void Update()
    {
        if (!disableEnemy)
        {
            RotateEnemy();
            distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= agent.stoppingDistance)
            {
                Attack();

            }
            else
            {
                MoveEnemy();
            }
        }
    }

    protected override void MoveEnemy()
    {
        base.MoveEnemy();
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsAttacking", false);
    }

    protected override void Attack()
    {
        base.Attack();
        
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsAttacking", true);
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Attack)");
            gameManager.playerStats.Health -= damage;
            gameManager.playerUI.SetHealth(gameManager.playerStats.Health);
        }
    }

    void ActivateColliderWeapon()
    {
        weapon.enabled = true;
        
    }
    void DesactivateColliderWeapon()
    {
        weapon.enabled = false;
    }
}
