using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    public SpellSO spellCast;
    private Rigidbody rb;
    private SphereCollider sCollider;

    private void Awake()
    {
        sCollider = GetComponent<SphereCollider>();
        sCollider.isTrigger = true;
        sCollider.radius = spellCast.spellRadius;
        
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        Destroy(this.gameObject, spellCast.lifeTime);
    }
    private void Update()
    {
        transform.Translate(Vector3.up * spellCast.speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //apply spell effect
        //apply hit effects
        Destroy(this.gameObject);

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //health enemy
        }
    }

}
