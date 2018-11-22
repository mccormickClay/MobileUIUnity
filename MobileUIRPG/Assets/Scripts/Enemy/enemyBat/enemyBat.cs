using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyBat : Enemy
{
    public float health;

    // Use this for initialization
    void Start() {
        state = State.WAIT;
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
            case battleState.State.WAIT:
                Debug.Log("Bat is Waiting...");
                break;
        }
    }
}
