using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [Header("Parameters")]
    public SaveWeapon saveWeapon;

    [Header("Inputfields")]
    public InputField nameInput;
    public InputField diceNumberInput;
    public InputField damagesInput;
    public InputField bonusDamagesInput;
    public InputField rangeInput;
    
    public void Delete()
    {
        CharacterParametersController.instance.activeCharacter.saveCharacter.weapons.Remove(saveWeapon);
        Destroy(gameObject);
    }

    public void OnNameChanged()
    {
        saveWeapon.weaponName = nameInput.text;
    }

    public void OnDiceNumberChanged()
    {
        if (diceNumberInput.text != "")
        {
            saveWeapon.diceNumber = int.Parse(diceNumberInput.text);
        }
        else
        {
            saveWeapon.diceNumber = 0;
        }
    }

    public void OnDamagesChanged()
    {
        if (damagesInput.text != "")
        {
            saveWeapon.damages = int.Parse(damagesInput.text);
        }
        else
        {
            saveWeapon.damages = 0;
        }
    }

    public void OnBonusDamagesChanged()
    {
        if (bonusDamagesInput.text != "")
        {
            saveWeapon.bonusDamages = int.Parse(bonusDamagesInput.text);
        }
        else
        {
            saveWeapon.bonusDamages = 0;
        }
    }

    public void OnRangeChanged()
    {
        if (rangeInput.text != "")
        {
            saveWeapon.range = float.Parse(rangeInput.text);
        }
        else
        {
            saveWeapon.range = 0;
        }
    }
}

[Serializable]
public class SaveWeapon
{
    public string weaponName;
    public int diceNumber;
    public int damages;
    public int bonusDamages;
    public float range;

    public SaveWeapon()
    {

    }

    public SaveWeapon(SaveWeapon toCopy)
    {
        weaponName = toCopy.weaponName;
        diceNumber = toCopy.diceNumber;
        damages = toCopy.damages;
        bonusDamages = toCopy.bonusDamages;
        range = toCopy.range;
    }
}
