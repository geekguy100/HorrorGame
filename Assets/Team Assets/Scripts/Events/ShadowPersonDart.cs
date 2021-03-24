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
    [Tooltip("The Animator of the shadow person to dart.")]
    [SerializeField] private Animator shadowPersonAnimator;

    [Tooltip("The audio clip to play when the animation is played.")]
    [SerializeField] private AudioClip audioClip;

    /// <summary>
    /// Invoked when the player is rotated properly.
    /// </summary>
    protected override void RunEvent()
    {
        shadowPersonAnimator.gameObject.SetActive(true);
        shadowPersonAnimator.SetTrigger("Dart");
        EventAudioManager.instance.PlayOneShot(audioClip);
    }
}