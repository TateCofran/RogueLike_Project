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

}
