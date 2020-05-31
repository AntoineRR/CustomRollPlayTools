using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("Parameters")]
    public SaveItem saveItem;

    [Header("Inputfields")]
    public InputField nameInput;
    public InputField quantityInput;
    public InputField descriptionInput;

    public void Delete()
    {
        CharacterParametersController.instance.activeCharacter.saveCharacter.items.Remove(saveItem);
        Destroy(gameObject);
    }

    public void OnNameChanged()
    {
        saveItem.itemName = nameInput.text;
    }

    public void OnQuantityChanged()
    {
        if (quantityInput.text != "")
        {
            saveItem.quantity = int.Parse(quantityInput.text);
        }
        else
        {
            saveItem.quantity = 0;
        }
    }

    public void OnDescriptionChanged()
    {
        saveItem.description = descriptionInput.text;
    }
}

[Serializable]
public class SaveItem
{
    public string itemName;
    public int quantity;
    public string description;

    public SaveItem()
    {

    }

    public SaveItem(SaveItem toCopy)
    {
        itemName = toCopy.itemName;
        quantity = toCopy.quantity;
        description = toCopy.description;
    }
}
