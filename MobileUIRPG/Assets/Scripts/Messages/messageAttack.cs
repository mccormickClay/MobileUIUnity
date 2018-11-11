using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class messageAttack : MonoBehaviour {

    MethodBase method;
    GameObject enemy;
    messageSelectEnemy selector;

    // Use this for initialization
    void Awake () {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Attack);

        selector = GameObject.FindGameObjectWithTag("Player").GetComponent<messageSelectEnemy>();
        messageAttack message = this;
        selector.SetMsgAttack(ref message);
	}
	
    public void Attack()
    {
        if (enemy != null)
        {
            method = MethodBase.GetCurrentMethod();
            Debug.Log(gameObject.name + " -> " + method.Name);
            GlobalManager.Print();
            enemy.GetComponent<Enemy>().Damage(10);
        }
    }

    public void SetSelected(ref GameObject _selected)
    {
        enemy = _selected;
    }
}
