using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class StudyTip : MonoBehaviour
{
    string[] tips = new string[10];
    TMP_Text textObject;
    int index = 0;
    private float timer = 0f;
    private float waitTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        tips[0] = "Give yourself enough time to study";
        tips[1] = "Organize your study space";
        tips[2] = "Use flow charts and diagrams";
        tips[3] = "Practice on old exams";
        tips[4] = "Explain your answers to others";
        tips[5] = "Organize study groups with friends";
        tips[6] = "Take regular breaks";
        tips[7] = "Snack on brain food";
        tips[8] = "Plan your exam day";
        tips[9] = "Drink plenty of water";
        // textObject = GetComponent<TMP_Text>();
        // textObject.text = "TESTING1";

        // Debug.Log("textObject.text: " + textObject.text);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            textObject = GetComponent<TMP_Text>();
            textObject.text = "Study Tips\n\n" + tips[index];
            if (index < tips.Length - 1)
                index++;
            else
                index = 0;
            timer = 0f;
        }

    }
}
