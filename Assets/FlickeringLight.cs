/*****************************************************************************
// File Name :         FlickeringLight.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] flickeringSounds;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void FlickerLight()
    {
        AudioClip clip = AudioClipHepler.GetRandomAudioClipFromSet(flickeringSounds);

        audioSource.PlayOneShot(clip);
    }
}
