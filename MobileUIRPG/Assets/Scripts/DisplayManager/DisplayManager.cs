using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager
{

    private static DisplayManager instance = null;

    private DisplayManager()
    {
        Debug.Log("DisplayManager Constructor");      
    }

    public static DisplayManager Instance()
    {
        if (instance == null)
        {
            instance = new DisplayManager();
        }
        return instance;
    }

    public static void Create()
    {
        Instance().privCreate();
    }

    void privCreate()
    {
        aspectRatio = new Vector2(Screen.width, Screen.height);        
    }

    public static Vector2 GetAspectRatio()
    {
        return (Instance().privGetAspectRatio());
    }

    Vector2 privGetAspectRatio()
    {
        return (aspectRatio);
    }

    public static void PrintRatio()
    {
        Instance().privPrintRatio();
    }

    void privPrintRatio()
    {
        Debug.Log("The aspect ratio is: " + aspectRatio.x + "x" + aspectRatio.y);
        DebugMobileManager.Log("The aspect ratio is: " + aspectRatio.x.ToString() + "x" + aspectRatio.y.ToString());
    }

    public static Vector3 GetPositionOnScreen(float _x = 0.0f, float _y = 0.0f, float _z = 0.0f)
    {
        return(Instance().privGetPositionOnScreen(_x,_y,_z));
    }

    Vector3 privGetPositionOnScreen(float _x, float _y, float _z)
    {
        Vector3 posOnScreen = new Vector3(_x, _y, _z);
        return (posOnScreen);
    }

    Vector2 aspectRatio;


}