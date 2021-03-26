/*****************************************************************************
// File Name :         SpecificRotationEvent.cs
// Author :            Kyle Grenier
// Creation Date :     03/22/2021
//
// Brief Description : An in game event that requires the player to be rotated specifically.
*****************************************************************************/
using UnityEngine;

public abstract class SpecificRotationEvent : MonoBehaviour, InGameEvent
{
    [Tooltip("The rotation required by the player to execute the event.")]
    [SerializeField] private Vector3 requiredRotation;

    // The camera attached to the player.
    private Transform playerCamera = null;

    /// <summary>
    /// Executes the event if the rotation condition has been met.
    /// </summary>
    /// <param name="player">The player game object.</param>
    /// <returns>True if the event's rotation condition has been met and the
    /// event was executed.</returns>
    public bool Execute(GameObject player)
    {
        if (playerCamera == null)
            playerCamera = player.transform.GetChild(0);

        float distance = Vector3.Distance(playerCamera.rotation.eulerAngles, requiredRotation);
        
        //print(distance);

        if (distance < 7f)
        {
            RunEvent();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Invoked when the player is rotated properly;
    /// what the event does.
    /// </summary>
    protected abstract void RunEvent();
}