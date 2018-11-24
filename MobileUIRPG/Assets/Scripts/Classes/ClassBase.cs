using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ClassBase {

    public Image healthBar;
    private float playerMaxHP;
    protected GameObject skillUI;

    protected GameObject imageWait;

    // Use this for initialization
    protected void CreateClassCanvas(string ClassName, float currentHP, float maxHP)
    {
        GameObject playerUI = GameObject.Instantiate(Resources.Load("CalledPrefabs/ClassCanvas/" + ClassName + "Canvas") as GameObject);
        playerUI.name = ClassName + "Canvas";
        skillUI = playerUI.transform.GetChild(0).gameObject;
        imageWait = playerUI.transform.GetChild(1).gameObject;

        healthBar = playerUI.transform.GetChild(3).gameObject.GetComponent<Image>();

        playerMaxHP = maxHP;
        healthBar.fillAmount = currentHP / playerMaxHP;

        EnableButtons(true);
    }

    public void EnableButtons(bool enabled)
    {
        skillUI.SetActive(enabled);
        
        imageWait.SetActive(!enabled);
    }

    public void UpdateHealth(float _currentHP)
    {
        healthBar.fillAmount = _currentHP / playerMaxHP;
    }

    public abstract void CreateCanvas(float currentHP, float maxHP);
}
