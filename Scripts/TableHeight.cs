using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHeight : MonoBehaviour
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
        float controllerToTableZ = rControllerTransform.position.z;
        Transform tableTransform = GetComponent<Transform>();
        float tableScaleY = tableTransform.localScale.y;
        float tableScaleZ = tableTransform.localScale.z;

        if (OVRInput.Get(OVRInput.RawButton.RThumbstick))
        {
            tableTransform.position = (new Vector3(tableTransform.position.x, controllerToTableY - (tableScaleY / 1.32f), controllerToTableZ - (tableScaleZ) + 1.5f));

        }
    }
}
