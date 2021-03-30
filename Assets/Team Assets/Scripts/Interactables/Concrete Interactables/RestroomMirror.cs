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
        StartCoroutine(TeleportToMirror(teleportTransform));
    }
    
    /// <summary>
    /// Teleports the interactor to the specified Transform's position.
    /// </summary>
    /// <param name="teleportTransform">The Transform to teleport to.</param>
    private IEnumerator TeleportToMirror(Transform teleportTransform)
    {
        displayingUI = EventManager.MirrorInteracted(false);
        EventAudioManager.instance.PlayOneShot(teleportSound);
        teleporting = true;
        // TODO: Fancy effects and whatnot.

        float initialFogDepth = VolumeHandler.GetFogDepth();
        StartCoroutine(VolumeHandler.SetFogOverTime(1f, timeBeforeTeleport));
        yield return new WaitForSeconds(timeBeforeTeleport);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector3 pos = new Vector3(teleportTransform.position.x, player.transform.position.y, teleportTransform.position.z);
        player.transform.position = pos;

        StartCoroutine(VolumeHandler.SetFogOverTime(initialFogDepth, 3f));
        teleporting = false;
    }
    #endregion
}