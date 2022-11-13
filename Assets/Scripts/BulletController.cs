using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    [SerializeField] float speed = 45f;
    float timeToDestroy;


    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        timeToDestroy += 1 * Time.deltaTime;

        if (timeToDestroy >= 1.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //health enemy
        }
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
