
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //you need this in order to have a bunch of clips
//Usage: Have this attached to the listener
//Intent: To create a source from which we can attach and play all of the audio sources
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]//clamps the volume between 0 and 1
    public float volume =.7f;
    [Range (.5f,1.5f)]
    public float pitch= 1f;

    [Range(0,0.1f)]
    public float randomVolume = 0.1f;
 [Range(0f,.5f)]
    public float randomPitch = .1f;
    
    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip; //the audio clip will not change throughout the game
    }

    public void Play()
    {
        source.volume = volume*(1+Random.Range(-randomVolume/2f,randomVolume/2f)); 
        source.pitch = pitch*(1+ Random.Range(-randomPitch/2f, randomPitch/2f));
        source.Play();
    }
}
public class AudioManager : MonoBehaviour
{
    [SerializeField] 
    
    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
