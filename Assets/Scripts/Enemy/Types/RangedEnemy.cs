using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnBullet;
    [SerializeField] Transform barrel;
    
    //[SerializeField] float fireSpeed;


    private void Update()
    {
        MoveEnemy();
        RotateEnemy();
        Attack();

    }

    protected override void Attack()
    {
        if (attackCd <= 0)
        {
            agent.isStopped = true;
            Instantiate(bullet, barrel.position, barrel.rotation);           
            Debug.Log("Shoot");
            attackCd = 5f;
        }
        else
        {
            attackCd -= Time.deltaTime;
        }
    }

     public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
