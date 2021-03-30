/*****************************************************************************
// File Name :         UIManager.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Class to handle updating UI.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [Tooltip("The UI panel that displays the list of locations to teleport to.")]
    [SerializeField] private GameObject teleportPanel;


    private List<UIWindow> openWindows = new List<UIWindow>();


    #region --- Subscribing and Unsubscribing to Events ---
    private void OnEnable()
    {
        EventManager.OnMirrorInteracted += ToggleTeleportUI;
        EventManager.OnOpenUIWindow += AddOpenWindow;
        EventManager.OnCloseUIWindow += RemoveOpenWindow;
    }

    private void OnDisable()
    {
        EventManager.OnMirrorInteracted -= ToggleTeleportUI;
        EventManager.OnOpenUIWindow -= AddOpenWindow;
        EventManager.OnCloseUIWindow -= RemoveOpenWindow;
    }

    #endregion

    private void Update()
    {
        // Close any open windows on ESC key press.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!CloseOpenWindow())
                EventManager.TryQuitGame();
        }
    }

    /// <summary>
    /// Toggles displaying the teleport UI and locks/unlocks the cursor.
    /// </summary>
    /// <param name="turnOn">True if the UI should be enabled.</param>
    /// <returns>True if the mirror UI was enabled.</returns>
    private bool ToggleTeleportUI(bool turnOn)
    {
        if (turnOn)
        {
            teleportPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return true;
        }
        else
        {
            teleportPanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            return false;
        }
    }

    /// <summary>
    /// Adds a window to the list of opened windows.
    /// </summary>
    /// <param name="window">The window to add.</param>
    private void AddOpenWindow(UIWindow window)
    {
        openWindows.Add(window);
    }

    /// <summary>
    /// Removes an open window from the list of open windows. Call this if you're closing a UIWindow outside
    /// of the UIManager.
    /// </summary>
    /// <param name="window">The window to remove.</param>
    private void RemoveOpenWindow(UIWindow window)
    {
        if (openWindows.Contains(window))
            openWindows.Remove(window);
    }

    /// <summary>
    /// Closes the most recently opened window.
    /// </summary>
    /// <returns>True if a window was closed.</returns>
    private bool CloseOpenWindow()
    {
        if (openWindows.Count > 0)
        {
            openWindows[openWindows.Count - 1].CloseWindow();
            return true;
        }

        return false;
    }
}