/*****************************************************************************
// File Name :         PlayerInteractionHandler.cs
// Author :            Kyle Grenier
// Creation Date :     03/26/2021
//
// Brief Description : Handles performing interactions as the player.
*****************************************************************************/
using UnityEngine;

public class PlayerInteractionHandler : IInteractor
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GetInteractable() != null)
        {
            PerformInteraction();
        }
    }
}