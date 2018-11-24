using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerState : battleState {

    playerStats localPlayerData;
    //public Image healthBar;
    messageBase cmdBase;

    GameObject buttonAtt;
    GameObject buttonDef;
    GameObject imageWait;

    // Use this for initialization
    void Start () {
        localPlayerData = GlobalManager.LoadData();
        state = battleState.State.CHOOSE;
        cmdBase = null;

        if(localPlayerData.maxHP == 0)
        {
            localPlayerData.maxHP = 100f;
            localPlayerData.currentHP = localPlayerData.maxHP;
        }

        localPlayerData.classCmd = new WarriorClass();
        CreatePlayerCanvas();
	}
	

    void CreatePlayerCanvas()
    {
        localPlayerData.classCmd.CreateCanvas(localPlayerData.currentHP, localPlayerData.maxHP);
        
    }

    void EnableButtons(bool enabled)
    {
        buttonAtt.SetActive(enabled);
        //buttonDef.SetActive(enabled);

        imageWait.SetActive(!enabled);
    }

    // Update is called once per frame
    void Update () {
		
	}

    protected override void DoState()
    {
        switch(state)
        {
            case battleState.State.CHOOSE:
                Debug.Log("Set to Choose");
                localPlayerData.classCmd.EnableButtons(true);
                break;
            case battleState.State.WAIT:
                Debug.Log("Set to Wait");
                localPlayerData.classCmd.EnableButtons(false);
                break;
        }
    }

    public void SetMessage(messageBase _msg)
    {
        cmdBase = _msg;
    }

    public override void Action()
    {
        cmdBase.Process();
        BattleController.FinishTurn();
    }

    public void Damage(float _dmg)
    {
        localPlayerData.currentHP -= _dmg;
        localPlayerData.classCmd.UpdateHealth(localPlayerData.currentHP);
    }



    void SavePlayer()
    {
        GlobalManager.SaveData(localPlayerData);
    }

    public void SetToChoose()
    {
        Debug.Log("Player Set to Choose");
        state = State.CHOOSE;
        DoState();
    }
}
