
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public static AudioManager instance;
    [SerializeField] 
    
    public Sound[] sounds;

    private void Awake()
    {
        if (GetInstanceID() != null)
        {
            Debug.LogError("More than 1 AudioManager in the scene.");
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    
    
    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_"+ i +"_" +sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
        //PlaySound("Respawn"); 
    }

    //create a method for creating the sound

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)//check which track it is, play the first song with that name
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return; //exit out of the loop
            }
        }
        //no sound with _name
        Debug.LogWarning("AudioManager: Sound not found in sound list:," + _name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
