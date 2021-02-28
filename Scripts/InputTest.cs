using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    public GameObject rController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Transform rControllerTransform = rController.GetComponent<Transform>();
        float controllerToTableY = rControllerTransform.position.y;
        Transform tableTransform = GetComponent<Transform>();
        float tableScaleY = tableTransform.localScale.y;
        
        if(OVRInput.Get(OVRInput.RawButton.A))
        {
            tableTransform.position = (new Vector3(tableTransform.position.x, controllerToTableY-(tableScaleY/2f), tableTransform.position.z));
        }
        /*if(OVRInput.Get(OVRInput.RawButton.A))
        {
            Debug.Log("Moving Table");
            tableTransform.transform.Translate(new Vector3(tableTransform.position.x, 0.005f, tableTransform.position.z));
        }
        if (OVRInput.Get(OVRInput.RawButton.B))
        {
            Debug.Log("Moving Table");
            tableTransform.transform.Translate(new Vector3(tableTransform.position.x, -0.005f, tableTransform.position.z));
        }*/
    }
}
