/*****************************************************************************
// File Name :         DestroyOnStateExit.cs
// Author :            Kyle Grenier
// Creation Date :     03/24/2021
//
// Brief Description : Destroys the game object attached to the animator when the state exits.
*****************************************************************************/
using UnityEngine;

public class DestroyOnStateExit : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}
