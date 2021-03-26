/*****************************************************************************
// File Name :         CubeTest.cs
// Author :            Kyle Grenier
// Creation Date :     03/26/2021
//
// Brief Description : Test cube interactable.
*****************************************************************************/
using UnityEngine;

public class CubeTest : MonoBehaviour, IInteractable
{
    public void InRangeAction(GameObject interactor)
    {
        print("LOOKING at CHUBE");
    }

    public void Interact(GameObject interactor)
    {
        print("INTERACTING WITH CUBE");
    }

    public void OutOfRangeAction(GameObject interactor)
    {
        print("CUBE AWAY NOW");
    }
}