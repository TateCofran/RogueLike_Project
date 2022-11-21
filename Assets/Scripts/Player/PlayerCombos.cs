using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombos : MonoBehaviour
{
    PlayerController controller;

    private Animator anim;
    public int combo;
    public bool isAttacking;
    public float delay;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void StartCombo()
    {
        isAttacking = false;
        if(combo < 3)
        {
            combo++;
            delay += Time.deltaTime;
        }
        
    }
    void FinishCombo()
    {
        isAttacking = false;
        combo = 0;  
        delay = 0;
    }
    public void Combo()
    {
        if (/*Input.GetMouseButtonDown(0) &&*/ !isAttacking && delay <= 5f)
        {
            isAttacking = true;
            anim.SetTrigger("Attack" + combo);
        }
    }
}
