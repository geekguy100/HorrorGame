/*****************************************************************************
// File Name :         RestroomMirror.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Behaviour for interacting with the restroom mirrors
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class RestroomMirror : MonoBehaviour, IInteractable
{
    private bool displayingUI = false;
    private GameObject interactor;
    private bool teleporting = false;

    [Tooltip("The time to wait in seconds before teleporting the interactor.")]
    [SerializeField] private float timeBeforeTeleport = 2f;

    [SerializeField] private AudioClip teleportSound;

    public void InRangeAction(GameObject interactor)
    {
        // TODO: Highlight the mirror.
        this.interactor = interactor;
    }

    /// <summary>
    /// Invoked when the player interacts with the mirror.
    /// </summary>
    public void Interact(GameObject interactor)
    {
        if (teleporting)
            return;

        print("Interacted with the mirror.");
        displayingUI = EventManager.MirrorInteracted(!displayingUI);
    }

    /// <summary>
    /// Invoked when the player leaves the mirror's proximity.
    /// </summary>
    public void OutOfRangeAction(GameObject interactor)
    {
        displayingUI = EventManager.MirrorInteracted(false);
        interactor = null;
    }

    #region --- Button Clicking ---
    /// <summary>
    /// Initiates the teleportation sequence.
    /// </summary>
    public void Teleport(Transform teleportTransform)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerInput>().enabled = false;
        player.transform.position = teleportTransform.position;
        player.GetComponent<PlayerInput>().enabled = true;
    }
    
    #endregion
}