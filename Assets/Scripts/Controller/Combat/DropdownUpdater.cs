using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

public class DropdownUpdater : MonoBehaviour
{
    public static DropdownUpdater instance;

    [Header("Fight")]
    public Dropdown defenseurDropdown;

    public Dropdown weaponDropdown;
    public Dropdown abilityDropdown;

    public Text weaponDamages;
    public Text abilityDamages;

    public Dropdown weaponStat1Dropdown;
    public Dropdown weaponStat2Dropdown;

    public Text weaponStat1Text;
    public Text weaponStat2Text;

    public Dropdown abilityStat1Dropdown;
    public Dropdown abilityStat2Dropdown;

    public Text abilityStat1Text;
    public Text abilityStat2Text;

    public InputField bonusInput;

    public Dropdown defenseurAction;
    public InputField defenseurBonus;

    public Text defenseurStatText;

    public Button attackWithWeapon;
    public Button attackWithAbility;

    [Header("Dice Roller")]
    public Dropdown statDropdown;
    public Text statText;
    public InputField bonusStatInput;

    public InputField diceInput;
    public InputField bonusDiceInput;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FillCharacterDropdowns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillCharacterDropdowns()
    {
        List<OptionData> options = new List<OptionData>();
        foreach (Character character in CharacterParametersController.instance.characters)
        {
            OptionData option = new OptionData(character.saveCharacter.characterName);
            options.Add(option);
        }

        defenseurDropdown.ClearOptions();
        defenseurDropdown.AddOptions(options);
        UpdateDefenseur();
    }

    public void FillWeaponsAndAbilities()
    {
        List<OptionData> options = new List<OptionData>();
        foreach (SaveWeapon saveWeapon in FightController.instance.attaquant.weapons)
        {
            OptionData option = new OptionData(saveWeapon.weaponName);
            options.Add(option);
        }

        weaponDropdown.ClearOptions();
        weaponDropdown.AddOptions(options);
        UpdateWeapon();

        options = new List<OptionData>();
        foreach (SaveAbility saveAbility in FightController.instance.attaquant.abilities)
        {
            OptionData option = new OptionData(saveAbility.abilityName);
            options.Add(option);
        }

        abilityDropdown.ClearOptions();
        abilityDropdown.AddOptions(options);
        UpdateAbility();
    }

    public void UpdateAttaquant()
    {
        FillWeaponsAndAbilities();
        UpdateWeaponStat1();
        UpdateWeaponStat2();
        UpdateAbilityStat1();
        UpdateAbilityStat2();
        UpdateStat();
    }

    public void UpdateDefenseur()
    {
        FightController.instance.defenseur = CharacterParametersController.instance.characters[defenseurDropdown.value].saveCharacter;

        UpdateActionStat();
        UpdateBonusActionStat();
    }

    public void UpdateWeapon()
    {
        if (FightController.instance.attaquant.weapons.Count != 0)
        {
            attackWithWeapon.interactable = true;

            SaveWeapon w = FightController.instance.attaquant.weapons[weaponDropdown.value];
            FightController.instance.weapon = w;

            weaponDamages.text = w.diceNumber.ToString() + "D" + w.damages.ToString() + " + " + w.bonusDamages.ToString();
        }
        else
        {
            attackWithWeapon.interactable = false;
            FightController.instance.weapon = null;
            weaponDamages.text = "0";
        }
    }

    public void UpdateAbility()
    {
        if (FightController.instance.attaquant.abilities.Count != 0)
        {
            attackWithAbility.interactable = true;

            SaveAbility a = FightController.instance.attaquant.abilities[abilityDropdown.value];
            FightController.instance.ability = a;

            abilityDamages.text = a.diceNumber.ToString() + "D" + a.damages.ToString() + " + " + a.bonusDamages.ToString();
        }
        else
        {
            attackWithAbility.interactable = false;
            FightController.instance.ability = null;
            abilityDamages.text = "0";
        }
    }

    public void UpdateWeaponStat1()
    {
        string name = weaponStat1Dropdown.GetComponentInChildren<Text>().text;
        FightController.instance.weaponStat1 = GetStat(name, FightController.instance.attaquant);

        weaponStat1Text.text = FightController.instance.weaponStat1.ToString();
    }

    public void UpdateWeaponStat2()
    {
        string name = weaponStat2Dropdown.GetComponentInChildren<Text>().text;
        FightController.instance.weaponStat2 = GetStat(name, FightController.instance.attaquant);

        weaponStat2Text.text = FightController.instance.weaponStat2.ToString();
    }

    public void UpdateAbilityStat1()
    {
        string name = abilityStat1Dropdown.GetComponentInChildren<Text>().text;
        FightController.instance.abilityStat1 = GetStat(name, FightController.instance.attaquant);

        abilityStat1Text.text = FightController.instance.abilityStat1.ToString();
    }

    public void UpdateAbilityStat2()
    {
        string name = abilityStat2Dropdown.GetComponentInChildren<Text>().text;
        FightController.instance.abilityStat2 = GetStat(name, FightController.instance.attaquant);

        abilityStat2Text.text = FightController.instance.abilityStat2.ToString();
    }

    public void UpdateStat()
    {
        string name = statDropdown.GetComponentInChildren<Text>().text;

        statText.text = GetStat(name, FightController.instance.attaquant).ToString();
    }

