using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class messageAttack : MonoBehaviour {

    MethodBase method;
    GameObject enemy;
    messageSelectEnemy selector;
    playerState playerState;

    // Use this for initialization
    void Awake () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Attack);

        selector = player.GetComponent<messageSelectEnemy>();
        playerState = player.GetComponent<playerState>();
        messageAttack message = this;
        selector.SetMsgAttack(ref message);
	}
	
    public void Attack()
    {
        if (enemy != null)
        {
            playerState.NextState();
            method = MethodBase.GetCurrentMethod();
            Debug.Log(gameObject.name + " -> " + method.Name);
            GlobalManager.Print();
            enemy.GetComponent<Enemy>().Damage(10);
            playerState.NextState();
        }
    }

    public void SetSelected(ref GameObject _selected)
    {
        enemy = _selected;
    }
}
