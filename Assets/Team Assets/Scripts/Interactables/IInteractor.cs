/*****************************************************************************
// File Name :         IInteractor.cs
// Author :            Kyle Grenier
// Creation Date :     03/26/2021
//
// Brief Description : Creates a contract for a GameObject that interacts with IInteractables.
*****************************************************************************/
using UnityEngine;

public abstract class IInteractor : MonoBehaviour
{
    // The interactable we're working with.
    private IInteractable interactable;

    /// <summary>
    /// Sets the interactable we'll be interacting with.
    /// </summary>
    /// <param name="interactable">The IInteractable to interact with.</param>
    public void SetInteractable(IInteractable interactable)
    {
        this.interactable = interactable;
        interactable.InRangeAction(gameObject);
    }

    /// <summary>
    /// Returns the IInteractable we're interacting with.
    /// </summary>
    /// <returns>The IInteractable we're interacting with.</returns>
    public IInteractable GetInteractable()
    {
        return interactable;
    }

    /// <summary>
    /// Sets the interactable to null.
    /// </summary>
    public void UnassignInteractable()
    {
        interactable.OutOfRangeAction(gameObject);
        interactable = null;
    }

    /// <summary>
    /// Interact with the currently assigned interactable.
    /// </summary>
    public void PerformInteraction()
    {
        interactable?.Interact(gameObject);
    }
}
