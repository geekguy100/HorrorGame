/*****************************************************************************
// File Name :         PlayerInteraction.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Enables the player to interact with IInteractables.
*****************************************************************************/
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    IInteractable nearbyInteractable = null;

    private void OnTriggerEnter(Collider col)
    {
        // If we walking into an IInteractable, let us be able to interact with it.
        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null)
            nearbyInteractable = interactable;
    }

    private void OnTriggerExit(Collider col)
    {
        // If we walk away from the interactable we were able to interact with it,
        // make sure we set it back to null so we can't interact with it from a distance.
        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null && interactable == nearbyInteractable)
        {
            nearbyInteractable = null;

            // If the interactable we've been using is an IOffInteractable, make sure to turn it off
            // once we leave its proximity.
            IOffInteractable offInteractable = col.GetComponent<IOffInteractable>();
            if (offInteractable != null)
                offInteractable.TurnOff();
        }
    }

    private void Update()
    {
        // Interact with the interactable on key press.
        if (Input.GetKeyDown(KeyCode.E) && nearbyInteractable != null)
        {
            nearbyInteractable.Interact();
        }
    }
}
