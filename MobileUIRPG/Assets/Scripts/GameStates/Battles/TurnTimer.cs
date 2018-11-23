using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartBattleCountDown(float _waitTime)
    {
        StartCoroutine(IE_StartBattleCountDown(_waitTime));
    }

    IEnumerator IE_StartBattleCountDown(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime); // waits 3 seconds
        BattleController.StartTurn();
    }

}
