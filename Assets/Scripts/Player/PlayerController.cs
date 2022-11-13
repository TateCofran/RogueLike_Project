using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform model;
    [HideInInspector] private Animator animator;
    
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    [HideInInspector] public Vector3 input;

    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform bulletParent;
    [SerializeField] GameObject bullet;

    [SerializeField] float dashDistance;
    [HideInInspector]public int dashAmount = 3;
    [HideInInspector]public int maxDashAmount = 3;
    
    float dashCd;

    //[SerializeField] GameObject floatingText;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        GatherInput();
        Rotation();
        Look();
        dashCd += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(dashAmount > 0)
            {
                StartCoroutine(Dash());
            }            
        }
        if (dashAmount < maxDashAmount)
        {
            if (dashCd >= 5f)
            {
                dashAmount++;
                dashCd = 0;
                Debug.Log(dashAmount + "/" + maxDashAmount);
            }
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        animator.SetFloat("Vel X", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Vel Z", Input.GetAxisRaw("Vertical"));
    }

    private void Move()
    {
        rb.MovePosition(transform.position + input.ToIso() * input.normalized.magnitude * speed * Time.deltaTime);
    }
    private void Look()
    {
        if (input == Vector3.zero) return;

        Quaternion rot = Quaternion.LookRotation(input.ToIso(), Vector3.up);
        model.rotation = Quaternion.RotateTowards(model.rotation, rot, turnSpeed * Time.deltaTime);
    }

    void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation, bulletParent);
    }

    IEnumerator Dash()
    {
        transform.position += input.ToIso() * input.normalized.magnitude * dashDistance;    
        dashAmount --;
        Debug.Log("Dash, you have " + dashAmount + " left");
        yield return null;      
    }
}