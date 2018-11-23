using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class battleState : MonoBehaviour {

    public enum State {
        CHOOSE, WAIT }

    public State state;
    protected bool inFirst = false;

    protected abstract void DoState();
    public void SetState(State _state)
    {
        state = _state;
        DoState();
    }

    public void NextState()
    {

        switch (state)
        {
            case State.CHOOSE:
                SetState(State.WAIT);   
                break;
            case State.WAIT:
                SetState(State.CHOOSE);
                break;
        }

        DoState();
    }



    public abstract void Action();
}
