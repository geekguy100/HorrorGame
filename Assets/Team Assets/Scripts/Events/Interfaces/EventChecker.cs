/*****************************************************************************
// File Name :         EventChecker.cs
// Author :            Kyle Grenier
// Creation Date :     03/22/2021
//
// Brief Description : Checks to see if the player is inside of the event trigger and invokes the event if they are.
*****************************************************************************/
using UnityEngine;

public class EventChecker : MonoBehaviour
{
    private InGameEvent gameEvent;
    private GameObject player = null;

    private void Awake()
    {
        gameEvent = GetComponent<InGameEvent>();
        if (gameEvent == null)
        {
            Debug.LogWarning(gameObject.name + ": No InGameEvent component attached to this event checker. Deleting game object...");
            Destroy(gameObject);
        }
    }

    // --- No OnTriggerStay ---
    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.CompareTag("Player"))
    //        player = col.gameObject;
    //}

    //private void OnTriggerExit(Collider col)
    //{
    //    if (col.CompareTag("Player"))
    //        player = null;
    //}

    //private void Update()
    //{
    //    if (player != null)
    //    {
    //        bool executed = gameEvent.Execute(player);

    //        if(executed)
    //            Destroy(gameObject);
    //    }
    //}

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            bool executed = gameEvent.Execute(col.gameObject);

            // If the event executed successfully, destroy this game object.
            if (executed)
                Destroy(gameObject);
        }
    }
}
