using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputLog : MonoBehaviour
{
    public Text characterName;
    public Text statName;
    public Text stat;
    public InputField roll;

    public bool completed;

    // Start is called before the first frame update
    void Start()
    {
        completed = false;
    }

    public void OnInputCompleted()
    {
        if (roll.text != "")
        {
            completed = true;
        }
    }
}
