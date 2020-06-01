using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public static TabGroup instance;

    public List<TabButton> tabButtons;
    public List<GameObject> objectsToSwap;

    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;

    public TabButton selectedTab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //TabButton toSelect = tabButtons.Find(elt => elt.gameObject.GetComponentInChildren<Text>().text == "Statistiques" || );
        //OnTabSelected(toSelect);
        OnTabSelected(tabButtons[0]);
    }

    public void OnTabEnter(TabButton button)
    {
        if (selectedTab != button)
        {
            button.background.color = tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        if (selectedTab != button)
        {
            button.background.color = tabIdle;
        }
    }

    public void OnTabSelected(TabButton button)
    {
        _ResetTabs();
        button.background.color = tabActive;
        selectedTab = button;
        foreach (GameObject go in objectsToSwap)
        {
            if (go == button.toActivate)
            {
                button.toActivate.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }

        //if (button.GetComponentInChildren<Text>().text == "Combat")
        //{
        //    DropdownUpdater.instance.FillCharacterDropdowns();
        //}
    }

    private void _ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            button.background.color = tabIdle;
        }
    }
}
