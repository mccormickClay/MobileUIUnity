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
        SpawnBat(2);
    }

    void SpawnBat(int position)
    {
        GameObject temp = BatFactory.CreateBat();

        //Figure out where to add Spawn Variables on.
        // Enemy Manager get error if it uses variables from there
        switch(position)
        {
            case 1:
                temp.transform.position = Vector3.zero;
                break;
            case 2:
                temp.transform.position = new Vector3(-294f, 1.24f, -0.3f); ;
                break;    

        }
        temp.SetActive(true);
    }
}
