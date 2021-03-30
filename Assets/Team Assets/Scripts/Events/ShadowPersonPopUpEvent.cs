/*****************************************************************************
// File Name :         ShadowPersonPopUpEvent.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;

public class ShadowPersonPopUpEvent : SpecificRotationEvent
{
    [SerializeField] private GameObject shadowPersonPrefab;
    [SerializeField] private float offset;

    [SerializeField] private AudioClip moanSFX;

    [Tooltip("The time in seconds the shadow person will stay on screen.")]
    [SerializeField] private float waitTime = 0.25f;

    protected override void RunEvent(GameObject player)
    {
        Vector3 pos = player.transform.position + player.transform.forward * offset;
        ShadowPerson sp = Instantiate(shadowPersonPrefab, pos, shadowPersonPrefab.transform.rotation).GetComponent<ShadowPerson>();
        sp.SetInactiveAfterTime(waitTime);
        EventAudioManager.instance.PlayOneShot(moanSFX);
    }
}
