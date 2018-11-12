using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerState : MonoBehaviour {

    playerStats localPlayerData;
    public Image healthBar;

    // Use this for initialization
    void Start () {
        localPlayerData = GlobalManager.LoadData();

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
        healthBar = playerUI.transform.GetChild(3).gameObject.GetComponent<Image>();
        healthBar.fillAmount = localPlayerData.currentHP / localPlayerData.maxHP;
    }

	// Update is called once per frame
	void Update () {
		
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
}
