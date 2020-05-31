using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [Header("Parameters")]
    public SaveCharacter saveCharacter;

    [Header("Inputs")]
    public Text nameInput;
    public InputField stateInput;
    public InputField remainingHPInput;
    public InputField remainingMPInput;
    public Text maxHPInput;
    public Text maxMPInput;

    void Start()
    {
        // Saving a grey color if the character was just created
        if (saveCharacter.color.Count == 0)
        {
            saveCharacter.color = new List<int>();
            saveCharacter.color.Add(150);
            saveCharacter.color.Add(150);
            saveCharacter.color.Add(150);
        }

        // Changing UI color depending on the color associated with the character
        Button characterButton = GetComponentInChildren<Button>();
        ColorBlock buttonColors = characterButton.colors;

        List<float> floatColor = new List<float>();
        floatColor.Add((float)saveCharacter.color[0] / 255);
        floatColor.Add((float)saveCharacter.color[1] / 255);
        floatColor.Add((float)saveCharacter.color[2] / 255);

        buttonColors.normalColor = new Color(floatColor[0], floatColor[1], floatColor[2]);
        buttonColors.highlightedColor = new Color(floatColor[0] + 0.05f, floatColor[1] + 0.05f, floatColor[2] + 0.05f);
        buttonColors.pressedColor = new Color(floatColor[0] - 0.05f, floatColor[1] - 0.05f, floatColor[2] - 0.05f);
        characterButton.colors = buttonColors;
    }

    public void OpenCharacter()
    {
        if (saveCharacter.color.Count != 0)
        {
            List<float> floatColor = new List<float>();
            floatColor.Add((float)saveCharacter.color[0] / 255);
            floatColor.Add((float)saveCharacter.color[1] / 255);
            floatColor.Add((float)saveCharacter.color[2] / 255);

            CharacterParametersController.instance.characterStatsPanel.GetComponent<Image>().color = new Color(floatColor[0], floatColor[1], floatColor[2], 0.4f);
        }

        CharacterParametersController.instance.activeCharacter = this;

        CharacterParametersController.instance.name.text = saveCharacter.characterName;

        CharacterParametersController.instance.pv.text = saveCharacter.maxHP.ToString();
        CharacterParametersController.instance.pm.text = saveCharacter.maxMP.ToString();

        CharacterParametersController.instance.pnj.isOn = saveCharacter.pnj;

        CharacterParametersController.instance.gold.text = saveCharacter.gold.ToString();
        CharacterParametersController.instance.silver.text = saveCharacter.silver.ToString();
        CharacterParametersController.instance.copper.text = saveCharacter.copper.ToString();

        // Base stats

        CharacterParametersController.instance.forceBase.text = saveCharacter.stats.force.ToString();
        CharacterParametersController.instance.defenseBase.text = saveCharacter.stats.defense.ToString();
        CharacterParametersController.instance.adresseBase.text = saveCharacter.stats.adresse.ToString();
        CharacterParametersController.instance.agiliteBase.text = saveCharacter.stats.agilite.ToString();
        CharacterParametersController.instance.vitesseBase.text = saveCharacter.stats.vitesse.ToString();

        CharacterParametersController.instance.seductionBase.text = saveCharacter.stats.seduction.ToString();
        CharacterParametersController.instance.intimidationBase.text = saveCharacter.stats.intimidation.ToString();
        CharacterParametersController.instance.rhetoriqueBase.text = saveCharacter.stats.rhetorique.ToString();
        CharacterParametersController.instance.premiereImpressionBase.text = saveCharacter.stats.premiereImpression.ToString();
        CharacterParametersController.instance.dressageBase.text = saveCharacter.stats.dressage.ToString();

        CharacterParametersController.instance.magieBase.text = saveCharacter.stats.magie.ToString();
        CharacterParametersController.instance.eruditionBase.text = saveCharacter.stats.erudition.ToString();
        CharacterParametersController.instance.perceptionBase.text = saveCharacter.stats.perception.ToString();
        CharacterParametersController.instance.resistanceMentaleBase.text = saveCharacter.stats.resistanceMentale.ToString();
        CharacterParametersController.instance.sangFroidBase.text = saveCharacter.stats.sangFroid.ToString();

        // Permanent additionnal stats

        CharacterParametersController.instance.forceModifPerm.text = saveCharacter.permanentStatsBonuses.force.ToString();
        CharacterParametersController.instance.defenseModifPerm.text = saveCharacter.permanentStatsBonuses.defense.ToString();
        CharacterParametersController.instance.adresseModifPerm.text = saveCharacter.permanentStatsBonuses.adresse.ToString();
        CharacterParametersController.instance.agiliteModifPerm.text = saveCharacter.permanentStatsBonuses.agilite.ToString();
        CharacterParametersController.instance.vitesseModifPerm.text = saveCharacter.permanentStatsBonuses.vitesse.ToString();

        CharacterParametersController.instance.seductionModifPerm.text = saveCharacter.permanentStatsBonuses.seduction.ToString();
        CharacterParametersController.instance.intimidationModifPerm.text = saveCharacter.permanentStatsBonuses.intimidation.ToString();
        CharacterParametersController.instance.rhetoriqueModifPerm.text = saveCharacter.permanentStatsBonuses.rhetorique.ToString();
        CharacterParametersController.instance.premiereImpressionModifPerm.text = saveCharacter.permanentStatsBonuses.premiereImpression.ToString();
        CharacterParametersController.instance.dressageModifPerm.text = saveCharacter.permanentStatsBonuses.dressage.ToString();

        CharacterParametersController.instance.magieModifPerm.text = saveCharacter.permanentStatsBonuses.magie.ToString();
        CharacterParametersController.instance.eruditionModifPerm.text = saveCharacter.permanentStatsBonuses.erudition.ToString();
        CharacterParametersController.instance.perceptionModifPerm.text = saveCharacter.permanentStatsBonuses.perception.ToString();
        CharacterParametersController.instance.resistanceMentaleModifPerm.text = saveCharacter.permanentStatsBonuses.resistanceMentale.ToString();
        CharacterParametersController.instance.sangFroidModifPerm.text = saveCharacter.permanentStatsBonuses.sangFroid.ToString();

        // Temporary additionnal stats

        CharacterParametersController.instance.forceModifTemp.text = saveCharacter.temporaryStatsBonuses.force.ToString();
        CharacterParametersController.instance.defenseModifTemp.text = saveCharacter.temporaryStatsBonuses.defense.ToString();
        CharacterParametersController.instance.adresseModifTemp.text = saveCharacter.temporaryStatsBonuses.adresse.ToString();
        CharacterParametersController.instance.agiliteModifTemp.text = saveCharacter.temporaryStatsBonuses.agilite.ToString();
        CharacterParametersController.instance.vitesseModifTemp.text = saveCharacter.temporaryStatsBonuses.vitesse.ToString();

        CharacterParametersController.instance.seductionModifTemp.text = saveCharacter.temporaryStatsBonuses.seduction.ToString();
        CharacterParametersController.instance.intimidationModifTemp.text = saveCharacter.temporaryStatsBonuses.intimidation.ToString();
        CharacterParametersController.instance.rhetoriqueModifTemp.text = saveCharacter.temporaryStatsBonuses.rhetorique.ToString();
        CharacterParametersController.instance.premiereImpressionModifTemp.text = saveCharacter.temporaryStatsBonuses.premiereImpression.ToString();
        CharacterParametersController.instance.dressageModifTemp.text = saveCharacter.temporaryStatsBonuses.dressage.ToString();

        CharacterParametersController.instance.magieModifTemp.text = saveCharacter.temporaryStatsBonuses.magie.ToString();
        CharacterParametersController.instance.eruditionModifTemp.text = saveCharacter.temporaryStatsBonuses.erudition.ToString();
        CharacterParametersController.instance.perceptionModifTemp.text = saveCharacter.temporaryStatsBonuses.perception.ToString();
        CharacterParametersController.instance.resistanceMentaleModifTemp.text = saveCharacter.temporaryStatsBonuses.resistanceMentale.ToString();
        CharacterParametersController.instance.sangFroidModifTemp.text = saveCharacter.temporaryStatsBonuses.sangFroid.ToString();

        // Weapons

        // Destroying the weapons that were previously in the container
        foreach (Weapon w in ButtonController.instance.weaponContainer.GetComponentsInChildren<Weapon>())
        {
            Destroy(w.gameObject);
        }
        
        // Adding the character's weapons
        foreach (SaveWeapon saveWeapon in saveCharacter.weapons)
        {
            ButtonController.instance.OpenAndAddWeapon(saveWeapon);
        }

        // Abilities

        // Destroying the abilities that were previously in the container
        foreach (Ability a in ButtonController.instance.abilityContainer.GetComponentsInChildren<Ability>())
        {
            Destroy(a.gameObject);
        }
        
        foreach (SaveAbility saveAbility in saveCharacter.abilities)
        {
            ButtonController.instance.OpenAndAddAbility(saveAbility);
        }

        // Items

        // Destroying the items that were previously in the container
        foreach (Item i in ButtonController.instance.itemContainer.GetComponentsInChildren<Item>())
        {
            Destroy(i.gameObject);
        }

        foreach (SaveItem saveItem in saveCharacter.items)
        {
            ButtonController.instance.OpenAndAddItem(saveItem);
        }
    }

    public void OnRemainingHPChanged()
    {
        if (remainingHPInput.text != "")
        {
            saveCharacter.remainingHP = int.Parse(remainingHPInput.text);
        }
        else
        {
            saveCharacter.remainingHP = 0;
        }
    }

    public void OnRemainingMPChanged()
    {
        if (remainingMPInput.text != "")
        {
            saveCharacter.remainingMP = int.Parse(remainingMPInput.text);
        }
        else
        {
            saveCharacter.remainingMP = 0;
        }
    }

    public void OnIdChanged()
    {
        saveCharacter.state = stateInput.text;
    }
}

