using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogController : MonoBehaviour
{
    public static LogController instance;

    public GameObject resultLog;
    public GameObject separator;

    [Header("Attaquant")]
    public GameObject attaquantCriticalWinLog;
    public GameObject attaquantWinLog;
    public GameObject attaquantFailLog;
    public GameObject attaquantCriticalFailLog;
    public GameObject attaquantClassicalLog;
    public GameObject attaquantInputLog;

    [Header("Defenseur")]
    public GameObject defenseurCriticalWinLog;
    public GameObject defenseurWinLog;
    public GameObject defenseurFailLog;
    public GameObject defenseurCriticalFailLog;
    public GameObject defenseurInputLog;

    [Header("Divers")]
    public GameObject logContainer;

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

    // Attaquant

    public void AddAttaquantCriticalWinLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(attaquantCriticalWinLog, logContainer.transform);
        Log logComponent = go.GetComponent<Log>();

        CompleteLog(logComponent, logs, FightController.instance.attaquant);
    }

    public void AddAttaquantWinLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(attaquantWinLog, logContainer.transform);
        Log logComponent = go.GetComponent<Log>();

        CompleteLog(logComponent, logs, FightController.instance.attaquant);
    }

    public void AddAttaquantFailLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(attaquantFailLog, logContainer.transform);
        Log logComponent = go.GetComponent<Log>();

        CompleteLog(logComponent, logs, FightController.instance.attaquant);
    }

    public void AddAttaquantCriticalFailLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(attaquantCriticalFailLog, logContainer.transform);
        Log logComponent = go.GetComponent<Log>();

        CompleteLog(logComponent, logs, FightController.instance.attaquant);
    }

    public void AddAttaquantClassicalLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(attaquantClassicalLog, logContainer.transform);
        Log logComponent = go.GetComponent<Log>();

        CompleteLog(logComponent, logs, FightController.instance.attaquant);
    }

    public InputLog AddAttaquantInputLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(attaquantInputLog, logContainer.transform);
        InputLog logComponent = go.GetComponent<InputLog>();

        CompleteInputLog(logComponent, logs, FightController.instance.attaquant);

        return logComponent;
    }

    //Defenseur

    public void AddDefenseurCriticalWinLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(defenseurCriticalWinLog, logContainer.transform);
        Log logComponent = go.GetComponent<Log>();

        CompleteLog(logComponent, logs, FightController.instance.defenseur);
    }

    public void AddDefenseurWinLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(defenseurWinLog, logContainer.transform);
        Log logComponent = go.GetComponent<Log>();

        CompleteLog(logComponent, logs, FightController.instance.defenseur);
    }

    public void AddDefenseurFailLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(defenseurFailLog, logContainer.transform);
        Log logComponent = go.GetComponent<Log>();

        CompleteLog(logComponent, logs, FightController.instance.defenseur);
    }

    public void AddDefenseurCriticalFailLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(defenseurCriticalFailLog, logContainer.transform);
        Log logComponent = go.GetComponent<Log>();

        CompleteLog(logComponent, logs, FightController.instance.defenseur);
    }

    public InputLog AddDefenseurInputLog(Dictionary<string, string> logs)
    {
        GameObject go = Instantiate(defenseurInputLog, logContainer.transform);
        InputLog logComponent = go.GetComponent<InputLog>();

        CompleteInputLog(logComponent, logs, FightController.instance.defenseur);

        return logComponent;
    }

    // Result Log

    public void AddResultLog(string log)
    {
        GameObject go = Instantiate(resultLog, logContainer.transform);
        go.GetComponentInChildren<Text>().text = log;
    }

    // Separator

    public void AddSeparator()
    {
        Instantiate(separator, logContainer.transform);
    }

    // Completion method

    public void CompleteLog(Log logComponent, Dictionary<string, string> logs, SaveCharacter saveCharacter)
    {
        logComponent.characterName.text = logs["character"];
        logComponent.statName.text = logs["stat name"];
        logComponent.stat.text = logs["stat value"];
        logComponent.roll.text = logs["roll value"];

        List<float> floatColor = new List<float>();
        floatColor.Add((float)saveCharacter.color[0] / 255);
        floatColor.Add((float)saveCharacter.color[1] / 255);
        floatColor.Add((float)saveCharacter.color[2] / 255);
        logComponent.characterName.color = new Color(floatColor[0], floatColor[1], floatColor[2]);
    }

    public void CompleteInputLog(InputLog logComponent, Dictionary<string, string> logs, SaveCharacter saveCharacter)
    {
        logComponent.characterName.text = logs["character"];
        logComponent.statName.text = logs["stat name"];
        logComponent.stat.text = logs["stat value"];

        List<float> floatColor = new List<float>();
        floatColor.Add((float)saveCharacter.color[0] / 255);
        floatColor.Add((float)saveCharacter.color[1] / 255);
        floatColor.Add((float)saveCharacter.color[2] / 255);
        logComponent.characterName.color = new Color(floatColor[0], floatColor[1], floatColor[2]);
    }
}
