using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController {

    private static BattleController instance = null;
    private bool battleMode = true;
    public Queue<battleState> turnQueue;
    public Queue<battleState> waitQueue;
    public int amountOfPawns = 1;
    public int turnsLeft;
    float timeBetweenTurns = 1.0f;

    TurnTimer timer;

    private BattleController()
    {
        turnQueue = new Queue<battleState>();
        waitQueue = new Queue<battleState>();
        GameObject timerObject = GameObject.Instantiate(Resources.Load("CalledPrefabs/TurnTimerObject") as GameObject);

        timer = timerObject.GetComponent<TurnTimer>();
    }

    public static BattleController Instance()
    {
        if(instance == null)
        {
            instance = new BattleController();
        }
        return (instance);
    }

    public static void Create()
    {
        Instance().privCreate();
    }

    void privCreate()
    {
        Debug.Log("Amount of pawns in scene: " + amountOfPawns);
    }

    public static void AddTurn( battleState _go)
    {
        Debug.Log("Turn Added from: " + _go.name);
        Instance().privAddTurn( _go);
    }

    void privAddTurn( battleState _go)
    {
        turnQueue.Enqueue(_go);
        if(turnQueue.Count == amountOfPawns)
        {
            turnsLeft = amountOfPawns;
            BattleSequence();
        }
        else
        {
            EnemyChoose();
        }
    }

    public static void AddToWaitQueue(battleState _go)
    {
        Instance().privAddToWaitQueue(_go);
    }

    void privAddToWaitQueue(battleState _go)
    {
        waitQueue.Enqueue(_go);
    }

    public static void EnemyChoose()
    {
        Instance().privEnemyChoose();
    }

    void privEnemyChoose()
    {
        Debug.Log("waitQueue size: " + waitQueue.Count);
        if (waitQueue.Count != 0)
        {
            battleState temp = waitQueue.Dequeue();
            temp.NextState();
        }
    }

    public static void StartTurn()
    {
        Instance().privStartTurn();
    }

    void privStartTurn()
    {
        Debug.Log(turnQueue.Count);
        battleState temp = turnQueue.Dequeue();

        temp.Action();

        temp.SetState(battleState.State.WAIT);
        waitQueue.Enqueue(temp);

    }

    void BattleSequence()
    {
        if (Instance().turnQueue.Count > 0)
        {
            timer.StartBattleCountDown(timeBetweenTurns);
        }

    }

    public static void IncrementPawn()
    {
        Instance().privIncrementPawn();
    }

    void privIncrementPawn()
    {
        amountOfPawns++;
        Debug.Log("Amount of pawns in scene1: " + amountOfPawns);
    }

    public static void FinishTurn()
    {
        Instance().privFinishTurn();
    }

    void privFinishTurn()
    {
        turnsLeft--;

        Debug.Log("Amount of turns left: " + turnsLeft);

        if (turnsLeft == 0)
        {
            Debug.Log("There are zero turns left");
            PlayerManager.SetPlayerToChoose();
        }
        else
        {
            BattleSequence();
        }
    }
}
