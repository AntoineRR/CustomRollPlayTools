using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [Header("Parameters")]
    public SaveAbility saveAbility;

    [Header("Inputfields")]
    public InputField nameInput;
    public InputField diceNumberInput;
    public InputField damagesInput;
    public InputField bonusDamagesInput;
    public InputField rangeInput;
    public InputField pmCostInput;
    public InputField descriptionInput;
    
    public void Delete()
    {
        CharacterParametersController.instance.activeCharacter.saveCharacter.abilities.Remove(saveAbility);
        Destroy(gameObject);
    }

    public void OnNameChanged()
    {
        saveAbility.abilityName = nameInput.text;
    }

    public void OnDiceNumberChanged()
    {
        if (diceNumberInput.text != "")
        {
            saveAbility.diceNumber = int.Parse(diceNumberInput.text);
        }
        else
        {
            saveAbility.diceNumber = 0;
        }
    }

    public void OnDamagesChanged()
    {
        if (damagesInput.text != "")
        {
            saveAbility.damages = int.Parse(damagesInput.text);
        }
        else
        {
            saveAbility.damages = 0;
        }
    }

    public void OnBonusDamagesChanged()
    {
        if (bonusDamagesInput.text != "")
        {
            saveAbility.bonusDamages = int.Parse(bonusDamagesInput.text);
        }
        else
        {
            saveAbility.bonusDamages = 0;
        }
    }

    public void OnRangeChanged()
    {
        if (rangeInput.text != "")
        {
            saveAbility.range = float.Parse(rangeInput.text);
        }
        else
        {
            saveAbility.range = 0;
        }
    }

    public void OnPMChanged()
    {
        if (pmCostInput.text != "")
        {
            saveAbility.pmCost = int.Parse(pmCostInput.text);
        }
        else
        {
            saveAbility.pmCost = 0;
        }
    }

    public void OnDescriptionChanged()
    {
        saveAbility.description = descriptionInput.text;
    }
}

[Serializable]
public class SaveAbility
{
    public string abilityName;
    public int diceNumber;
    public int damages;
    public int bonusDamages;
    public float range;
    public int pmCost;
    public string description;

    public SaveAbility()
    {

    }
    
    public SaveAbility(SaveAbility toCopy)
    {
        abilityName = toCopy.abilityName;
        diceNumber = toCopy.diceNumber;
        damages = toCopy.damages;
        bonusDamages = toCopy.bonusDamages;
        range = toCopy.range;
        pmCost = toCopy.pmCost;
        description = toCopy.description;
    }
}
