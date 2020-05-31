using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterParametersController : MonoBehaviour
{
    public static CharacterParametersController instance;

    public GameObject characterStatsPanel;

    [HideInInspector]
    public Character activeCharacter;
    [HideInInspector]
    public List<Character> characters;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        List<SaveCharacter> saveCharacters = JsonSerializer.instance.GetCharacters();

        characters = new List<Character>();
        foreach (SaveCharacter saveCharacter in saveCharacters)
        {
            characters.Add(ButtonController.instance.AddCharacter(saveCharacter));
        }
        
        if (characters.Count != 0)
        {
            characters[0].Select();
            characters[0].OpenCharacter();
        }
    }

    [Header("General")]
    public InputField name;

    public InputField pv;
    public InputField pm;

    public Toggle pnj;

    public InputField gold;
    public InputField silver;
    public InputField copper;

    [Header("Physique")]
    public InputField forceBase;
    public InputField forceModifPerm;
    public InputField forceModifTemp;

    public InputField defenseBase;
    public InputField defenseModifPerm;
    public InputField defenseModifTemp;

    public InputField adresseBase;
    public InputField adresseModifPerm;
    public InputField adresseModifTemp;

    public InputField agiliteBase;
    public InputField agiliteModifPerm;
    public InputField agiliteModifTemp;

    public InputField vitesseBase;
    public InputField vitesseModifPerm;
    public InputField vitesseModifTemp;

    [Header("Social")]
    public InputField seductionBase;
    public InputField seductionModifPerm;
    public InputField seductionModifTemp;

    public InputField intimidationBase;
    public InputField intimidationModifPerm;
    public InputField intimidationModifTemp;

    public InputField rhetoriqueBase;
    public InputField rhetoriqueModifPerm;
    public InputField rhetoriqueModifTemp;

    public InputField premiereImpressionBase;
    public InputField premiereImpressionModifPerm;
    public InputField premiereImpressionModifTemp;

    public InputField dressageBase;
    public InputField dressageModifPerm;
    public InputField dressageModifTemp;

    [Header("Mental")]
    public InputField magieBase;
    public InputField magieModifPerm;
    public InputField magieModifTemp;

    public InputField eruditionBase;
    public InputField eruditionModifPerm;
    public InputField eruditionModifTemp;

    public InputField perceptionBase;
    public InputField perceptionModifPerm;
    public InputField perceptionModifTemp;

    public InputField resistanceMentaleBase;
    public InputField resistanceMentaleModifPerm;
    public InputField resistanceMentaleModifTemp;

    public InputField sangFroidBase;
    public InputField sangFroidModifPerm;
    public InputField sangFroidModifTemp;

    public void UnselectEveryCharacter()
    {
        foreach (Character character in characters)
        {
            character.Unselect();
        }
    }
}
