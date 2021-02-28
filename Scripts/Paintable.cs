using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Paintable : MonoBehaviour
{
    public GameObject brush;
    public static float brushSize = 0.15f;
    public RenderTexture rt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButton(0))
        // {
        //     var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if (Physics.Raycast(Ray, out hit))
        //     {
        //         var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
        //         go.transform.localScale = Vector3.one * brushSize;
        //     }
        // }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "pencil")
        {
            if (OVRInput.Get(OVRInput.RawButton.B) || OVRInput.Get(OVRInput.RawButton.Y))
            {
                Debug.Log("hitting pencil");
                Vector3 closestPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
                Vector3 pointToDrawAt = new Vector3(closestPoint.x, GameObject.Find("drawPage").transform.position.y + 0.001f, closestPoint.z);
                var paint = Instantiate(brush, pointToDrawAt, Quaternion.identity, transform);
                paint.transform.localScale = Vector3.one * brushSize;
            }
            
        }
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
        texture2d.ReadPixels(new Rect(0,0, rt.width, rt.height), 0, 0);
        texture2d.Apply();

        var data = texture2d.EncodeToPNG();

        File.WriteAllBytes(Application.streamingAssetsPath + "/Notes/savedNotes.png", data);

    }
}
