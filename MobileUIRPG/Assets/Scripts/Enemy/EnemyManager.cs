using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager {

    private static EnemyManager instance = null;

    private EnemyManager()
    {
        Debug.Log("EnemyManager -> Constructor()");
        DebugMobileManager.Log("EnemyManager -> Constructor()");
        BatSpawner.Create();
    }

    public static EnemyManager Instance()
    {
        if(instance == null)
        {
            instance = new EnemyManager();
        }
        return(instance);
    }

    public static void Create()
    {
        Instance().privCreate();
    }

    void privCreate()
    {
        Debug.Log("Create enemy object/factory for storage");
        enemyPosition_Middle = new Vector3(-294f, 1.24f, -0.3f);
        enemyPosition_Left = new Vector3(-295.5f, 1.5f, 2.5f);
        enemyPosition_Right = new Vector3(-292.6f, 1.5f, 2.5f);

        BatSpawner.SpawnBats(3);
    }

    public static Vector3 GetNextSpawnPoint()
    {
        return(Instance().privGetNextSpawnPoint());
    }

    Vector3 privGetNextSpawnPoint()
    {
        Vector3 temp = Vector3.zero;

        switch (spawnPoint)
        {
            case 0:
                temp = enemyPosition_Middle;
                break;
            case 1:
                temp = enemyPosition_Left;
                break;
            case 2:
                temp = enemyPosition_Right;
                break;
            default:
                temp = Vector3.zero;
                Debug.Log("To Many Enemies are already spawned!");
                break;
        }

        spawnPoint++;
        return (temp);
            
    }

    private Vector3 enemyPosition_Middle;
    private Vector3 enemyPosition_Left;
    private Vector3 enemyPosition_Right;
    static int spawnPoint = 0;

}
