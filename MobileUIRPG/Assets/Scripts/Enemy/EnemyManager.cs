using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager {

    private static EnemyManager instance = null;

    private EnemyManager()
    {
        Debug.Log("EnemyManager -> Constructor()");
        DebugMobileManager.Log("EnemyManager -> Constructor()");
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
    }
}
