using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleState : MonoBehaviour {

    enum State {
        PLAYERCHOOSE,
        PLAYERACTION,
        ENEMYCHOOSE,
        ENEMYACTION,
        ENDROUND }

    State state;

	// Use this for initialization
	void Start () {
        state = State.PLAYERCHOOSE;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
