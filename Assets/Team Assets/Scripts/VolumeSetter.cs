/*****************************************************************************
// File Name :         VolumeSetter.cs
// Author :            Kyle Grenier
// Creation Date :     03/26/2021
//
// Brief Description : Sets the volume the player walks into.
*****************************************************************************/
using UnityEngine;

public class VolumeSetter : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        // We collided with a volume.
        if (/*VolumeHandler.HasVolume() && */col.gameObject.CompareTag("Volume"))
        {
            VolumeHandler.SetVolume(col.gameObject);
        }
    }
}