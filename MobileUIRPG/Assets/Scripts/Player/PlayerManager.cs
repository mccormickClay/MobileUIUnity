using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager {

    private static PlayerManager instance = null;
    private playerState playerState;

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
        GameObject player = GameObject.Instantiate(Resources.Load("CalledPrefabs/Player/Player") as GameObject);
        playerState = player.GetComponent<playerState>();
        player.name = "Player";
    }

    public static void SetPlayerToChoose()
    {
        Instance().privSetPlayerToChoose();
    }

    void privSetPlayerToChoose()
    {
        playerState.SetToChoose();
    }
}
