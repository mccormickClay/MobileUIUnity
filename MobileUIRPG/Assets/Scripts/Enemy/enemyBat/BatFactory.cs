using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFactory {

    private static BatFactory instance = null;
    private Queue<GameObject> inactiveGOs = new Queue<GameObject>();
    private Queue<GameObject> activeGOs = new Queue<GameObject>();

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

    public static GameObject GetInactiveBat()
    {
        return(Instance().privGetInactiveBat());
    }

    GameObject privGetInactiveBat()
    {
        GameObject temp = inactiveGOs.Dequeue();
        activeGOs.Enqueue(temp);
        return (temp);
    }
}
