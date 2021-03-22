/*****************************************************************************
// File Name :         InGameEvent.cs
// Author :            Kyle Grenier
// Creation Date :     03/22/2021
//
// Brief Description : Defines the contract for creating an in game event.
*****************************************************************************/
using UnityEngine;

public interface InGameEvent
{
    bool Execute(GameObject player);
}