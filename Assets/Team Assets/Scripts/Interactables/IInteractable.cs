/*****************************************************************************
// File Name :         IInteractable.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Interface for all iteractables.
*****************************************************************************/
using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject interactor);
    void OutOfRangeAction(GameObject interactor);
    void InRangeAction(GameObject interactor);
}
