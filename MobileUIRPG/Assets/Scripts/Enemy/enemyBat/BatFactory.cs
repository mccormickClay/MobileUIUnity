using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFactory {

    private static BatFactory instance = null;
    private Queue<GameObject> inactiveGOs = new Queue<GameObject>();
    private List<GameObject> activeList = new List<GameObject>();

    private int poolAmount = 3;

    private BatFactory()
    {
        Debug.Log("BatFactory -> Constructor");
    }

    public static BatFactory Instance()
    {
        if (instance == null)
        {
            instance = new BatFactory();
        }
        return instance;
    }

    public static void Create()
    {
        Instance().privCreate();
    }

    void privCreate()
    {
        LoadBats();
    }

    private static void LoadBats()
    {
        Instance().privLoadBats();
    }

    void privLoadBats()
    {
        for(int i = 0; i < poolAmount; i++)
        {
            GameObject bat = GameObject.Instantiate(Resources.Load("CalledPrefabs/Enemies/Enemy_Bat") as GameObject);
            bat.SetActive(false);
            inactiveGOs.Enqueue(bat);
        }
    }

    /* Get Inactive GO. Set inactive object to Active
     * Send object to active list*/
    public static GameObject CreateBat()
    {
        return(Instance().privCreateBat());
    }

    GameObject privCreateBat()
    {
        GameObject temp = inactiveGOs.Dequeue();
        temp.SetActive(true);
        activeList.Add(temp);
        BattleController.IncrementPawn();
        return (temp);
    }

    /* "Destroy" GO. Set object to inactive and
     * send to inactive queue*/
    public static void Recycle(GameObject _enemyBat)
    {
        Instance().privRecycle(_enemyBat);
    }

    void privRecycle(GameObject _enemyBat)
    {
        activeList.Remove(_enemyBat);
        _enemyBat.SetActive(false);
        inactiveGOs.Enqueue(_enemyBat);
    }
}
