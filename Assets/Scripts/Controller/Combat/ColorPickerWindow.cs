using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerWindow : MonoBehaviour
{
    public static ColorPickerWindow instance;

    public Button target;
    public ColorPicker colorPicker;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        colorPicker = GetComponentInChildren<ColorPicker>();

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            ColorBlock colors = target.colors;
            colors.normalColor = colorPicker.CurrentColor;
            colors.highlightedColor = new Color(colorPicker.CurrentColor[0] + 0.05f, colorPicker.CurrentColor[1] + 0.05f, colorPicker.CurrentColor[2] + 0.05f);
            colors.pressedColor = new Color(colorPicker.CurrentColor[0] - 0.05f, colorPicker.CurrentColor[1] - 0.05f, colorPicker.CurrentColor[2] - 0.05f);
            colors.selectedColor = colorPicker.CurrentColor;
            target.colors = colors;

            CharacterParametersController.instance.characterStatsPanel.GetComponent<Image>().color =
                new Color(colorPicker.CurrentColor.r, colorPicker.CurrentColor.g, colorPicker.CurrentColor.b, 0.4f);

            CharacterParametersController.instance.activeCharacter.SetColor(colorPicker.CurrentColor);
        }
    }
}
