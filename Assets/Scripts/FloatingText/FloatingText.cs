using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0.2f, 0);
    public Vector3 RandomizeIntensity = new Vector3(0.5f, 0, 0);
    void Start()
    {
        Destroy(gameObject, 1f);
        transform.localPosition += offset;    
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x), 
                                               Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y), 
                                               Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z)); 
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

    }
}
