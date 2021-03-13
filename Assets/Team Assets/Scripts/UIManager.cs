/*****************************************************************************
// File Name :         UIManager.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Class to handle updating UI.
*****************************************************************************/
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Tooltip("The UI panel that displays the list of locations to teleport to.")]
    [SerializeField] private GameObject teleportPanel;

    #region --- Subscribing and Unsubscribing to Events ---
    private void OnEnable()
    {
        EventManager.OnMirrorInteracted += ToggleTeleportUI;
    }

    private void OnDisable()
    {
        EventManager.OnMirrorInteracted -= ToggleTeleportUI;
    }

    #endregion

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
    /// Displays information on the item the player picked up.
    /// </summary>
    /// <param name="interactable">The item the player picked up.</param>
    private void DisplayItemInfo(IInteractable interactable)
    {
        throw new System.NotImplementedException();
    }
}
