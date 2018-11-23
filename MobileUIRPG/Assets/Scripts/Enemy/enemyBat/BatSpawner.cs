using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner {

    private static BatSpawner instance = null;

    private BatSpawner()
    {
        Debug.Log("BatSpawner -> Constructor");
        BatFactory.Create();
    }

    public static BatSpawner Instance()
    {
        if (instance == null)
        {
            instance = new BatSpawner();
        }
        return instance;
    }

    public static void Create()
    {
        Instance().privCreate();
    }

    void privCreate()
    {
        /*SpawnBat(1);
        SpawnBat(2);
        SpawnBat(3);*/
    }

    void SpawnBat(int position)
    {
        GameObject temp = BatFactory.CreateBat();

        //Figure out where to add Spawn Variables on.
        // Enemy Manager get error if it uses variables from there
        switch(position)
        {
            case 1:
                temp.transform.position = new Vector3(-295.5f, 1.5f, 2.5f);
                break;
            case 2:
                temp.transform.position = new Vector3(-294f, 1.24f, -0.3f);
                break;
            case 3:
                temp.transform.position = new Vector3(-292.6f, 1.5f, 2.5f);
                break;

        }
        BattleController.AddToWaitQueue(temp.GetComponent<Enemy>());
    }

    public static void SpawnBats(int _amountOfEnemies)
    {
        Instance().privSpawnBats(_amountOfEnemies);
    }

    void privSpawnBats(int _amountOfEnemies)
    {
        for (int i = 0; i < _amountOfEnemies; i++)
        {
            GameObject temp = BatFactory.CreateBat();

            //Figure out where to add Spawn Variables on.
            // Enemy Manager get error if it uses variables from there

            temp.transform.position = EnemyManager.GetNextSpawnPoint();

            BattleController.AddToWaitQueue(temp.GetComponent<Enemy>());
        }
    }
}
