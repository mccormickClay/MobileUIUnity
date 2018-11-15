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
        GameObject obj = new GameObject();
        privSetText(ref obj);

        GameObject canvas = new GameObject();
        privSetCanvas(ref canvas);

        obj.transform.SetParent(canvas.transform, false);

        obj.GetComponent<RectTransform>().pivot = Vector2.up;

        Vector2 pos = DisplayManager.GetPositionOnScreen(0.0f, 1.0f);

        obj.GetComponent<RectTransform>().position = pos;

    }

    void privSetText(ref GameObject obj)
    {
        obj.name = "DebugLog";
        obj.layer = LayerMask.NameToLayer("UI");
        obj.AddComponent<CanvasRenderer>();
        debuggerText = obj.AddComponent<Text>();
        debuggerText.fontSize = 20;
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
        rect.sizeDelta = DisplayManager.GetAspectRatio();
        rect.pivot = new Vector2(.5f, .5f);
        rect.localScale = new Vector3(0.25f,0.25f,0.25f);

        Canvas can = canvas.AddComponent<Canvas>();
        can.renderMode = RenderMode.ScreenSpaceOverlay;

        CanvasScaler cans = canvas.AddComponent<CanvasScaler>();
        cans.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        cans.referenceResolution = DisplayManager.GetAspectRatio();
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