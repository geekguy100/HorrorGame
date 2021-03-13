/*****************************************************************************
// File Name :         IOnOffInteractable.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : An IInteractable that turns off if the player leaves its proximity.
*****************************************************************************/
using UnityEngine;

public interface IOffInteractable : IInteractable
{
    void TurnOff();
}
