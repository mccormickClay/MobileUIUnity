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
        enemyPosition_2 = new Vector3(-294f, 1.24f, -0.3f);
    }

    public static Vector3 GetMiddleSpawn()
    {
        return(Instance().privGetMiddleSpawn());
    }

    Vector3 privGetMiddleSpawn()
    {
        return (enemyPosition_2);
    }

    private Vector3 enemyPosition_1;
    private Vector3 enemyPosition_2;
    private Vector3 enemyPosition_3;
    public enum ENEMYSPAWNPOINT { LEFT, MIDDLE, RIGHT};

}
