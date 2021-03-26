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
    public void InRangeAction()
    {
        print("LOOKING at CHUBE");
    }

    public void Interact()
    {
        print("INTERACTING WITH CUBE");
    }

    public void TurnOff()
    {
        print("CUBE AWAY NOW");
    }
}
