using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController {

    private static BattleController instance = null;
    private bool battleMode = true;
    public Queue<battleState> turnQueue;
    public int amountOfPawns = 1;
    public int turnsLeft;
    float timeBetweenTurns = 2.0f;

    TurnTimer timer;

    private BattleController()
    {
        turnQueue = new Queue<battleState>();
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
    }

    public static void StartTurn()
    {
        Instance().privStartTurn();
    }

    void privStartTurn()
    {
        Debug.Log(turnQueue.Count);
        battleState temp = turnQueue.Dequeue();

        temp.PerformAction();

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
