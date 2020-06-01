using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSerializer : MonoBehaviour
{
    public static JsonSerializer instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveCharacter()
    {
        // ----- Modifying the character panel to update the name and max HP / MP

        CharacterParametersController.instance.activeCharacter.nameInput.text = CharacterParametersController.instance.name.text;

        // ----- Generating the SaveCharacter object we will save

        SaveCharacter toSave = new SaveCharacter(CharacterParametersController.instance.activeCharacter.saveCharacter);

        // Inputs from the character panel

        // Remaining HP
        if (CharacterParametersController.instance.activeCharacter.remainingHPInput.text != "")
        {
            toSave.remainingHP = int.Parse(CharacterParametersController.instance.activeCharacter.remainingHPInput.text);
        }
        else
        {
            toSave.remainingHP = 0;
        }

        // Remaining MP
        if (CharacterParametersController.instance.activeCharacter.remainingMPInput.text != "")
        {
            toSave.remainingMP = int.Parse(CharacterParametersController.instance.activeCharacter.remainingMPInput.text);
        }
        else
        {
            toSave.remainingMP = 0;
        }

        // State
        toSave.state = CharacterParametersController.instance.activeCharacter.stateInput.text;

        // Inputs from the right panel

        // Generating new stats objects to fill
        toSave.stats = new Stats();
        toSave.permanentStatsBonuses = new Stats();
        toSave.temporaryStatsBonuses = new Stats();

        // Character name
        toSave.characterName = CharacterParametersController.instance.name.text;

        // Max HP and MP
        toSave.maxHP = int.Parse(CharacterParametersController.instance.pv.text);
        toSave.maxMP = int.Parse(CharacterParametersController.instance.pm.text);

        // PNJ
        toSave.pnj = CharacterParametersController.instance.pnj.isOn;

        // Money
        if (CharacterParametersController.instance.gold.text != "")
        {
            toSave.gold = int.Parse(CharacterParametersController.instance.gold.text);
        }
        else
        {
            toSave.gold = 0;
        }

        if (CharacterParametersController.instance.silver.text != "")
        {
            toSave.silver = int.Parse(CharacterParametersController.instance.silver.text);
        }
        else
        {
            toSave.silver = 0;
        }

        if (CharacterParametersController.instance.copper.text != "")
        {
            toSave.copper = int.Parse(CharacterParametersController.instance.copper.text);
        }
        else
        {
            toSave.copper = 0;
        }

        // Physical stats
        toSave.stats.force = int.Parse(CharacterParametersController.instance.forceBase.text);
        toSave.stats.defense = int.Parse(CharacterParametersController.instance.defenseBase.text);
        toSave.stats.adresse = int.Parse(CharacterParametersController.instance.adresseBase.text);
        toSave.stats.agilite = int.Parse(CharacterParametersController.instance.agiliteBase.text);
        toSave.stats.vitesse = int.Parse(CharacterParametersController.instance.vitesseBase.text);

        // Social stats
        toSave.stats.seduction = int.Parse(CharacterParametersController.instance.seductionBase.text);
        toSave.stats.intimidation = int.Parse(CharacterParametersController.instance.intimidationBase.text);
        toSave.stats.rhetorique = int.Parse(CharacterParametersController.instance.rhetoriqueBase.text);
        toSave.stats.premiereImpression = int.Parse(CharacterParametersController.instance.premiereImpressionBase.text);
        toSave.stats.dressage = int.Parse(CharacterParametersController.instance.dressageBase.text);

        // Mental stats
        toSave.stats.magie = int.Parse(CharacterParametersController.instance.magieBase.text);
        toSave.stats.erudition = int.Parse(CharacterParametersController.instance.eruditionBase.text);
        toSave.stats.perception = int.Parse(CharacterParametersController.instance.perceptionBase.text);
        toSave.stats.resistanceMentale = int.Parse(CharacterParametersController.instance.resistanceMentaleBase.text);
        toSave.stats.sangFroid = int.Parse(CharacterParametersController.instance.sangFroidBase.text);

        // Permanent modifications on Physical stats

        if (CharacterParametersController.instance.forceModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.force = int.Parse(CharacterParametersController.instance.forceModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.force = 0;
        }

        if (CharacterParametersController.instance.defenseModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.defense = int.Parse(CharacterParametersController.instance.defenseModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.defense = 0;
        }

        if (CharacterParametersController.instance.adresseModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.adresse = int.Parse(CharacterParametersController.instance.adresseModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.adresse = 0;
        }

        if (CharacterParametersController.instance.agiliteModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.agilite = int.Parse(CharacterParametersController.instance.agiliteModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.agilite = 0;
        }

        if (CharacterParametersController.instance.vitesseModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.vitesse = int.Parse(CharacterParametersController.instance.vitesseModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.vitesse = 0;
        }

        // Permanent modifications on Social stats

        if (CharacterParametersController.instance.seductionModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.seduction = int.Parse(CharacterParametersController.instance.seductionModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.seduction = 0;
        }

        if (CharacterParametersController.instance.intimidationModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.intimidation = int.Parse(CharacterParametersController.instance.intimidationModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.intimidation = 0;
        }

        if (CharacterParametersController.instance.rhetoriqueModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.rhetorique = int.Parse(CharacterParametersController.instance.rhetoriqueModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.rhetorique = 0;
        }

        if (CharacterParametersController.instance.premiereImpressionModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.premiereImpression = int.Parse(CharacterParametersController.instance.premiereImpressionModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.premiereImpression = 0;
        }

        if (CharacterParametersController.instance.dressageModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.dressage = int.Parse(CharacterParametersController.instance.dressageModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.dressage = 0;
        }

        // Permanent modifications on Mental stats

        if (CharacterParametersController.instance.magieModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.magie = int.Parse(CharacterParametersController.instance.magieModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.magie = 0;
        }

        if (CharacterParametersController.instance.eruditionModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.erudition = int.Parse(CharacterParametersController.instance.eruditionModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.erudition = 0;
        }

        if (CharacterParametersController.instance.perceptionModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.perception = int.Parse(CharacterParametersController.instance.perceptionModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.perception = 0;
        }

        if (CharacterParametersController.instance.resistanceMentaleModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.resistanceMentale = int.Parse(CharacterParametersController.instance.resistanceMentaleModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.resistanceMentale = 0;
        }

        if (CharacterParametersController.instance.sangFroidModifPerm.text != "")
        {
            toSave.permanentStatsBonuses.sangFroid = int.Parse(CharacterParametersController.instance.sangFroidModifPerm.text);
        }
        else
        {
            toSave.permanentStatsBonuses.sangFroid = 0;
        }


        // Temporary modifications on Physical stats

        if (CharacterParametersController.instance.forceModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.force = int.Parse(CharacterParametersController.instance.forceModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.force = 0;
        }

        if (CharacterParametersController.instance.defenseModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.defense = int.Parse(CharacterParametersController.instance.defenseModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.defense = 0;
        }

        if (CharacterParametersController.instance.adresseModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.adresse = int.Parse(CharacterParametersController.instance.adresseModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.adresse = 0;
        }

        if (CharacterParametersController.instance.agiliteModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.agilite = int.Parse(CharacterParametersController.instance.agiliteModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.agilite = 0;
        }

        if (CharacterParametersController.instance.vitesseModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.vitesse = int.Parse(CharacterParametersController.instance.vitesseModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.vitesse = 0;
        }

        // Temporary modifications on Social stats

        if (CharacterParametersController.instance.seductionModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.seduction = int.Parse(CharacterParametersController.instance.seductionModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.seduction = 0;
        }

        if (CharacterParametersController.instance.intimidationModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.intimidation = int.Parse(CharacterParametersController.instance.intimidationModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.intimidation = 0;
        }

        if (CharacterParametersController.instance.rhetoriqueModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.rhetorique = int.Parse(CharacterParametersController.instance.rhetoriqueModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.rhetorique = 0;
        }

        if (CharacterParametersController.instance.premiereImpressionModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.premiereImpression = int.Parse(CharacterParametersController.instance.premiereImpressionModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.premiereImpression = 0;
        }

        if (CharacterParametersController.instance.dressageModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.dressage = int.Parse(CharacterParametersController.instance.dressageModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.dressage = 0;
        }

        // Temporary modifications on Mental stats

        if (CharacterParametersController.instance.magieModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.magie = int.Parse(CharacterParametersController.instance.magieModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.magie = 0;
        }

        if (CharacterParametersController.instance.eruditionModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.erudition = int.Parse(CharacterParametersController.instance.eruditionModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.erudition = 0;
        }

        if (CharacterParametersController.instance.perceptionModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.perception = int.Parse(CharacterParametersController.instance.perceptionModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.perception = 0;
        }

        if (CharacterParametersController.instance.resistanceMentaleModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.resistanceMentale = int.Parse(CharacterParametersController.instance.resistanceMentaleModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.resistanceMentale = 0;
        }

        if (CharacterParametersController.instance.sangFroidModifTemp.text != "")
        {
            toSave.temporaryStatsBonuses.sangFroid = int.Parse(CharacterParametersController.instance.sangFroidModifTemp.text);
        }
        else
        {
            toSave.temporaryStatsBonuses.sangFroid = 0;
        }

        // Weapons

        toSave.weapons = new List<SaveWeapon>();
        foreach (SaveWeapon weapon in CharacterParametersController.instance.activeCharacter.saveCharacter.weapons)
        {
            toSave.weapons.Add(new SaveWeapon(weapon));
        }

        // Abilities

        toSave.abilities = new List<SaveAbility>();
        foreach (SaveAbility ability in CharacterParametersController.instance.activeCharacter.saveCharacter.abilities)
        {
            toSave.abilities.Add(new SaveAbility(ability));
        }

        // Items
        toSave.items = new List<SaveItem>();
        foreach (SaveItem item in CharacterParametersController.instance.activeCharacter.saveCharacter.items)
        {
            toSave.items.Add(new SaveItem(item));
        }

        // ----- Adding the new stats to the character

        CharacterParametersController.instance.activeCharacter.saveCharacter = new SaveCharacter(toSave);

        // ----- Saving the character

        string path = "Assets/Ressources/Characters/" + toSave.characterName + ".json";
        string json = JsonUtility.ToJson(toSave, true);
        StreamWriter streamWriter = new StreamWriter(path);
        streamWriter.WriteLine(json);
        streamWriter.Close();
    }

    public void QuickSaveCharacter(SaveCharacter toSave)
    {
        string path = "Assets/Ressources/Characters/" + toSave.characterName + ".json";
        string json = JsonUtility.ToJson(toSave, true);
        StreamWriter streamWriter = new StreamWriter(path);
        streamWriter.WriteLine(json);
        streamWriter.Close();
    }

    public List<SaveCharacter> GetCharacters()
    {
        string path = "Assets/Ressources/Characters";
        DirectoryInfo infos = new DirectoryInfo(path);

        List<SaveCharacter> saveCharacters = new List<SaveCharacter>();
        foreach (FileInfo fileInfo in infos.GetFiles())
        {
            if (!fileInfo.FullName.Contains(".meta"))
            {
                StreamReader streamReader = new StreamReader(fileInfo.FullName);
                string json = streamReader.ReadToEnd();

                SaveCharacter saveCharacter = JsonUtility.FromJson<SaveCharacter>(json);

                saveCharacters.Add(saveCharacter);
            }
        }
        return saveCharacters;
    }
}
