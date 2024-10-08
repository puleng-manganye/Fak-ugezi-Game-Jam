using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

#region Class Description:
/*
 * 
 */
#endregion

public class VolumeSettings : MonoBehaviour
{
    #region Fields
    
    // Audio mixer component
    public AudioMixer audioMixer;
    
    #endregion

    #region Set volume
    
    //This function is called when we adjust the volume slider.
    public void SetMusicVolume (float musicVolume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSpatialVolume (float spatialVolume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("SpatialVolume", spatialVolume);
    }
    
    public void SetSfxVolume (float sfxVolume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("SfxVolume", sfxVolume);
    }
    #endregion
}
