using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] colorObjects;
    GameObject[] redObjects;
    GameObject[] greenObjects;
    GameObject[] blueObjects;
    GameObject[] magentaObjects;
    GameObject[] cyanObjects;
    GameObject[] yellowObjects;
    private string nowQColor = "None";
    private string nowEColor = "None";
    private string nowColor = "None";

    public GameObject redPannelObjects;
    public GameObject greenPannelObjects;
    public GameObject bluePannelObjects;
    void Start()
    {
        redObjects = GameObject.FindGameObjectsWithTag("Red");
        greenObjects = GameObject.FindGameObjectsWithTag("Green");
        blueObjects = GameObject.FindGameObjectsWithTag("Blue");
        magentaObjects = GameObject.FindGameObjectsWithTag("Magenta");
        cyanObjects = GameObject.FindGameObjectsWithTag("Cyan");
        yellowObjects = GameObject.FindGameObjectsWithTag("Yellow");

        var list = new List<GameObject>();
        list.AddRange(redObjects);
        list.AddRange(greenObjects);
        list.AddRange(blueObjects);
        list.AddRange(magentaObjects);
        list.AddRange(cyanObjects);
        list.AddRange(yellowObjects);

        colorObjects = list.ToArray();
        Debug.Log(colorObjects.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (nowQColor)
            {
                case "None":
                    nowQColor = "Red";
                    break;
                case "Red":
                    nowQColor = "Green";
                    break;
                case "Green":
                    nowQColor = "Blue";
                    break;
                case "Blue":
                    nowQColor = "None";
                    break;
            }
            nowColor = ColorCheck(nowQColor, nowEColor);
            ColorActive(nowColor);

            Debug.Log(nowQColor + nowEColor + nowColor);
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            switch (nowEColor)
            {
                case "None":
                    nowEColor = "Red";
                    break;
                case "Red":
                    nowEColor = "Green";
                    break;
                case "Green":
                    nowEColor = "Blue";
                    break;
                case "Blue":
                    nowEColor = "None";
                    break;
            }
            nowColor = ColorCheck(nowQColor, nowEColor);
            ColorActive(nowColor);

            Debug.Log(nowQColor + nowEColor + nowColor);
        }
    }
    private string ColorCheck(string qColor, string eColor)
    {
        string color = "None";
        switch (eColor)
        {
            case "None":
                switch (qColor)
                {
                    case "None":
                        color = "None";
                        break;
                    case "Red":
                        color = "Red";
                        break;
                    case "Green":
                        color = "Green";
                        break;
                    case "Blue":
                        color = "Blue";
                        break;
                }
                break;
            case "Red":
                switch (qColor)
                {
                    case "None":
                        color = "Red";
                        break;
                    case "Red":
                        color = "Red";
                        break;
                    case "Green":
                        color = "Yellow";
                        break;
                    case "Blue":
                        color = "Magenta";
                        break;
                }
                break;
            case "Green":
                switch (qColor)
                {
                    case "None":
                        color = "Green";
                        break;
                    case "Red":
                        color = "Yellow";
                        break;
                    case "Green":
                        color = "Green";
                        break;
                    case "Blue":
                        color = "Cyan";
                        break;
                }
                break;
            case "Blue":
                switch (qColor)
                {
                    case "None":
                        color = "Blue";
                        break;
                    case "Red":
                        color = "Magenta";
                        break;
                    case "Green":
                        color = "Cyan";
                        break;
                    case "Blue":
                        color = "Blue";
                        break;
                }
                break;
        }
        return color;
    }
    private void ColorActive(string color)
    {
        foreach (GameObject obj in colorObjects)
        {
            obj.SetActive(false);
        }
        redPannelObjects.SetActive(false);
        greenPannelObjects.SetActive(false);
        bluePannelObjects.SetActive(false);
        switch (color)
        {
            case "None":
                foreach (GameObject obj in colorObjects)
                {
                    obj.SetActive(true);
                }
                break;
            case "Red":
                foreach (GameObject obj in redObjects)
                {
                    obj.SetActive(true);
                }
                redPannelObjects.SetActive(true);
                greenPannelObjects.SetActive(false);
                bluePannelObjects.SetActive(false);
                break;
            case "Green":
                foreach (GameObject obj in greenObjects)
                {
                    obj.SetActive(true);
                }
                redPannelObjects.SetActive(false);
                greenPannelObjects.SetActive(true);
                bluePannelObjects.SetActive(false);
                break;
            case "Blue":
                foreach (GameObject obj in blueObjects)
                {
                    obj.SetActive(true);
                }
                redPannelObjects.SetActive(false);
                greenPannelObjects.SetActive(false);
                bluePannelObjects.SetActive(true);
                break;
            case "Magenta":
                foreach (GameObject obj in magentaObjects)
                {
                    obj.SetActive(true);
                }
                redPannelObjects.SetActive(true);
                greenPannelObjects.SetActive(false);
                bluePannelObjects.SetActive(true);
                break;
            case "Cyan":
                foreach (GameObject obj in cyanObjects)
                {
                    obj.SetActive(true);
                }
                redPannelObjects.SetActive(false);
                greenPannelObjects.SetActive(true);
                bluePannelObjects.SetActive(true);
                break;
            case "Yellow":
                foreach (GameObject obj in yellowObjects)
                {
                    obj.SetActive(true);
                }
                redPannelObjects.SetActive(true);
                greenPannelObjects.SetActive(true);
                bluePannelObjects.SetActive(false);
                break;
        }
    }
}
