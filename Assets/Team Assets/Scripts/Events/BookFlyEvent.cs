/*****************************************************************************
// File Name :         BookFlyEvent.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;

public class BookFlyEvent : MonoBehaviour, InGameEvent
{
    [SerializeField] private Animator bookAnim;
    [SerializeField] private AudioClip audioClip;

    public bool Execute(GameObject player)
    {
        bookAnim.gameObject.SetActive(true);
        bookAnim.SetTrigger("Launch");
        EventAudioManager.instance.PlayOneShot(audioClip);
        return true;
    }
}
