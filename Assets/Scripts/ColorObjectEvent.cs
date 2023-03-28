using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ColorObjectEvent : MonoBehaviour
{
    private ColorManager colorManager;
    private Rigidbody body;
    private UnityEngine.Color ccolor;
    private string scolor;
    // Start is called before the first frame update
    void Start()
    {
        scolor = gameObject.tag;
        if (ColorUtility.TryParseHtmlString(scolor, out ccolor))
        {
            Debug.Log("Color value: " + ccolor);
        }
        else
        {
            Debug.LogError("Failed to parse color: " + scolor);
        }
        colorManager = FindObjectOfType<ColorManager>();
        colorManager.colorEvent.AddListener(OnColorEvent);

        body = GetComponent<Rigidbody>();
    }
    void OnColorEvent(string color)
    {
        if (color == gameObject.tag)
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.color = ccolor;
            body.isKinematic = false;
            Debug.Log("Event data: " + color);
        } else if (color == "None")
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.color = ccolor;
            body.isKinematic = false;
        }
        else
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.color = UnityEngine.Color.black;
            body.isKinematic = true;
        }
    }
}
