using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombos : MonoBehaviour
{
    private Animator anim;
    public int combo;
    public bool isAttacking;
    public float delay;

    SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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
            soundManager.SelectAudio(1, 0.05f);
            anim.SetTrigger("Attack" + combo);
        }
    }
}
