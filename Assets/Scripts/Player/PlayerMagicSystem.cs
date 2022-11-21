using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    private float currentCastTimer;
    public bool isCasting = false;

    [SerializeField] public Spell spellToCast;
    [SerializeField] public Transform castPoint;
    [SerializeField] public Transform spellParent;
    GameManager gameManager;
    PlayerUI playerUI;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        playerUI = FindObjectOfType<PlayerUI>();
        gameManager = FindObjectOfType<GameManager>();
    }
    public void CastSpell()
    {
        if(isCasting == false)
        {
            if (gameManager.playerStats.Mana <= 0)
            {
                Debug.Log("No mana");
                return;
            }
            else
            {
                isCasting = true;
                gameManager.playerStats.Mana -= spellToCast.spellCast.manaCost;
                playerUI.SetMana(gameManager.playerStats.Mana);
                anim.SetTrigger("MagicAttack");
            }
        }
       
    }


}
