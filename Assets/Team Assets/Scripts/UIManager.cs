/*****************************************************************************
// File Name :         UIManager.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Class to handle updating UI.
*****************************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Tooltip("The UI panel that displays the list of locations to teleport to.")]
    [SerializeField] private GameObject teleportPanel;

    [SerializeField] private TextMeshProUGUI pageNotification;
    [SerializeField] private TextMeshProUGUI winText;

    private bool teleporting = false;


    private List<UIWindow> openWindows = new List<UIWindow>();


    #region --- Subscribing and Unsubscribing to Events ---
    private void OnEnable()
    {
        EventManager.OnMirrorInteracted += ToggleTeleportUI;
        EventManager.OnOpenUIWindow += AddOpenWindow;
        EventManager.OnCloseUIWindow += RemoveOpenWindow;
        EventManager.OnPagePickup += TogglePageNotification;

        EventManager.OnJournalComplete += ToggleWinText;

        EventManager.OnMirrorTeleport += OnTeleport;
        EventManager.OnTeleportEnd += OnTeleportEnd;
    }

    private void OnDisable()
    {
        EventManager.OnMirrorInteracted -= ToggleTeleportUI;
        EventManager.OnOpenUIWindow -= AddOpenWindow;
        EventManager.OnCloseUIWindow -= RemoveOpenWindow;
        EventManager.OnPagePickup -= TogglePageNotification;

        EventManager.OnJournalComplete -= ToggleWinText;

        EventManager.OnMirrorTeleport -= OnTeleport;
        EventManager.OnTeleportEnd -= OnTeleportEnd;
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

    private void OnTeleport()
    {
        ToggleTeleportUI(false);
        teleporting = true;
    }

    private void OnTeleportEnd()
    {
        teleporting = false;
    }

    /// <summary>
    /// Toggles displaying the teleport UI and locks/unlocks the cursor.
    /// </summary>
    /// <param name="turnOn">True if the UI should be enabled.</param>
    /// <returns>True if the mirror UI was enabled.</returns>
    private bool ToggleTeleportUI(bool turnOn)
    {
        if (teleporting)
            return false;

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

    private void TogglePageNotification(JournalPage page)
    {
        pageNotification.text = "Collected Page " + page.id;
        pageNotification.gameObject.SetActive(true);
        StartCoroutine(WaitThenDisable(pageNotification.gameObject, 2f));
    }

    private void ToggleWinText()
    {
        winText.gameObject.SetActive(true);
        StartCoroutine(WaitThenDisable(winText.gameObject, 5f));
    }

    private IEnumerator WaitThenDisable(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
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