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

    [Tooltip("The time to wait in seconds before teleporting the interactor.")]
    [SerializeField] private float timeBeforeTeleport = 2f;

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
        StartCoroutine(TeleportToMirror(teleportTransform));
    }
    
    /// <summary>
    /// Teleports the interactor to the specified Transform's position.
    /// </summary>
    /// <param name="teleportTransform">The Transform to teleport to.</param>
    private IEnumerator TeleportToMirror(Transform teleportTransform)
    {
        // TODO: Fancy effects and whatnot.
        yield return new WaitForSeconds(timeBeforeTeleport);
        interactor.transform.position = teleportTransform.position;
    }
    #endregion
}