using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    public enum Type
    {
        Classic = 0,
        CriticalWin = 1,
        Win = 2,
        Fail = 3,
        CriticalFail = 4,
        None = 5
    }

    public Text characterName;
    public Text statName;
    public Text stat;
    public Text roll;
}
