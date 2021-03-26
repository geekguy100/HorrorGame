/*****************************************************************************
// File Name :         VolumeHandler.cs
// Author :            Kyle Grenier
// Creation Date :     03/26/2021
//
// Brief Description : Handles updating field of the current volume.
*****************************************************************************/
using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public static class VolumeHandler
{
    private static Volume currentVolume = null;

    private static Fog fog = null;
    
    /// <summary>
    /// Updates the current Volume.
    /// </summary>
    /// <param name="volumeObject">The GameObject holding the Volume component.</param>
    public static void SetVolume(GameObject volumeObject)
    {
        Volume v = volumeObject.GetComponent<Volume>();
        if (v == null)
            return;

        currentVolume = v;

        // If there is no fog, set it to null.
        if (!currentVolume.profile.TryGet(out fog))
            fog = null;
    }

    public static bool HasVolume()
    {
        return currentVolume != null;
    }

    /// <summary>
    /// Updates the fog's attenuation distance to the given value if
    /// the fog override exists on the current volume.
    /// </summary>
    /// <param name="value">The value to update the fog's attenuation distance to.</param>
    public static void SetFogDepth(float value)
    {
        if (fog != null)
            fog.meanFreePath.value = value;
        else
            Debug.Log("VOLUME: Did not set depth... fog is null.");
    }

    /// <summary>
    /// Returns the fog's attenuation distance. -1 if fog is null.
    /// </summary>
    /// <returns>The fog's attenuation distance or -1 if the fog is null.</returns>
    public static float GetFogDepth()
    {
        if (fog != null)
            return fog.meanFreePath.value;
        else
            return -1;
    }
}