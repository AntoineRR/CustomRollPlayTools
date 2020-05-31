using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightController : MonoBehaviour
{
    public static FightController instance;

    public SaveCharacter attaquant;
    public SaveCharacter defenseur;

    public SaveWeapon weapon;
    public SaveAbility ability;

    public int weaponStat1;
    public int weaponStat2;

    public int abilityStat1;
    public int abilityStat2;

    public int defenseurStat;

    public int attackNumber;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        attackNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackWithWeapon()
    {
        StartCoroutine(ShowAttackWithWeaponLogs());
    }

    public IEnumerator ShowAttackWithWeaponLogs()
    {
        // Creating each character color string in hex

        List<float> floatColor = new List<float>();
        floatColor.Add((float)attaquant.color[0] / 255);
        floatColor.Add((float)attaquant.color[1] / 255);
        floatColor.Add((float)attaquant.color[2] / 255);

        string attaquantColor = ColorUtility.ToHtmlStringRGB(new Color(floatColor[0], floatColor[1], floatColor[2]));

        floatColor = new List<float>();
        floatColor.Add((float)defenseur.color[0] / 255);
        floatColor.Add((float)defenseur.color[1] / 255);
        floatColor.Add((float)defenseur.color[2] / 255);

        string defenseurColor = ColorUtility.ToHtmlStringRGB(new Color(floatColor[0], floatColor[1], floatColor[2]));

        // Used variables

        Dictionary<string, string> dictionaryLog;

        // Lancer de stat 1

        int attackValue1;
        if (attaquant.pnj)
        {
            attackValue1 = RollDice(100);
        }
        else
        {
            dictionaryLog = CreateLogDictionary(attaquant.characterName, DropdownUpdater.instance.weaponStat1Dropdown.GetComponentInChildren<Text>().text,
                "", "/ " + weaponStat1.ToString());
            InputLog inputLog = LogController.instance.AddAttaquantInputLog(dictionaryLog);

            yield return new WaitUntil(() => inputLog.completed);

            attackValue1 = int.Parse(inputLog.roll.text);

            Destroy(inputLog.gameObject);
        }

        dictionaryLog = CreateLogDictionary(attaquant.characterName, DropdownUpdater.instance.weaponStat1Dropdown.GetComponentInChildren<Text>().text,
            attackValue1.ToString(), "/ " + weaponStat1.ToString());

        bool success = true;

        if (attackValue1 <= weaponStat1 && attackValue1 > 5)
        {
            LogController.instance.AddAttaquantWinLog(dictionaryLog);
        }
        else if (attackValue1 <= weaponStat1 && attackValue1 <= 5)
        {
            LogController.instance.AddAttaquantCriticalWinLog(dictionaryLog);
        }
        else if (attackValue1 > weaponStat1 && attackValue1 <= 95)
        {
            LogController.instance.AddAttaquantFailLog(dictionaryLog);
            success = false;
        }
        else if (attackValue1 > weaponStat1 && attackValue1 > 95)
        {
            LogController.instance.AddAttaquantCriticalFailLog(dictionaryLog);
            success = false;
        }

        // Lancer de stat 2

        bool secondRoll = false;
        int attackValue2 = 0;
        if (DropdownUpdater.instance.weaponStat2Dropdown.GetComponentInChildren<Text>().text != "-")
        {
            secondRoll = true;

            if (attaquant.pnj)
            {
                attackValue2 = RollDice(100);
            }
            else
            {
                dictionaryLog = CreateLogDictionary(attaquant.characterName, DropdownUpdater.instance.weaponStat2Dropdown.GetComponentInChildren<Text>().text,
                    "", "/ " + weaponStat2.ToString());
                InputLog inputLog = LogController.instance.AddAttaquantInputLog(dictionaryLog);

                yield return new WaitUntil(() => inputLog.completed);

                attackValue2 = int.Parse(inputLog.roll.text);

                Destroy(inputLog.gameObject);
            }

            dictionaryLog = CreateLogDictionary(attaquant.characterName, DropdownUpdater.instance.weaponStat2Dropdown.GetComponentInChildren<Text>().text,
                attackValue2.ToString(), "/ " + weaponStat2.ToString());

            if (attackValue2 <= weaponStat2 && attackValue2 > 5)
            {
                LogController.instance.AddAttaquantWinLog(dictionaryLog);
            }
            else if (attackValue2 <= weaponStat2 && attackValue2 <= 5)
            {
                LogController.instance.AddAttaquantCriticalWinLog(dictionaryLog);
            }
            else if (attackValue2 > weaponStat2 && attackValue2 <= 95)
            {
                LogController.instance.AddAttaquantFailLog(dictionaryLog);
                success = false;
            }
            else if (attackValue2 > weaponStat2 && attackValue2 > 95)
            {
                LogController.instance.AddAttaquantCriticalFailLog(dictionaryLog);
                success = false;
            }
        }

        if (!success)
        {
            string logTemp = "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>" + " échoue à attaquer "
                + "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>";
            LogController.instance.AddResultLog(logTemp);

            StartCoroutine(RollVitesseDice());

            yield break;
        }

        bool parade = DropdownUpdater.instance.defenseurAction.GetComponentInChildren<Text>().text == "Parer";
        bool esquive = DropdownUpdater.instance.defenseurAction.GetComponentInChildren<Text>().text == "Esquiver";

        int defensiveAction;
        if (defenseur.pnj)
        {
            defensiveAction = RollDice(100);
        }
        else
        {
            if (parade)
            {
                dictionaryLog = CreateLogDictionary(defenseur.characterName, "Adresse",
                    "", "/ " + defenseurStat.ToString());
            }
            else if (esquive)
            {
                dictionaryLog = CreateLogDictionary(defenseur.characterName, "Agilité",
                    "", "/ " + defenseurStat.ToString());
            }
            InputLog inputLog = LogController.instance.AddDefenseurInputLog(dictionaryLog);

            yield return new WaitUntil(() => inputLog.completed);

            defensiveAction = int.Parse(inputLog.roll.text);

            Destroy(inputLog.gameObject);
        }

        success = false;

        if (parade)
        {
            dictionaryLog = CreateLogDictionary(defenseur.characterName, "Adresse",
                defensiveAction.ToString(), "/ " + defenseurStat.ToString());
        }
        else if (esquive)
        {
            dictionaryLog = CreateLogDictionary(defenseur.characterName, "Agilité",
                defensiveAction.ToString(), "/ " + defenseurStat.ToString());
        }
        else
        {

        }

        if (defensiveAction <= defenseurStat && defensiveAction > 5)
        {
            LogController.instance.AddDefenseurWinLog(dictionaryLog);
        }
        else if (defensiveAction <= defenseurStat && defensiveAction <= 5)
        {
            LogController.instance.AddDefenseurCriticalWinLog(dictionaryLog);
        }
        else if (defensiveAction > defenseurStat && defensiveAction <= 95)
        {
            LogController.instance.AddDefenseurFailLog(dictionaryLog);
            success = true;
        }
        else if (defensiveAction > defenseurStat && defensiveAction > 95)
        {
            LogController.instance.AddDefenseurCriticalFailLog(dictionaryLog);
            success = true;
        }

        if (!secondRoll)
        {
            if (attackValue1 / (float)weaponStat1 > defensiveAction / (float)defenseurStat)
            {
                success = false;
            }
            else
            {
                success = true;
            }
        }
        else
        {
            if (attackValue2 / (float)weaponStat2 > defensiveAction / (float)defenseurStat)
            {
                success = false;
            }
            else
            {
                success = true;
            }
        }

        if (!success)
        {
            string logTemp = "";
            if (parade)
            {
                logTemp = "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>" + " pare l'attaque de "
                    + "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>";
            }
            else if (esquive)
            {
                logTemp = "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>" + " esquive l'attaque de "
                    + "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>";
            }

            LogController.instance.AddResultLog(logTemp);

            StartCoroutine(RollVitesseDice());

            yield break;
        }

        int defense;
        if (defenseur.pnj)
        {
            defense = RollDice(100);
        }
        else
        {
            dictionaryLog = CreateLogDictionary(defenseur.characterName, "Défense",
                "", "/ " + DropdownUpdater.instance.GetStat("Défense", defenseur).ToString());
            InputLog inputLog = LogController.instance.AddDefenseurInputLog(dictionaryLog);

            yield return new WaitUntil(() => inputLog.completed);

            defense = int.Parse(inputLog.roll.text);

            Destroy(inputLog.gameObject);
        }

        success = false;

        dictionaryLog = CreateLogDictionary(defenseur.characterName, "Défense",
                defense.ToString(), "/ " + DropdownUpdater.instance.GetStat("Défense", defenseur).ToString());

        if (defense <= DropdownUpdater.instance.GetStat("Défense", defenseur) && defense > 5)
        {
            LogController.instance.AddDefenseurWinLog(dictionaryLog);
            success = true;
        }
        else if (defense <= DropdownUpdater.instance.GetStat("Défense", defenseur) && defense <= 5)
        {
            LogController.instance.AddDefenseurCriticalWinLog(dictionaryLog);
            success = true;
        }
        else if (defense > DropdownUpdater.instance.GetStat("Défense", defenseur) && defense <= 95)
        {
            LogController.instance.AddDefenseurFailLog(dictionaryLog);
        }
        else if (defense > DropdownUpdater.instance.GetStat("Défense", defenseur) && defense > 95)
        {
            LogController.instance.AddDefenseurCriticalFailLog(dictionaryLog);
        }

        int degatsAbsorbes = 0;
        if (success)
        {
            int temp = DropdownUpdater.instance.GetStat("Défense", defenseur);
            while (temp >= defense)
            {
                temp -= 15;
                degatsAbsorbes += 1;
            }
        }

        int degats = 0;
        if (attaquant.pnj)
        {
            for (int i = 0; i < weapon.diceNumber; i++)
            {
                degats += RollDice(weapon.damages);
            }
        }
        else
        {
            dictionaryLog = CreateLogDictionary(attaquant.characterName, "Attaque (" + weapon.weaponName + ")",
                "", "/ " + weapon.diceNumber * weapon.damages);
            InputLog inputLog = LogController.instance.AddAttaquantInputLog(dictionaryLog);

            yield return new WaitUntil(() => inputLog.completed);

            degats = int.Parse(inputLog.roll.text);

            Destroy(inputLog.gameObject);
        }

        dictionaryLog = CreateLogDictionary(attaquant.characterName, "Attaque (" + weapon.weaponName + ")",
                degats.ToString() + " + " + weapon.bonusDamages * weapon.diceNumber, "/ " + weapon.diceNumber * (weapon.damages + weapon.bonusDamages));

        LogController.instance.AddAttaquantClassicalLog(dictionaryLog);

        degats += weapon.bonusDamages * weapon.diceNumber;

        string log2;
        if (degatsAbsorbes == 0)
        {
            log2 = "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>" + " inflige "
                + "<b>" + degats.ToString() + "</b> PV de dégât(s) à "
                + "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>";
        }
        else
        {
            log2 = "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>" + " inflige "
                + "<b>" + degats.ToString() + " - " + degatsAbsorbes.ToString() + "</b> PV de dégât(s) à "
                + "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>";
        }
        LogController.instance.AddResultLog(log2);

        StartCoroutine(RollVitesseDice());
    }
    
    public void AttackWithAbility()
    {
        StartCoroutine(ShowAttackWithAbilityLogs());
    }

    public IEnumerator ShowAttackWithAbilityLogs()
    {
        // Creating each character color string in hex

        List<float> floatColor = new List<float>();
        floatColor.Add((float)attaquant.color[0] / 255);
        floatColor.Add((float)attaquant.color[1] / 255);
        floatColor.Add((float)attaquant.color[2] / 255);

        string attaquantColor = ColorUtility.ToHtmlStringRGB(new Color(floatColor[0], floatColor[1], floatColor[2]));

        floatColor = new List<float>();
        floatColor.Add((float)defenseur.color[0] / 255);
        floatColor.Add((float)defenseur.color[1] / 255);
        floatColor.Add((float)defenseur.color[2] / 255);

        string defenseurColor = ColorUtility.ToHtmlStringRGB(new Color(floatColor[0], floatColor[1], floatColor[2]));

        // Used variables

        Dictionary<string, string> dictionaryLog;

        // First attack

        int attackValue1;
        if (attaquant.pnj)
        {
            attackValue1 = RollDice(100);
        }
        else
        {
            dictionaryLog = CreateLogDictionary(attaquant.characterName, DropdownUpdater.instance.abilityStat1Dropdown.GetComponentInChildren<Text>().text,
                "", "/ " + abilityStat1.ToString());
            InputLog inputLog = LogController.instance.AddAttaquantInputLog(dictionaryLog);

            yield return new WaitUntil(() => inputLog.completed);

            attackValue1 = int.Parse(inputLog.roll.text);

            Destroy(inputLog.gameObject);
        }

        dictionaryLog = CreateLogDictionary(attaquant.characterName, DropdownUpdater.instance.abilityStat1Dropdown.GetComponentInChildren<Text>().text,
            attackValue1.ToString(), "/ " + abilityStat1.ToString());

        bool success = true;

        if (attackValue1 <= abilityStat1 && attackValue1 > 5)
        {
            LogController.instance.AddAttaquantWinLog(dictionaryLog);
        }
        else if (attackValue1 <= abilityStat1 && attackValue1 <= 5)
        {
            LogController.instance.AddAttaquantCriticalWinLog(dictionaryLog);
        }
        else if (attackValue1 > abilityStat1 && attackValue1 <= 95)
        {
            LogController.instance.AddAttaquantFailLog(dictionaryLog);
            success = false;
        }
        else if (attackValue1 > abilityStat1 && attackValue1 > 95)
        {
            LogController.instance.AddAttaquantCriticalFailLog(dictionaryLog);
            success = false;
        }

        // Lancer de stat 2

        bool secondRoll = false;
        int attackValue2 = 0;
        if (DropdownUpdater.instance.abilityStat2Dropdown.GetComponentInChildren<Text>().text != "-")
        {
            secondRoll = true;

            if (attaquant.pnj)
            {
                attackValue2 = RollDice(100);
            }
            else
            {
                dictionaryLog = CreateLogDictionary(attaquant.characterName, DropdownUpdater.instance.abilityStat2Dropdown.GetComponentInChildren<Text>().text,
                    "", "/ " + abilityStat2.ToString());
                InputLog inputLog = LogController.instance.AddAttaquantInputLog(dictionaryLog);

                yield return new WaitUntil(() => inputLog.completed);

                attackValue2 = int.Parse(inputLog.roll.text);

                Destroy(inputLog.gameObject);
            }

            dictionaryLog = CreateLogDictionary(attaquant.characterName, DropdownUpdater.instance.abilityStat2Dropdown.GetComponentInChildren<Text>().text,
                attackValue2.ToString(), "/ " + abilityStat2.ToString());

            if (attackValue2 <= abilityStat2 && attackValue2 > 5)
            {
                LogController.instance.AddAttaquantWinLog(dictionaryLog);
            }
            else if (attackValue2 <= abilityStat2 && attackValue2 <= 5)
            {
                LogController.instance.AddAttaquantCriticalWinLog(dictionaryLog);
            }
            else if (attackValue2 > abilityStat2 && attackValue2 <= 95)
            {
                LogController.instance.AddAttaquantFailLog(dictionaryLog);
                success = false;
            }
            else if (attackValue2 > abilityStat2 && attackValue2 > 95)
            {
                LogController.instance.AddAttaquantCriticalFailLog(dictionaryLog);
                success = false;
            }
        }

        if (!success)
        {
            string logTemp = "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>" + " échoue à attaquer "
                + "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>";
            LogController.instance.AddResultLog(logTemp);

            StartCoroutine(RollVitesseDice());

            yield break;
        }

        bool parade = DropdownUpdater.instance.defenseurAction.GetComponentInChildren<Text>().text == "Parer";
        bool esquive = DropdownUpdater.instance.defenseurAction.GetComponentInChildren<Text>().text == "Esquiver";

        int defensiveAction;
        if (defenseur.pnj)
        {
            defensiveAction = RollDice(100);
        }
        else
        {
            if (parade)
            {
                dictionaryLog = CreateLogDictionary(defenseur.characterName, "Adresse",
                    "", "/ " + defenseurStat.ToString());
            }
            else if (esquive)
            {
                dictionaryLog = CreateLogDictionary(defenseur.characterName, "Agilité",
                    "", "/ " + defenseurStat.ToString());
            }
            InputLog inputLog = LogController.instance.AddDefenseurInputLog(dictionaryLog);

            yield return new WaitUntil(() => inputLog.completed);

            defensiveAction = int.Parse(inputLog.roll.text);

            Destroy(inputLog.gameObject);
        }

        success = false;

        if (parade)
        {
            dictionaryLog = CreateLogDictionary(defenseur.characterName, "Adresse",
                defensiveAction.ToString(), "/ " + defenseurStat.ToString());
        }
        else if (esquive)
        {
            dictionaryLog = CreateLogDictionary(defenseur.characterName, "Agilité",
                defensiveAction.ToString(), "/ " + defenseurStat.ToString());
        }
        else
        {

        }

        if (defensiveAction <= defenseurStat && defensiveAction > 5)
        {
            LogController.instance.AddDefenseurWinLog(dictionaryLog);
        }
        else if (defensiveAction <= defenseurStat && defensiveAction <= 5)
        {
            LogController.instance.AddDefenseurCriticalWinLog(dictionaryLog);
        }
        else if (defensiveAction > defenseurStat && defensiveAction <= 95)
        {
            LogController.instance.AddDefenseurFailLog(dictionaryLog);
            success = true;
        }
        else if (defensiveAction > defenseurStat && defensiveAction > 95)
        {
            LogController.instance.AddDefenseurCriticalFailLog(dictionaryLog);
            success = true;
        }

        if (!secondRoll)
        {
            if (attackValue1 / (float)abilityStat1 > defensiveAction / (float)defenseurStat)
            {
                success = false;
            }
            else
            {
                success = true;
            }
        }
        else
        {
            if (attackValue2 / (float)abilityStat2 > defensiveAction / (float)defenseurStat)
            {
                success = false;
            }
            else
            {
                success = true;
            }
        }

        if (!success)
        {
            string logTemp = "";
            if (parade)
            {
                logTemp = "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>" + " pare l'attaque de "
                    + "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>";
            }
            else if (esquive)
            {
                logTemp = "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>" + " esquive l'attaque de "
                    + "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>";
            }

            LogController.instance.AddResultLog(logTemp);

            StartCoroutine(RollVitesseDice());

            yield break;
        }

        int defense;
        if (defenseur.pnj)
        {
            defense = RollDice(100);
        }
        else
        {
            dictionaryLog = CreateLogDictionary(defenseur.characterName, "Défense",
                "", "/ " + DropdownUpdater.instance.GetStat("Défense", defenseur).ToString());
            InputLog inputLog = LogController.instance.AddDefenseurInputLog(dictionaryLog);

            yield return new WaitUntil(() => inputLog.completed);

            defense = int.Parse(inputLog.roll.text);

            Destroy(inputLog.gameObject);
        }

        success = false;

        dictionaryLog = CreateLogDictionary(defenseur.characterName, "Défense",
                defense.ToString(), "/ " + DropdownUpdater.instance.GetStat("Défense", defenseur).ToString());

        if (defense <= DropdownUpdater.instance.GetStat("Défense", defenseur) && defense > 5)
        {
            LogController.instance.AddDefenseurWinLog(dictionaryLog);
            success = true;
        }
        else if (defense <= DropdownUpdater.instance.GetStat("Défense", defenseur) && defense <= 5)
        {
            LogController.instance.AddDefenseurCriticalWinLog(dictionaryLog);
            success = true;
        }
        else if (defense > DropdownUpdater.instance.GetStat("Défense", defenseur) && defense <= 95)
        {
            LogController.instance.AddDefenseurFailLog(dictionaryLog);
        }
        else if (defense > DropdownUpdater.instance.GetStat("Défense", defenseur) && defense > 95)
        {
            LogController.instance.AddDefenseurCriticalFailLog(dictionaryLog);
        }

        int degatsAbsorbes = 0;
        if (success)
        {
            int temp = DropdownUpdater.instance.GetStat("Défense", defenseur);
            while (temp >= defense)
            {
                temp -= 15;
                degatsAbsorbes += 1;
            }
        }

        int degats = 0;
        if (attaquant.pnj)
        {
            for (int i = 0; i < weapon.diceNumber; i++)
            {
                degats += RollDice(weapon.damages);
            }
        }
        else
        {
            dictionaryLog = CreateLogDictionary(attaquant.characterName, "Attaque (" + ability.abilityName + ")",
                "", "/ " + ability.diceNumber * ability.damages);
            InputLog inputLog = LogController.instance.AddAttaquantInputLog(dictionaryLog);

            yield return new WaitUntil(() => inputLog.completed);

            degats = int.Parse(inputLog.roll.text);

            Destroy(inputLog.gameObject);
        }

        dictionaryLog = CreateLogDictionary(attaquant.characterName, "Attaque (" + ability.abilityName + ")",
                degats.ToString() + " + " + ability.bonusDamages * ability.diceNumber, "/ " + ability.diceNumber * (ability.damages + ability.bonusDamages));

        LogController.instance.AddAttaquantClassicalLog(dictionaryLog);

        degats += ability.bonusDamages * ability.diceNumber;

        string logString;
        if (degatsAbsorbes == 0)
        {
            logString = "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>" + " inflige "
                + "<b>" + degats.ToString() + "</b> PV de dégât(s) à "
                + "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>";
        }
        else
        {
            logString = "<color=#" + attaquantColor + "><b>" + attaquant.characterName + "</b></color>" + " inflige "
                + "<b>" + degats.ToString() + " - " + degatsAbsorbes.ToString() + "</b> PV de dégât(s) à "
                + "<color=#" + defenseurColor + "><b>" + defenseur.characterName + "</b></color>";
        }
        LogController.instance.AddResultLog(logString);

        StartCoroutine(RollVitesseDice());
    }

    public void RollDiceForStat()
    {
        int roll = RollDice(100);

        int stat = DropdownUpdater.instance.GetStat(DropdownUpdater.instance.statDropdown.GetComponentInChildren<Text>().text, attaquant);

        Dictionary<string, string> log = CreateLogDictionary(attaquant.characterName, DropdownUpdater.instance.statDropdown.GetComponentInChildren<Text>().text,
                roll.ToString(), "/ " + stat.ToString());

        if (roll <= stat && roll > 5)
        {
            LogController.instance.AddAttaquantWinLog(log);
        }
        else if (roll <= stat && roll <= 5)
        {
            LogController.instance.AddAttaquantCriticalWinLog(log);
        }
        else if (roll > stat && roll <= 95)
        {
            LogController.instance.AddAttaquantFailLog(log);
        }
        else if (roll > stat && roll > 95)
        {
            LogController.instance.AddAttaquantCriticalFailLog(log);
        }

        LogController.instance.AddSeparator();
    }

    public IEnumerator RollVitesseDice()
    {
        Dictionary<string, string> dictionaryLog;

        int vitesse;
        if (attaquant.pnj)
        {
            vitesse = RollDice(100);
        }
        else
        {
            dictionaryLog = CreateLogDictionary(attaquant.characterName, "Vitesse",
                "", "/ " + (DropdownUpdater.instance.GetStat("Vitesse", attaquant) / (2 * attackNumber)).ToString());
            InputLog inputLog = LogController.instance.AddAttaquantInputLog(dictionaryLog);

            yield return new WaitUntil(() => inputLog.completed);

            vitesse = int.Parse(inputLog.roll.text);

            Destroy(inputLog.gameObject);
        }

        bool success = false;

        dictionaryLog = CreateLogDictionary(attaquant.characterName, "Vitesse",
                vitesse.ToString(), "/ " + (DropdownUpdater.instance.GetStat("Vitesse", attaquant) / (2 * attackNumber)).ToString());

        if (vitesse <= (DropdownUpdater.instance.GetStat("Vitesse", attaquant) / (2 * attackNumber)) && vitesse > 5)
        {
            LogController.instance.AddAttaquantWinLog(dictionaryLog);
            success = true;
        }
        else if (vitesse <= (DropdownUpdater.instance.GetStat("Vitesse", attaquant) / (2 * attackNumber)) && vitesse <= 5)
        {
            LogController.instance.AddAttaquantCriticalWinLog(dictionaryLog);
            success = true;
        }
        else if (vitesse > (DropdownUpdater.instance.GetStat("Vitesse", attaquant) / (2 * attackNumber)) && vitesse <= 95)
        {
            LogController.instance.AddAttaquantFailLog(dictionaryLog);
        }
        else if (vitesse > (DropdownUpdater.instance.GetStat("Vitesse", attaquant) / (2 * attackNumber)) && vitesse > 95)
        {
            LogController.instance.AddAttaquantCriticalFailLog(dictionaryLog);
        }

        if (success)
        {
            attackNumber += 1;
            DropdownUpdater.instance.attaquantDropdown.interactable = false;
        }
        else
        {
            attackNumber = 1;
            DropdownUpdater.instance.attaquantDropdown.interactable = true;
            LogController.instance.AddSeparator();
        }
    }

    public int RollDice(int maxRoll)
    {
        return Random.Range(1, maxRoll + 1);
    }

    public Dictionary<string, string> CreateLogDictionary(string character, string statName, string rollValue, string statValue)
    {
        Dictionary<string, string> toReturn = new Dictionary<string, string>();
        toReturn.Add("character", character);
        toReturn.Add("stat name", statName);
        toReturn.Add("roll value", rollValue);
        toReturn.Add("stat value", statValue);

        return toReturn;
    }
}
