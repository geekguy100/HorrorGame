/*****************************************************************************
// File Name :         EventManager.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Holds all of the game's events and handles invoking them.
*****************************************************************************/
using System;

public static class EventManager
{
    public static event Action<IInteractable> OnInteractableInteracted;
    public static event Predicate<bool> OnMirrorInteracted;

    public static event Action<JournalPage> OnPagePickup;

    /// <summary>
    /// Invoked when the player interacts with an IInteractable.
    /// </summary>
    /// <param name="interactable">The IInteractable the player interacted with.</param>
    public static void InteractableInteracted(IInteractable interactable)
    {
        OnInteractableInteracted?.Invoke(interactable);
    }

    /// <summary>
    /// Invoked when the player interacts with the mirror.
    /// </summary>
    /// <param name="turnOn">True if the mirror UI should be turned on.</param>
    /// <returns>True if the mirror UI was turned on.</returns>
    public static bool MirrorInteracted(bool turnOn)
    {
        if (OnMirrorInteracted != null)
            return OnMirrorInteracted.Invoke(turnOn);
        else
            return false;
    }

    public static void PagePickup(JournalPage page)
    {
        OnPagePickup?.Invoke(page);
    }
}