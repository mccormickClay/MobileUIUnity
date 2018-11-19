using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager
{
    private static GlobalManager instance = null;
    private playerStats savedData;

    private GlobalManager()
    {
        Debug.Log("Global Manager Constructor");
        DisplayManager.Create();
        DebugMobileManager.Create();

        PlayerManager.Create();
        BattleController.Create();
        EnemyManager.Create();

        savedData = new playerStats();
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

    public static void SaveData(playerStats _data)
    {
        Instance().privSaveData(_data);
    }

    void privSaveData(playerStats _data)
    {
        savedData = _data;
    }

    public static playerStats LoadData()
    {
        return(Instance().privLoadData());
    }

    playerStats privLoadData()
    {
        return (savedData);
    }
}

