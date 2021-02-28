using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageRenderer : MonoBehaviour

{

    Texture2D image = null;
    byte[] fileData;
    private Texture2D[] allImages;
    private float timer = 0.0f;
    private float waitTime = 0.25f;
    private int currImage = 0;
    void Start()
    {
        string m_Path = Application.streamingAssetsPath;
        m_Path += "/Images/";
        DirectoryInfo dir = new DirectoryInfo(m_Path);
        FileInfo[] files = dir.GetFiles("*.png");
        allImages = new Texture2D[files.Length];
        int count = 0;
        foreach(FileInfo file in files)
        {
            if(File.Exists(file.FullName))
            {
                fileData = File.ReadAllBytes(file.FullName);

                image = new Texture2D(2, 2, TextureFormat.ARGB32, false);
                allImages[count] = image;
                image.LoadImage(fileData);
                GetComponent<Renderer>().material.mainTexture = image;
            }
            else
            {
                Debug.Log("Files at " + file.FullName + " does not exist.");
            }
            count++;
        }
        GetComponent<Renderer>().material.mainTexture = allImages[0];

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            if (OVRInput.Get(OVRInput.RawButton.X))
            {
                GetComponent<Renderer>().material.mainTexture = allImages[currImage];
                if (currImage < allImages.Length - 1)
                    currImage++;
                else
                    currImage = 0;
            }
            timer = 0.0f;
        }
    }

    public Texture2D[] getImages()
    {
        return allImages;
    }
}
