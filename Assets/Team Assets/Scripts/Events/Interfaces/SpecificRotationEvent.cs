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

    [Tooltip("How 'uncentered' the player's rotation can be from the required rotation; A higher value means" +
        " the player's rotation can be more uncentered / less on point.")]
    [SerializeField] private float rotationForgiveness = 7f;

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

        Vector3 rot = playerCamera.rotation.eulerAngles;
        //if (rot.x < 0)
        //    rot.x += 360f;
        //if (rot.y < 0)
        //    rot.y += 360f;
        //if (rot.z < 0)
        //    rot.z += 360f;

        float distance = Vector3.Distance(rot, requiredRotation);

        Vector3 rot2 = requiredRotation;
        rot2.x += 360f;
        rot2.y += 360f;
        rot2.z += 360f;

        float distance2 = Vector3.Distance(rot, rot2);
        print(distance2);

        if (distance < rotationForgiveness || distance2 < rotationForgiveness)
        {
            RunEvent(player);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Invoked when the player is rotated properly;
    /// what the event does.
    /// </summary>
    protected abstract void RunEvent(GameObject player);
}