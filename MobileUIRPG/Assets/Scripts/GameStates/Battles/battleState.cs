using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class battleState : MonoBehaviour {

    public enum State {
        CHOOSE, WAIT }

    public State state;
    protected bool inFirst = false;

    protected abstract void DoState();
    protected void SetState(State _state)
    {
        state = _state;
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

    public void PerformAction()
    {
        Action();
    }

    private IEnumerator Waiting(float waitTime)
    {
        inFirst = true;
        print("in FinishFirst");
        yield return new WaitForSeconds(waitTime);
        print("leave FinishFirst");
        inFirst = false;
    }
    public abstract void Action();
}
