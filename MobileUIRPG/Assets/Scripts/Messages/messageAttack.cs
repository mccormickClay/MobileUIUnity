using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class messageAttack : messageBase {

    MethodBase method;
    GameObject enemy;
    messageSelectEnemy selector;
    playerState playerState;

    // Use this for initialization
    void Awake () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Choose);

        selector = player.GetComponent<messageSelectEnemy>();
        playerState = player.GetComponent<playerState>();
        messageAttack message = this;
        selector.SetMsgAttack(ref message);
	}
	
    public override void Choose()
    {
        if (enemy != null)
        {
            method = MethodBase.GetCurrentMethod();
            Debug.Log(gameObject.name + " -> " + method.Name);

            BattleController.AddTurn(playerState);

            playerState.SetMessage(this);
            enemy.GetComponent<Enemy>().NextState();

            playerState.NextState(); // Before
            //Process();
        }
    }

    public override void Process()
    {
        playerState.NextState(); // Action
        Debug.Log("Player Processed an Attack!");
        enemy.GetComponent<Enemy>().Damage(10);
        playerState.NextState(); // After
    }

    public void SetSelected(ref GameObject _selected)
    {
        enemy = _selected;
    }
}
