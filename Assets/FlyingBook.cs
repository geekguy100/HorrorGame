/*****************************************************************************
// File Name :         FlyingBook.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;

public class FlyingBook : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHit(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
