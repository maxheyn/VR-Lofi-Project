using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSwapper : MonoBehaviour
{
    public GameObject hand;
    public GameObject handMesh;
    public Material[] colors = new Material[3];
    private MeshRenderer meshRenderer;
    private int i = 0;
    private float timer = 0.0f;
    private float waitTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = colors[0];
    }

    // Update is called once per frame
    void Update()
    {
        Renderer handRenderer = handMesh.GetComponent<SkinnedMeshRenderer>();
        timer += Time.deltaTime;
        meshRenderer = GetComponent<MeshRenderer>();
        Transform handTransform = hand.GetComponent<Transform>();
        Transform pencilTransform = GetComponent<Transform>();
        
        pencilTransform.position = handTransform.position;
        pencilTransform.rotation = handTransform.rotation;
        pencilTransform.Rotate(190f, 0f, 0f);

        // if (timer > waitTime)
        // {
        //     if(OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0)
        //     {
        //         meshRenderer.material = colors[i];
        //         i++;
        //         if (i == 3)
        //             i = 0;
        //         timer = 0.0f;
        //     }
        //     if (OVRInput.Get(OVRInput.RawButton.B))
        //     {
        //         if (handRenderer.enabled == false) {
        //             handRenderer.enabled = true;
        //             GetComponent<MeshRenderer>().enabled = false;
        //         }
        //         else {
        //             handRenderer.enabled = false;
        //             GetComponent<MeshRenderer>().enabled = true;
        //         }
        //         timer = 0.0f;
        //     }
        // }

    }
}
