using UnityEngine;

public class ClosedEnemy : Enemy
{
    private void Update()
    {
        RotateEnemy();
        MoveEnemy();
        Attack();

    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Attack)");
            gameManager.playerStats.Health -= damage;
            gameManager.playerUI.SetHealth(gameManager.playerStats.Health);
        }
    }
}
