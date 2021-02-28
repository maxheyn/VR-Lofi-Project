using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingPencil : MonoBehaviour
{
    public GameObject drawImage; 
    Sprite drawableSprite;
    Texture2D drawableTexture;
    Color32[] colors = new Color32[3]; 
    void Start()
    {
        drawableSprite = drawImage.GetComponent<SpriteRenderer>().sprite;
        drawableTexture = drawableSprite.texture;
        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "pageDraw")
        {
            Vector2 closestPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            Debug.Log("Set Pixel at: " + "10" + ", " + "10");
        }
    }
}
