using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card Stats")]
public class CardStats : ScriptableObject
{
    public string tittle;
    public string description;
    
    public Sprite icon;

    public bool isLevelDmg = false;
    public bool isLevelMana = false;
    public bool isLevelHp = false;
    public bool isLevelMagicDmg = false;

}
