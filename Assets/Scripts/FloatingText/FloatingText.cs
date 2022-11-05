using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
        transform.localPosition += new Vector3(0, 0.5f, 0);      
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

    }
}
