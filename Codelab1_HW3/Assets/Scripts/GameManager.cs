using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //cache
    private AudioManager audiomanager;
    void Start()
    {
        audiomanager=AudioManager.instance;
        if (audiomanager == null)
        {
            Debug.LogError("WHAT ARE YOU DOING?! No AudioManager found in this scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
