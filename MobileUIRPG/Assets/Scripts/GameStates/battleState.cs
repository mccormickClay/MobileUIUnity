using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class battleState : MonoBehaviour {

    protected enum State {
        CHOOSE, WAIT, ACTION }

    protected State state;

    protected abstract void DoState();
    void SetState(State _state)
    {
        state = _state;
    }

    public void NextState()
    {

        switch (state)
        {
            case State.CHOOSE:
                SetState(State.ACTION);   
                break;
            case State.ACTION:
                SetState(state = State.WAIT);
                break;
            case State.WAIT:
                SetState(state = State.CHOOSE);
                break;
        }

        DoState();
    }

}
