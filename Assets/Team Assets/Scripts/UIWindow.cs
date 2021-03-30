/*****************************************************************************
// File Name :         UIWindow.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;

public abstract class UIWindow : MonoBehaviour
{
    public virtual void OpenWindow()
    {
        EventManager.OpenUIWindow(this);
    }

    public virtual void CloseWindow()
    {
        EventManager.CloseUIWindow(this);
    }
}
