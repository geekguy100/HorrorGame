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

    private Animator anim;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        float time = Random.Range(0, 1f);
        anim.Play("Chapel_Spotlight", 0, time);
    }

    public void FlickerLight()
    {
        AudioClip clip = AudioClipHepler.GetRandomAudioClipFromSet(flickeringSounds);

        audioSource.PlayOneShot(clip);
    }
}
