/*****************************************************************************
// File Name :         ShadowPersonDart.cs
// Author :            Kyle Grenier
// Creation Date :     03/22/2021
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;

public class ShadowPersonDart : SpecificRotationEvent
{
    /// <summary>
    /// Invoked when the player is rotated properly.
    /// </summary>
    protected override void RunEvent()
    {
        Debug.Log("Running shadow person event!");
    }
}
