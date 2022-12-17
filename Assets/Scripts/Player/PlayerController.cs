using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Character
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform model;
    [HideInInspector] private Animator animator;
    
    //Movement
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    [HideInInspector] public Vector3 input;

    //Bullet
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform bulletParent;
    [SerializeField] GameObject bullet;

    //Dash
    [SerializeField] float dashDistance;
    [HideInInspector]public int dashAmount = 3;
    [HideInInspector]public int maxDashAmount = 3;
    
    float dashCd;

    //Attack
    [SerializeField] public bool isAttacking = false;
    [SerializeField] public bool hasMeleeWeapon = true;
    [SerializeField] BoxCollider swordCollider;
    [SerializeField] GameObject sword;

    //Magic
    [SerializeField] PlayerMagicSystem playerMagicSystem;

    //Combos
    [SerializeField] PlayerCombos playerCombos;

    //Audio
    SoundManager soundManager;
    
    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        animator = GetComponent<Animator>();
        DesactivateColliderWeapon();
        
    }
    private void Update()
    {
        GatherInput();
        Rotation();
        Look();
        ActivateWeapon();
        dashCd += Time.deltaTime;
        
        if (Input.GetMouseButtonDown(0))
        {
            if (hasMeleeWeapon == true)
            {
                playerCombos.Combo();
                //playerCombos.isAttacking = false;
            }
            else
            {
                Shoot();
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            playerMagicSystem.CastSpell();
            playerMagicSystem.isCasting = false;
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            hasMeleeWeapon =! hasMeleeWeapon;
        }
    }

    private void FixedUpdate()
    {
        if(playerCombos.isAttacking == false)
        {
            Move();
        }

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
        soundManager.SelectAudio(0, 0.05f);
        transform.position += input.ToIso() * input.normalized.magnitude * dashDistance;
        dashAmount --;
        Debug.Log("Dash, you have " + dashAmount + " left");
        yield return null;      
    }

    #region Animator weapon and spell
    //ActivateWeapon
    void ActivateWeapon()
    {
        if(hasMeleeWeapon == true)
        {
            sword.SetActive(true);
        }
        else
        {
            sword.SetActive(false);
        }
    }
    //Collider Weapons
    void ActivateColliderWeapon()
    {
        if(hasMeleeWeapon == true)
        {
            swordCollider.enabled = true;
        }
    }
    void DesactivateColliderWeapon()
    {
        swordCollider.enabled = false;
    }

    void ActivateSpell()
    {
        sword.SetActive(false);
        Instantiate(playerMagicSystem.spellToCast, playerMagicSystem.castPoint.position, playerMagicSystem.castPoint.rotation, playerMagicSystem.spellParent);
    }
    void DesactivateSpell()
    {
        sword.SetActive(true);
    }
    #endregion
}