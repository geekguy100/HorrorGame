/*****************************************************************************
// File Name :         ShadowPerson.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class ShadowPerson : MonoBehaviour
{
    /// <summary>
    /// Disables the GameObject after a given time.
    /// </summary>
    /// <param name="time">The time to wait before disabling the game object (in seconds).</param>
    public void SetInactiveAfterTime(float time)
    {
        StartCoroutine(SetInactive(time));
    }

    private IEnumerator SetInactive(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
