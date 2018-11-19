using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyBat : Enemy
{
    public float health;

    // Use this for initialization
    void Start() {
        state = State.AFTER;
        SetHealth(health);
        SetStrength(25f);

    }

    public override void SendToFactory()
    {
        BatFactory.Recycle(this.gameObject);
    }

    // Update is called once per frame
    void Update() {

    }

    protected override void DoState()
    {
        switch (state)
        {
            case battleState.State.CHOOSE:
                Debug.Log("Bat is Choosing...");
                BattleController.AddTurn(this);
                NextState();
                break;
            case battleState.State.BEFORE:
                NextState();
                break;
            case battleState.State.ACTION:
                Debug.Log("Bat is Performing Action...");
                //StartCoroutine(Action());
                //StartCoroutine(WaitToChangeStates());
                break;
            case battleState.State.AFTER:
                Debug.Log("Bat is Waiting...");
                break;
        }
    }
}
