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
        GameObject obj = new GameObject();
        privSetText(ref obj);

        GameObject canvas = new GameObject();
        privSetCanvas(ref canvas);

        obj.transform.parent = canvas.transform;

        obj.GetComponent<RectTransform>().localPosition = new Vector3(-400f, 890f, 0f);

        //debuggerText = Object.FindObjectOfType<Text>();
        //debuggerText.text = "";
    }

    void privSetText(ref GameObject obj)
    {
        obj.name = "DebugLog";
        obj.layer = LayerMask.NameToLayer("UI");
        obj.AddComponent<CanvasRenderer>();
        debuggerText = obj.AddComponent<Text>();
        debuggerText.fontSize = 70;
        debuggerText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        debuggerText.horizontalOverflow = HorizontalWrapMode.Overflow;
        debuggerText.verticalOverflow = VerticalWrapMode.Overflow;
        debuggerText.resizeTextForBestFit = false;
        debuggerText.supportRichText = true;
        debuggerText.color = Color.red;
        debuggerText.text = "DEBUGGER ACTIVE";
    }

    void privSetCanvas(ref GameObject canvas)
    {
        canvas.name = "DebugCanvas";
        canvas.layer = LayerMask.NameToLayer("UI");

        RectTransform rect = canvas.AddComponent<RectTransform>();
        rect.position = new Vector3(137f, 244f, 0f);
        rect.sizeDelta = new Vector2(1080f, 1920f);
        rect.pivot = new Vector2(.5f, .5f);
        rect.localScale = new Vector3(0.25f,0.25f,0.25f);

        Canvas can = canvas.AddComponent<Canvas>();
        can.renderMode = RenderMode.ScreenSpaceOverlay;

        CanvasScaler cans = canvas.AddComponent<CanvasScaler>();
        cans.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        cans.referenceResolution = new Vector2(1080f, 1920f);
        cans.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        cans.referencePixelsPerUnit = 100f;

        GraphicRaycaster graphicRaycaster = canvas.AddComponent<GraphicRaycaster>();
        graphicRaycaster.ignoreReversedGraphics = true;
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