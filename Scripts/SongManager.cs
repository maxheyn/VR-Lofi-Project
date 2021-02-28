using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{   
    public AudioSource songController;
    public AudioClip[] songs;
    private int index = 0;
    private AudioSource src;

    private float timer = 0f;
    private float timeWait = 0.25f;
    //String[] tips = new String[10];

    // Start is called before the first frame update
    void Start()
    {
        src = songController.GetComponent<AudioSource>();
        src.clip = songs[0];
        src.Play();
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeWait) 
        {
            if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > 0) //button is hit
            {
                src.Stop();
                src.clip = songs[index];
                src.Play();
                if (index < songs.Length - 1)
                    index++;
                else   
                    index = 0;
            }
        timer = 0f;
        }
    }
}
