/*****************************************************************************
// File Name :         SpawnMonsterSound.cs
// Author :            Kyle Grenier
// Creation Date :     03/15/2021
//
// Brief Description : Spawns the monster's footsteps above the player at a random time.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class SpawnMonsterSound : MonoBehaviour
{
    [Header("Min and Max Times for Randomly Spawning Sound.")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [Header("Fade Duration")]
    [Tooltip("How many seconds it takes to fade out the audio.")]
    [SerializeField] private float fadeDuration;

    [Header("Monster Footsteps Prefab")]
    [SerializeField] private GameObject monsterFootsteps;

    private AudioSource audioSource;


    private void Start()
    {
        StartCoroutine(PlaySoundAfterRandomTime());
    }

    /// <summary>
    /// Plays the monster footstep sound after a randomly selected time within the bounds.
    /// </summary>
    private IEnumerator PlaySoundAfterRandomTime()
    {
        float time = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(time);

        SpawnSFX();

        // Plays the sound for 15 seconds, then fades out,
        // then the process restarts.
        yield return new WaitForSeconds(15f);
        StartCoroutine(FadeOut());
    }

    /// <summary>
    /// Spawns in the monster SFX above the player's location.
    /// </summary>
    private void SpawnSFX()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        GameObject sfx = Instantiate(monsterFootsteps, playerPos + Vector3.up * 5f, Quaternion.identity);
        audioSource = sfx.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Fades out the audio source's volume over a duration of time,
    /// then starts the PlaySoundAfterRandomTime coroutine again.
    /// </summary>
    private IEnumerator FadeOut()
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        // Just to make sure we don't call upon an old audioSource, let's
        // destroy it and set the audioSource to null.
        Destroy(audioSource.gameObject);
        audioSource = null;

        StartCoroutine(PlaySoundAfterRandomTime());
    }
}
