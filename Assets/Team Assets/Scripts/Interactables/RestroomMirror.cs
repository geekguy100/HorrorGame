/*****************************************************************************
// File Name :         RestroomMirror.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Behaviour for interacting with the restroom mirrors
*****************************************************************************/
using UnityEngine;

public class RestroomMirror : MonoBehaviour, IOffInteractable
{
    private bool displayingUI = false;

    /// <summary>
    /// Invoked when the player interacts with the mirror.
    /// </summary>
    public void Interact()
    {
        print("Interacted with the mirror.");
        displayingUI = EventManager.MirrorInteracted(!displayingUI);
    }

    /// <summary>
    /// Invoked when the player leaves the mirror's proximity.
    /// </summary>
    public void TurnOff()
    {
        print("mirror off");
        displayingUI = EventManager.MirrorInteracted(false);
    }

    // TODO: Put button methods here.
}
