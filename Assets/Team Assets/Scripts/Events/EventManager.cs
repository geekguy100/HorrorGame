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
    public static event Action OnJournalComplete;

    public static event Action<UIWindow> OnOpenUIWindow;
    public static event Action<UIWindow> OnCloseUIWindow;

    public static event Action OnTryQuitGame;

    public static event Action OnMirrorTeleport;
    public static event Action OnTeleportEnd;

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

    public static void OpenUIWindow(UIWindow window)
    {
        OnOpenUIWindow?.Invoke(window);
    }

    public static void CloseUIWindow(UIWindow window)
    {
        OnCloseUIWindow?.Invoke(window);
    }

    public static void TryQuitGame()
    {
        OnTryQuitGame?.Invoke();
    }

    public static void JournalComplete()
    {
        OnJournalComplete?.Invoke();
    }

    public static void MirrorTeleport()
    {
        OnMirrorTeleport?.Invoke();
    }

    public static void TeleportEnd()
    {
        OnTeleportEnd?.Invoke();
    }
}