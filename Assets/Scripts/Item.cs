using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmour;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Effect Details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr;

    [Header("Weapon/Armor Details")]
    public int weaponStrength;

    public int armorStrength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Use(int charToUseOn)
    {
     
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];
  
        if (isItem)
        {
            if (selectedChar.currentHP != selectedChar.maxHP)
            {
                
                if (affectHP)
                {
                    
                    selectedChar.currentHP += amountToChange;

                    if (selectedChar.currentHP > selectedChar.maxHP)
                    {
                        selectedChar.currentHP = selectedChar.maxHP;
                    }

                    if (BattleManager.instance.battleActive)// update player battle stats
                    {
                        BattleManager.instance.activeBattlers[charToUseOn].currentHp += amountToChange;
                        if (BattleManager.instance.activeBattlers[charToUseOn].currentHp > BattleManager.instance.activeBattlers[charToUseOn].maxHP)
                        {
                            BattleManager.instance.activeBattlers[charToUseOn].currentHp = BattleManager.instance.activeBattlers[charToUseOn].maxHP;
                        }

                    }
                }
            }

            if (selectedChar.currentMP != selectedChar.maxMP)
            {
                if (affectMP)
                {
                    selectedChar.currentMP += amountToChange;
                    if (selectedChar.currentMP > selectedChar.maxMP)
                    {
                        selectedChar.currentMP = selectedChar.maxMP;
                    }


                    if (BattleManager.instance.battleActive)// update player battle stats
                    {

                        BattleManager.instance.activeBattlers[charToUseOn].currentMP += amountToChange;
                        if (BattleManager.instance.activeBattlers[charToUseOn].currentMP > selectedChar.maxMP)
                        {
                            BattleManager.instance.activeBattlers[charToUseOn].currentMP = selectedChar.maxMP;
                        }
                    }

                }
            }

            if (affectStr)
            {
                selectedChar.strength += amountToChange;

                
            }
            GameManager.instance.RemoveItem(itemName);
        }

        if (isWeapon)
        {
            if (selectedChar.equippedWeapon != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWeapon);
            }

            selectedChar.equippedWeapon = itemName;
            selectedChar.weaponPower = weaponStrength;

            GameManager.instance.RemoveItem(itemName);
        }

        if (isArmour)
        {
            if (selectedChar.equippedArmor != "")
            {
               GameManager.instance.AddItem(selectedChar.equippedArmor);
            }

            selectedChar.equippedArmor = itemName;
            selectedChar.armorPower = armorStrength;

            GameManager.instance.RemoveItem(itemName);
        }


        if(BattleManager.instance.battleActive)
        {
            BattleManager.instance.itemMenu.SetActive(false);
        }
        


    }
}
