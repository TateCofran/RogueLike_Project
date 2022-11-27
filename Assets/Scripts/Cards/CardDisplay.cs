using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public CardStats card;
    public TextMeshProUGUI tittleText;
    public TextMeshProUGUI descriptionText;

    public Image icon;

    public bool isSelected = false;

    private void Start()
    {
        
        tittleText.text = card.tittle;
        descriptionText.text = card.description;
        icon.sprite = card.icon;
    }
    public void SelectCard()
    {
        isSelected = true;

        Debug.Log("Cards "+ card.tittle +" was selected");
        LevelStats();
        DiscardCards();

    }

    void DiscardCards()
    {
        isSelected = false;
        foreach (Transform card in CardManager.instance.cardSlot)
        {
            Destroy(card.gameObject);

        }

        Cursor.visible = false;

        GameManager.gameManager.Resume();
    }

    void LevelStats()
    {
        if(card.isLevelDmg == true)
        {
            GameManager.gameManager.playerStats.IncreaseDamage(GameManager.gameManager.playerStats.Level);
            Debug.Log("Damage: " + GameManager.gameManager.playerStats.Damage);
        }
        if (card.isLevelMana == true)
        {
            GameManager.gameManager.playerStats.IncreaseMana(GameManager.gameManager.playerStats.Level);
            Debug.Log("Mana: " + GameManager.gameManager.playerStats.Mana);
        }
        if (card.isLevelHp == true)
        {
            GameManager.gameManager.playerStats.IncreaseHealth(GameManager.gameManager.playerStats.Level);
            Debug.Log("Health: " + GameManager.gameManager.playerStats.Health);
        }
        if (card.isLevelMagicDmg == true)
        {
            GameManager.gameManager.playerStats.IncreaseMagicDamage(GameManager.gameManager.playerStats.Level);
            Debug.Log("Magic Damage: " + GameManager.gameManager.playerStats.MagicDamage);
        }
    }
}
