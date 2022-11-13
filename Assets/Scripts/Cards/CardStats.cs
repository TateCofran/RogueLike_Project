using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card Stats")]
public class CardStats : ScriptableObject
{
    public string tittle;
    public string description;
    
    public Sprite icon;

    [SerializeField] int value;
    [SerializeField] int weight;

}
