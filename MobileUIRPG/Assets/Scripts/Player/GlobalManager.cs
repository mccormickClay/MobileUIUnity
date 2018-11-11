using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager
{
    private static GlobalManager instance = null;
    private Text debuggerText;

    private GlobalManager()
    {
        Debug.Log("Global Manager Constructor");

        // Finds
        DebugMobileManager.SetDeBuggerText();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static GlobalManager Instance()
    {
        if (instance == null)
        {
            instance = new GlobalManager();
        }
        return instance;
    }

    public static void Print()
    {
        Instance().privPrint();
    }

    void privPrint()
    {
        Debug.Log("Print");
    }
}

