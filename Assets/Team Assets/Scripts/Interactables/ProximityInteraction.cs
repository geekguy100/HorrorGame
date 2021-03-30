/*****************************************************************************
// File Name :         ProximityInteraction.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Enables interaction with nearby IInteractables.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(IInteractor))]
public class ProximityInteraction : MonoBehaviour
{
    private IInteractor interactor = null;

    private void Awake()
    {
        interactor = GetComponent<IInteractor>();
    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    // If we walking into an IInteractable, let us be able to interact with it.
    //    IInteractable interactable = col.GetComponent<IInteractable>();
    //    if (interactable != null)
    //    {
    //        interactor.SetInteractable(interactable);
    //    }
    //}

    private void OnTriggerStay(Collider col)
    {
        if (interactor.GetInteractable() != null)
            return;

        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactor.SetInteractable(interactable);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        // If we walk away from the interactable we were able to interact with it,
        // make sure we set it back to null so we can't interact with it from a distance.
        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null && interactable == interactor.GetInteractable())
        {
            interactor.UnassignInteractable();
        }
    }
}
