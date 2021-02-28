using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public GameObject lightGO;
    public GameObject handsPointer;
    Color c0 = Color.cyan;
    Color c1 = Color.magenta;
    Color[] colors = new Color[9];
    int i = 0;
    private float timer = 0.0f;
    private float waitTime = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.white;
        colors[1] = Color.black;
        colors[2] = Color.red;
        colors[3] = Color.yellow;
        colors[4] = Color.green;
        colors[5] = Color.blue;
        colors[6] = Color.cyan;
        colors[7] = Color.magenta;
        colors[8] = Color.gray;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Light lightComp = lightGO.GetComponent<Light>();
            if(OVRInput.Get(OVRInput.RawButton.Y))
            {
                Debug.Log("i " +i);
                if (i < 8){
                    lightComp.color = Color.Lerp(colors[i], colors[i + 1], Mathf.PingPong(Time.time, 1));
                    i++;
                }
                if (i == 8){
                    lightComp.color = Color.Lerp(colors[8], colors[0], Mathf.PingPong(Time.time, 1));
                    i=0;
                }
            }
            if (OVRInput.Get(OVRInput.RawButton.LThumbstick))
            {
                lightComp.color = Color.white;
            }
            timer = 0.0f;
        }
    }
}
