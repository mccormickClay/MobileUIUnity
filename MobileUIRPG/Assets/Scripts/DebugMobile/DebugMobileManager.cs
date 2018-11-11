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

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static DebugMobileManager Instance()
    {
        if (instance == null)
        {
            instance = new DebugMobileManager();
        }
        return instance;
    }

    public static void SetDeBuggerText()
    {
        Instance().privSetDebuggerText();
    }

    void privSetDebuggerText()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject obj = new GameObject();
        obj.name = "Debug Log";
        obj.layer = LayerMask.NameToLayer("UI");
        obj.AddComponent<CanvasRenderer>();
        debuggerText = obj.AddComponent<Text>();
        debuggerText.fontSize = 70;
        debuggerText.horizontalOverflow = HorizontalWrapMode.Overflow;
        debuggerText.verticalOverflow = VerticalWrapMode.Overflow;
        debuggerText.resizeTextForBestFit = false;


        //debuggerText = Object.FindObjectOfType<Text>();
        //debuggerText.text = "";
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