using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalManager
{
    private static GlobalManager instance = null;

    private GlobalManager()
    {
        Debug.Log("Global Manager Constructor");
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

