using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerState : battleState {

    playerStats localPlayerData;
    public Image healthBar;
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

        CreatePlayerCanvas();
	}
	
    void CreatePlayerCanvas()
    {
        GameObject playerUI = Instantiate(Resources.Load("CalledPrefabs/PlayerCanvas") as GameObject);
        playerUI.name = "PlayerCanvas";
        healthBar = playerUI.transform.GetChild(4).gameObject.GetComponent<Image>();
        healthBar.fillAmount = localPlayerData.currentHP / localPlayerData.maxHP;
        buttonAtt = playerUI.transform.GetChild(0).gameObject;
        buttonDef = playerUI.transform.GetChild(1).gameObject;
        imageWait = playerUI.transform.GetChild(2).gameObject;

        EnableButtons(true);
    }

    void EnableButtons(bool enabled)
    {
        buttonAtt.SetActive(enabled);
        buttonDef.SetActive(enabled);

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
                EnableButtons(true);
                break;
            case battleState.State.BEFORE:
                EnableButtons(false);
                break;
            case battleState.State.ACTION:
                EnableButtons(false);
                break;
            case battleState.State.AFTER:
                EnableButtons(false);
                break;
        }
    }

    public void SetMessage(messageBase _msg)
    {
        cmdBase = _msg;
    }

    public override IEnumerator Action()
    {
        while (inFirst)
        {
            yield return new WaitForSeconds(0.1f);
        }

        cmdBase.Process();
        BattleController.FinishTurn();
    }

    public void Damage(float _dmg)
    {
        localPlayerData.currentHP -= _dmg;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        healthBar.fillAmount = localPlayerData.currentHP / localPlayerData.maxHP;
    }

    void SavePlayer()
    {
        GlobalManager.SaveData(localPlayerData);
    }

    public void SetToChoose()
    {
        state = State.CHOOSE;
        DoState();
    }
}
