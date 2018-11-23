using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class messageBase : MonoBehaviour {

    protected playerState playerState;

    protected abstract void Choose();
    protected void Wait()
    {
        playerState.SetState(battleState.State.WAIT); // Wait
        BattleController.EnemyChoose();
    }

    public abstract void Process();
}
