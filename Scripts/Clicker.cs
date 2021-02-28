using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class Clicker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lightGO;
    public GameObject handsPointer;
    public RenderTexture rt;
    public AudioSource songController;
    public AudioClip[] songs;
    Color[] colors = new Color[9];
    int i = 0;
    private float timer = 0.0f;
    private float waitTime = 0.25f;
    private bool rightHanded = true;
    private int songsIndex = 0;
    private AudioSource src;
    Transform handTransform;
    Transform pencilTransform;
    
    void Start()
    {
        src = songController.GetComponent<AudioSource>();
        pencilTransform = GameObject.Find("pencil").GetComponent<Transform>();
        handTransform = GameObject.Find("CustomHandRight").GetComponent<Transform>();
        pencilTransform.position = handTransform.position;
        pencilTransform.rotation = handTransform.rotation;
        pencilTransform.Rotate(190f, 0f, 0f);
        rightHanded = true;
        colors[0] = Color.white;
        colors[1] = Color.black;
        colors[2] = Color.red;
        colors[3] = Color.yellow;
        colors[4] = Color.green;
        colors[5] = Color.blue;
        colors[6] = Color.cyan;
        colors[7] = Color.magenta;
        colors[8] = Color.gray;
        GameObject.Find("hands:Lhand").GetComponent<SkinnedMeshRenderer>().enabled = true;
        GameObject.Find("hands:Rhand").GetComponent<SkinnedMeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        pencilTransform.position = handTransform.position;
        pencilTransform.rotation = handTransform.rotation;
        pencilTransform.Rotate(190f, 0f, 0f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "buttonLights")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                Light lightComp = lightGO.GetComponent<Light>();
                if (OVRInput.Get(OVRInput.RawButton.A))
                {
                    other.GetComponent<MeshRenderer>().material.color = Color.cyan;

                    if (i < 8)
                    {
                        lightComp.color = Color.Lerp(colors[i], colors[i + 1], Mathf.PingPong(Time.time, 1));
                        i++;
                    }
                    if (i == 8)
                    {
                        lightComp.color = Color.Lerp(colors[8], colors[0], Mathf.PingPong(Time.time, 1));
                        i = 0;
                    }
                }
                if (OVRInput.Get(OVRInput.RawButton.B))
                {
                    other.GetComponent<MeshRenderer>().material.color = Color.cyan;

                    lightComp.color = Color.white;
                }
                timer = 0.0f;
            }   
        }
        else if (other.name == "buttonNotes+")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;

            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;

                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    GameObject.Find("Clipboard_Notes").GetComponent<Transform>().localScale += new Vector3(0.1f, 0.1f, 0.1f);
                    timer = 0.0f;
                }
            }

        }
        else if (other.name == "buttonNotes-")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;

            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;

                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    GameObject.Find("Clipboard_Notes").GetComponent<Transform>().localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                    timer = 0.0f;
                }
            }

        }
        else if (other.name == "buttonTips+")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;

            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;

                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    GameObject.Find("Clipboard_Tips").GetComponent<Transform>().localScale += new Vector3(0.1f, 0.1f, 0.1f);
                    timer = 0.0f;
                }
            }

        }
        else if (other.name == "buttonTips-")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;

            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;

                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    GameObject.Find("Clipboard_Tips").GetComponent<Transform>().localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                    timer = 0.0f;
                }
            }
        }
        else if (other.name == "buttonSwapHands")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;

            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    if (!rightHanded)
                    {
                        pencilTransform = GameObject.Find("pencil").GetComponent<Transform>();
                        handTransform = GameObject.Find("CustomHandRight").GetComponent<Transform>();
                        rightHanded = true;
                        timer = 0.0f;
                        Debug.Log("Set to Right Handed");
                        GameObject.Find("hands:Lhand").GetComponent<SkinnedMeshRenderer>().enabled = true;
                        GameObject.Find("hands:Rhand").GetComponent<SkinnedMeshRenderer>().enabled = false;
                    }
                    else
                    {
                        pencilTransform = GameObject.Find("pencil").GetComponent<Transform>();
                        handTransform = GameObject.Find("CustomHandLeft").GetComponent<Transform>();
                        rightHanded = false;
                        timer = 0.0f;
                        Debug.Log("Set to Left Handed");
                        GameObject.Find("hands:Lhand").GetComponent<SkinnedMeshRenderer>().enabled = false;
                        GameObject.Find("hands:Rhand").GetComponent<SkinnedMeshRenderer>().enabled = true;
                    }
                }
            }
        }
        else if (other.name == "buttonBSize+")
        {other.GetComponent<MeshRenderer>().material.color = Color.gray;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    Paintable.brushSize += 0.05f;
                    timer = 0.0f;
                }
            }
        }
        else if (other.name == "buttonBSize-")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    if ((Paintable.brushSize - 0.05f) > 0.0f) 
                        Paintable.brushSize -= 0.05f;
                    timer = 0.0f;
                }
            }
        }
        else if (other.name == "buttonSaveImage")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    Save();
                    timer = 0.0f;
                }
            }
        }
        else if (other.name == "buttonStartMusic")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    src.Play();
                    timer = 0.0f;
                }
            }
        }
        else if (other.name == "buttonStopMusic")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    src.Pause();
                    timer = 0.0f;
                }
            }
        }
        else if (other.name == "buttonVolumeUp")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    src.volume += 0.05f;
                    timer = 0.0f;
                }
            }
        }
        else if (other.name == "buttonVolumeDown")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    src.volume -= 0.05f;
                    timer = 0.0f;
                }
            }
        }
        else if (other.name == "buttonPrevSong")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    if(songsIndex == 0)
                        songsIndex = songs.Length-1;
                    else
                        songsIndex -= 1;
                    src.clip = songs[songsIndex];
                    src.Play();
                    timer = 0.0f;
                }
            }
        }
        else if (other.name == "buttonNextSong")
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                other.GetComponent<MeshRenderer>().material.color = Color.cyan;
                timer += Time.deltaTime;
                if (timer > waitTime)
                {
                    if(songsIndex == songs.Length - 1)
                        songsIndex = 0;
                    else
                        songsIndex += 1;
                    src.clip = songs[songsIndex];
                    src.Play();
                    timer = 0.0f;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public void Save()
    {
        StartCoroutine(CoSave());
    }

    private IEnumerator CoSave()
    {
        yield return new WaitForEndOfFrame();

        Debug.Log(Application.dataPath);
        RenderTexture.active = rt;
        var texture2d = new Texture2D(rt.width, rt.height);
        texture2d.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        texture2d.Apply();

        var data = texture2d.EncodeToPNG();

        File.WriteAllBytes(Application.streamingAssetsPath + "/Notes/savedNotes.png", data);
        Debug.Log("saved image!");

    }
}
