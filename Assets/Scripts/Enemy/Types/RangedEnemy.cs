using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnBullet;
    [SerializeField] Transform barrel;
    
    //[SerializeField] float fireSpeed;


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

            attackCd -= Time.deltaTime;

        }
    }
    protected override void MoveEnemy()
    {
        base.MoveEnemy();
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsAttacking", false);
        //anim.SetBool("IsCasting", false);
    }
    protected override void Attack()
    {
        if (attackCd <= 0)
        {
            agent.updatePosition = false;
            agent.SetDestination(player.transform.position);

            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", true);
            
            //anim.SetBool("IsCasting", false);


        }
        else if (attackCd > 0)
        {
            //anim.SetBool("IsCasting", true);
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsWalking", false);
        }
    }

     public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public void SpellCast()
    {

        Instantiate(bullet, barrel.position, barrel.rotation);
        attackCd = 4f;

    }
}