    public void UpdateActionStat()
    {
        int stat;
        int statBrute;
        if (defenseurAction.GetComponentInChildren<Text>().text == "Parer")
        {
            statBrute = GetStat("Adresse", FightController.instance.defenseur);
            if (defenseurBonus.text == "")
            {
                stat = statBrute;
            }
            else
            {
                stat = statBrute + int.Parse(defenseurBonus.text);
            }
        }
        else if (defenseurAction.GetComponentInChildren<Text>().text == "Esquiver")
        {
            statBrute = GetStat("Agilité", FightController.instance.defenseur);
            if (defenseurBonus.text == "")
            {
                stat = statBrute;
            }
            else
            {
                stat = statBrute + int.Parse(defenseurBonus.text);
            }
        }
        else
        {
            statBrute = 0;
            if (defenseurBonus.text == "")
            {
                stat = statBrute;
            }
            else
            {
                stat = statBrute + int.Parse(defenseurBonus.text);
            }
        }

        FightController.instance.defenseurStat = stat;
        defenseurStatText.text = statBrute.ToString();
    }

    public void UpdateBonusActionStat()
    {
        if (defenseurBonus.text != "")
        {
            if (defenseurAction.GetComponentInChildren<Text>().text == "Parer")
            {
                FightController.instance.defenseurStat = GetStat("Adresse", FightController.instance.defenseur) + int.Parse(defenseurBonus.text);
            }
            else if (defenseurAction.GetComponentInChildren<Text>().text == "Esquiver")
            {
                FightController.instance.defenseurStat = GetStat("Agilité", FightController.instance.defenseur) + int.Parse(defenseurBonus.text);
            }
            else
            {
                FightController.instance.defenseurStat = 0;
            }
        }
        else
        {
            if (defenseurAction.GetComponentInChildren<Text>().text == "Parer")
            {
                FightController.instance.defenseurStat = GetStat("Adresse", FightController.instance.defenseur);
            }
            else if (defenseurAction.GetComponentInChildren<Text>().text == "Esquiver")
            {
                FightController.instance.defenseurStat = GetStat("Agilité", FightController.instance.defenseur);
            }
            else
            {
                FightController.instance.defenseurStat = 0;
            }
        }
    }

    public int GetStat(string stat, SaveCharacter saveCharacter)
    {
        if (stat == "Force")
        {
            return saveCharacter.stats.force + saveCharacter.permanentStatsBonuses.force + saveCharacter.temporaryStatsBonuses.force;
        }
        else if (stat == "Défense")
        {
            return saveCharacter.stats.defense + saveCharacter.permanentStatsBonuses.defense + saveCharacter.temporaryStatsBonuses.defense;
        }
        else if (stat == "Adresse")
        {
            return saveCharacter.stats.adresse + saveCharacter.permanentStatsBonuses.adresse + saveCharacter.temporaryStatsBonuses.adresse;
        }
        else if (stat == "Agilité")
        {
            return saveCharacter.stats.agilite + saveCharacter.permanentStatsBonuses.agilite + saveCharacter.temporaryStatsBonuses.agilite;
        }
        else if (stat == "Vitesse")
        {
            return saveCharacter.stats.vitesse + saveCharacter.permanentStatsBonuses.vitesse + saveCharacter.temporaryStatsBonuses.vitesse;
        }

        else if (stat == "Séduction")
        {
            return saveCharacter.stats.seduction + saveCharacter.permanentStatsBonuses.seduction + saveCharacter.temporaryStatsBonuses.seduction;
        }
        else if (stat == "Intimidation")
        {
            return saveCharacter.stats.intimidation + saveCharacter.permanentStatsBonuses.intimidation + saveCharacter.temporaryStatsBonuses.intimidation;
        }
        else if (stat == "Rhétorique")
        {
            return saveCharacter.stats.rhetorique + saveCharacter.permanentStatsBonuses.rhetorique + saveCharacter.temporaryStatsBonuses.rhetorique;
        }
        else if (stat == "Première Impression")
        {
            return saveCharacter.stats.premiereImpression + saveCharacter.permanentStatsBonuses.premiereImpression + saveCharacter.temporaryStatsBonuses.premiereImpression;
        }
        else if (stat == "Dressage")
        {
            return saveCharacter.stats.dressage + saveCharacter.permanentStatsBonuses.dressage + saveCharacter.temporaryStatsBonuses.dressage;
        }

        else if (stat == "Magie")
        {
            return saveCharacter.stats.magie + saveCharacter.permanentStatsBonuses.magie + saveCharacter.temporaryStatsBonuses.magie;
        }
        else if (stat == "Erudition")
        {
            return saveCharacter.stats.erudition + saveCharacter.permanentStatsBonuses.erudition + saveCharacter.temporaryStatsBonuses.erudition;
        }
        else if (stat == "Perception")
        {
            return saveCharacter.stats.perception + saveCharacter.permanentStatsBonuses.perception + saveCharacter.temporaryStatsBonuses.perception;
        }
        else if (stat == "Résistance Mentale")
        {
            return saveCharacter.stats.resistanceMentale + saveCharacter.permanentStatsBonuses.resistanceMentale + saveCharacter.temporaryStatsBonuses.resistanceMentale;
        }
        else if (stat == "Sang Froid")
        {
            return saveCharacter.stats.sangFroid + saveCharacter.permanentStatsBonuses.sangFroid + saveCharacter.temporaryStatsBonuses.sangFroid;
        }

        else
        {
            return 0;
        }
    }
}
