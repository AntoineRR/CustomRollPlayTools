using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public static ButtonController instance;

    public Button addCharacter;

    public Button addWeapon;
    public Button addAbility;
    public Button addItem;

    public GameObject character;
    public GameObject characterContainer;

    public GameObject weaponContainer;
    public GameObject weapon;

    public GameObject abilityContainer;
    public GameObject ability;

    public GameObject itemContainer;
    public GameObject item;

    private void Awake()
    {
        instance = this;
    }

    public void AddCharacter()
    {
        GameObject go = Instantiate(character, characterContainer.transform);
        Character instantiatedCharacter = go.GetComponentInChildren<Character>();
        instantiatedCharacter.Initialize();

        addCharacter.transform.parent.transform.SetAsLastSibling();

        CharacterParametersController.instance.characters.Add(instantiatedCharacter);
    }

    public Character AddCharacter(SaveCharacter c)
    {
        GameObject go = Instantiate(character, characterContainer.transform);
        Character instantiatedCharacter = go.GetComponentInChildren<Character>();
        instantiatedCharacter.Initialize(c);
        
        // Placing the add button as the last element
        addCharacter.transform.parent.transform.SetAsLastSibling();

        return instantiatedCharacter;
    }

    public void SaveCharacter()
    {
        JsonSerializer.instance.SaveCharacter();
    }

    public void AddWeapon()
    {
        GameObject go = Instantiate(weapon, weaponContainer.transform);
        go.transform.SetAsFirstSibling();

        Weapon instantiatedWepon = go.GetComponent<Weapon>();

        instantiatedWepon.saveWeapon = new SaveWeapon();

        CharacterParametersController.instance.activeCharacter.saveCharacter.weapons.Add(instantiatedWepon.saveWeapon);
    }

    public void OpenAndAddWeapon(SaveWeapon w)
    {
        GameObject go = Instantiate(weapon, weaponContainer.transform);
        
        Weapon instantiatedWepon = go.GetComponent<Weapon>();

        instantiatedWepon.nameInput.text = w.weaponName;
        instantiatedWepon.diceNumberInput.text = w.diceNumber.ToString();
        instantiatedWepon.damagesInput.text = w.damages.ToString();
        instantiatedWepon.bonusDamagesInput.text = w.bonusDamages.ToString();
        instantiatedWepon.rangeInput.text = w.range.ToString();

        instantiatedWepon.saveWeapon = w;
    }

    public void AddAbility()
    {
        GameObject go = Instantiate(ability, abilityContainer.transform);
        go.transform.SetAsFirstSibling();

        Ability instantiatedAbility = go.GetComponent<Ability>();

        instantiatedAbility.saveAbility = new SaveAbility();

        CharacterParametersController.instance.activeCharacter.saveCharacter.abilities.Add(instantiatedAbility.saveAbility);
    }

    public void OpenAndAddAbility(SaveAbility a)
    {
        GameObject go = Instantiate(ability, abilityContainer.transform);
        
        Ability instantiatedAbility = go.GetComponent<Ability>();

        instantiatedAbility.nameInput.text = a.abilityName;
        instantiatedAbility.diceNumberInput.text = a.diceNumber.ToString();
        instantiatedAbility.damagesInput.text = a.damages.ToString();
        instantiatedAbility.bonusDamagesInput.text = a.bonusDamages.ToString();
        instantiatedAbility.rangeInput.text = a.range.ToString();
        instantiatedAbility.pmCostInput.text = a.pmCost.ToString();
        instantiatedAbility.descriptionInput.text = a.description;

        instantiatedAbility.saveAbility = a;
    }

    public void AddItem()
    {
        GameObject go = Instantiate(item, itemContainer.transform);
        go.transform.SetAsFirstSibling();

        Item instantiatedItem = go.GetComponent<Item>();

        instantiatedItem.saveItem = new SaveItem();

        CharacterParametersController.instance.activeCharacter.saveCharacter.items.Add(instantiatedItem.saveItem);
    }

    public void OpenAndAddItem(SaveItem i)
    {
        GameObject go = Instantiate(item, itemContainer.transform);

        Item instantiatedItem = go.GetComponent<Item>();

        instantiatedItem.nameInput.text = i.itemName;
        instantiatedItem.quantityInput.text = i.quantity.ToString();
        instantiatedItem.descriptionInput.text = i.description;

        instantiatedItem.saveItem = i;
    }
}