[Serializable]
public class SaveCharacter
{
    public string characterName;

    public bool pnj;

    public string state;

    public int remainingHP;
    public int remainingMP;

    public int maxHP;
    public int maxMP;

    public int gold;
    public int silver;
    public int copper;

    public List<int> color;

    public Stats stats;
    public Stats permanentStatsBonuses;
    public Stats temporaryStatsBonuses;

    public List<SaveWeapon> weapons;
    public List<SaveAbility> abilities;
    public List<SaveItem> items;

    public SaveCharacter()
    {

    } 

    public SaveCharacter(SaveCharacter toCopy)
    {
        characterName = toCopy.characterName;

        state = toCopy.state;

        remainingHP = toCopy.remainingHP;
        remainingMP = toCopy.remainingMP;

        maxHP = toCopy.maxHP;
        maxMP = toCopy.maxMP;

        pnj = toCopy.pnj;

        gold = toCopy.gold;
        silver = toCopy.silver;
        copper = toCopy.copper;

        color = new List<int>(toCopy.color);

        stats = new Stats(toCopy.stats);
        permanentStatsBonuses = new Stats(toCopy.permanentStatsBonuses);
        temporaryStatsBonuses = new Stats(toCopy.temporaryStatsBonuses);

        weapons = new List<SaveWeapon>();
        foreach (SaveWeapon saveWeapon in toCopy.weapons)
        {
            weapons.Add(new SaveWeapon(saveWeapon));
        }

        abilities = new List<SaveAbility>();
        foreach (SaveAbility saveAbility in toCopy.abilities)
        {
            abilities.Add(new SaveAbility(saveAbility));
        }

        items = new List<SaveItem>();
        foreach (SaveItem saveItem in toCopy.items)
        {
            items.Add(new SaveItem(saveItem));
        }
    }
}
