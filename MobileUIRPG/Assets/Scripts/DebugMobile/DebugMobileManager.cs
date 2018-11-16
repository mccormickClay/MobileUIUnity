using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMobileManager
{
    private static DebugMobileManager instance = null;
    private Text debuggerText;
    private Queue<string> queue = new Queue<string>();

    private DebugMobileManager()
    {
        Debug.Log("DebugMobileManager Constructor");
    }

    public static DebugMobileManager Instance()
    {
        if (instance == null)
        {
            instance = new DebugMobileManager();
        }
        return instance;
    }

    public static void Create()
    {
        Instance().privCreate();
    }

    void privCreate()
    {
        //GameObject debugUI = Resources.Load("CalledPrefabs/DebugCanvas") as GameObject;
        GameObject debugUI = GameObject.Instantiate(Resources.Load("CalledPrefabs/DebugCanvas") as GameObject);
        debugUI.name = "DebugCanvas";
        debuggerText = debugUI.transform.GetChild(0).GetComponent<Text>();
    }

    public static void Log(string _info)
    {
        Instance().privLog(_info);
    }

    void privLog(string _info)
    {

        queue.Enqueue(_info);
        if (queue.Count > 10)
        {
            queue.Dequeue();
            Debug.Log("Size of debug queue: " + queue.Count);
        }

        privRefreshLog();

    }

    void privRefreshLog()
    {
        debuggerText.text = "";

        foreach (string s in queue)
        {
            debuggerText.text += s;
            debuggerText.text += "\n";
        }
    }
}