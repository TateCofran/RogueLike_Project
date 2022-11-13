using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    public Transform cardSlot;
    [SerializeField] GameObject cardItem;
    [HideInInspector] CardDisplay cardDisplay;
    int cardSlots = 1;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);

        }
        else
        {
            instance = this;
        }
    }

    public void DrawCard()
    {
        var loadCards = Resources.LoadAll("Cards", typeof(CardStats));
        foreach (var card in loadCards)
        {
            for (int i = 0; i < cardSlots; i++)
            {
                int randomCard = Random.Range(0, 1);
                CardDisplay newCard = Instantiate(cardItem, cardSlot.position, Quaternion.identity, cardSlot).GetComponent<CardDisplay>();
                newCard.card = (CardStats)card;
            }
            Cursor.visible = true;
            Time.timeScale = 0f;
            GameManager.gameIsPaused = true;
        }
    }
}
