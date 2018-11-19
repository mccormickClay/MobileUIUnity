using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class battleState : MonoBehaviour {

    protected enum State {
        CHOOSE, BEFORE, ACTION, AFTER }

    protected State state;
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
                SetState(State.BEFORE);   
                break;
            case State.BEFORE:
                SetState(State.ACTION);
                break;
            case State.ACTION:
                SetState(State.AFTER);
                break;
            case State.AFTER:
                SetState(State.CHOOSE);
                break;
        }

        DoState();
    }

    public void PerformAction(float _waitTime)
    {
        StartCoroutine(Waiting(_waitTime));
        StartCoroutine(Action());
    }

    private IEnumerator Waiting(float waitTime)
    {
        inFirst = true;
        print("in FinishFirst");
        yield return new WaitForSeconds(waitTime);
        print("leave FinishFirst");
        inFirst = false;
    }

    public abstract IEnumerator Action();
}
