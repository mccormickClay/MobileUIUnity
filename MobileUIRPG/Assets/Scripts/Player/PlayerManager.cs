using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager {

    private static PlayerManager instance = null;

    private PlayerManager()
    {

    }

    public static PlayerManager Instance()
    {
        if(instance == null)
        {
            instance = new PlayerManager();
        }
        return (instance);
    }

    public static void Create()
    {
        Instance().privCreate();
    }

    private void privCreate()
    {
        GameObject bat = GameObject.Instantiate(Resources.Load("CalledPrefabs/Player/Player") as GameObject);
        bat.name = "Player";
    }
}
