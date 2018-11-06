using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class messageAttack : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    MethodBase method;

	// Use this for initialization
	void Awake () {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Attack);
	}
	
    public void Attack()
    {
        method = MethodBase.GetCurrentMethod();
        Debug.Log(gameObject.name + " -> " + method.Name);
    }
}
