/*****************************************************************************
// File Name :         Footsteps.cs
// Author :            Kyle Grenier
// Creation Date :     03/12/2021
//
// Brief Description : Footstep sounds for character movement.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour
{
    [Tooltip("The array of possible footstep sounds to play.")]
    [SerializeField] private AudioClip[] footstepClips;

    [Tooltip("The CharacterMovement script of the character's footsteps to play.")]
    [SerializeField] private CharacterMovement characterMovement;

    [Tooltip("The required distance to have traveled before playing a footstep sound.")]
    [SerializeField] private float requiredDistance = 1f;

    [Tooltip("The AudioSource to play the footstep sounds.")]
    [SerializeField] private AudioSource audioSource;


    // The distance the character has traveled.
    private float distanceTraveled = 0f;

    //private void Update()
    //{
    //    if (characterMovement.IsMoving())
    //    {
    //        distanceTraveled += Time.deltaTime * characterMovement.GetSpeed();
    //        if (distanceTraveled > requiredDistance)
    //        {
    //            PlayRandomFootstep();
    //            distanceTraveled = 0f;
    //        }
    //    }
    //    else if (distanceTraveled != 0f)
    //        distanceTraveled = 0f;
    //}

    public void PlayRandomFootstep()
    {
        AudioClip clip = AudioClipHepler.GetRandomAudioClipFromSet(footstepClips);
        audioSource.PlayOneShot(clip);
    }
}
