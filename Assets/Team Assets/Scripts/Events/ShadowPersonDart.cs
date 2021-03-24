/*****************************************************************************
// File Name :         ShadowPersonDart.cs
// Author :            Kyle Grenier
// Creation Date :     03/22/2021
//
// Brief Description : Triggers darting a shadow person down the hall.
*****************************************************************************/
using UnityEngine;

public class ShadowPersonDart : SpecificRotationEvent
{
    [SerializeField] private Animator shadowPersonAnimator;

    /// <summary>
    /// Invoked when the player is rotated properly.
    /// </summary>
    protected override void RunEvent()
    {
        shadowPersonAnimator.gameObject.SetActive(true);
        shadowPersonAnimator.SetTrigger("Dart");
    }
}
