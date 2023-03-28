using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string nowQColor = "None";
    private string nowEColor = "None";
    private string nowColor = "None";

    public GameObject redPannelObjects;
    public GameObject greenPannelObjects;
    public GameObject bluePannelObjects;

    public GameObject qRColorBox;
    public GameObject qGColorBox;
    public GameObject qBColorBox;

    public GameObject eRColorBox;
    public GameObject eGColorBox;
    public GameObject eBColorBox;

    public ColorEvent colorEvent = new ColorEvent();
    void Start()
    {
        qRColorBox.GetComponent<Image>().color = Color.black;
        qRColorBox.GetComponent<Image>().color = Color.black;
        qGColorBox.GetComponent<Image>().color = Color.black;
        qBColorBox.GetComponent<Image>().color = Color.black;
        eRColorBox.GetComponent<Image>().color = Color.black;
        eGColorBox.GetComponent<Image>().color = Color.black;
        eBColorBox.GetComponent<Image>().color = Color.black;
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
                    qRColorBox.GetComponent<Image>().color = Color.red;
                    qGColorBox.GetComponent<Image>().color = Color.black;
                    qBColorBox.GetComponent<Image>().color = Color.black;
                    break;
                case "Red":
                    nowQColor = "Green";
                    qRColorBox.GetComponent<Image>().color = Color.black;
                    qGColorBox.GetComponent<Image>().color = Color.green;
                    qBColorBox.GetComponent<Image>().color = Color.black;
                    break;
                case "Green":
                    nowQColor = "Blue";
                    qRColorBox.GetComponent<Image>().color = Color.black;
                    qGColorBox.GetComponent<Image>().color = Color.black;
                    qBColorBox.GetComponent<Image>().color = Color.blue;
                    break;
                case "Blue":
                    nowQColor = "None";
                    qRColorBox.GetComponent<Image>().color = Color.black;
                    qGColorBox.GetComponent<Image>().color = Color.black;
                    qBColorBox.GetComponent<Image>().color = Color.black;
                    break;
            }
            nowColor = ColorCheck(nowQColor, nowEColor);
            ColorActive(nowColor);
            ColorEvent(nowColor);
            Debug.Log(nowQColor + nowEColor + nowColor);
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            switch (nowEColor)
            {
                case "None":
                    nowEColor = "Red";
                    eRColorBox.GetComponent<Image>().color = Color.red;
                    eGColorBox.GetComponent<Image>().color = Color.black;
                    eBColorBox.GetComponent<Image>().color = Color.black;
                    break;
                case "Red":
                    nowEColor = "Green";
                    eRColorBox.GetComponent<Image>().color = Color.black;
                    eGColorBox.GetComponent<Image>().color = Color.green;
                    eBColorBox.GetComponent<Image>().color = Color.black;
                    break;
                case "Green":
                    nowEColor = "Blue";
                    eRColorBox.GetComponent<Image>().color = Color.black;
                    eGColorBox.GetComponent<Image>().color = Color.black;
                    eBColorBox.GetComponent<Image>().color = Color.blue;
                    break;
                case "Blue":
                    nowEColor = "None";
                    eRColorBox.GetComponent<Image>().color = Color.black;
                    eGColorBox.GetComponent<Image>().color = Color.black;
                    eBColorBox.GetComponent<Image>().color = Color.black;
                    break;
            }
            nowColor = ColorCheck(nowQColor, nowEColor);
            ColorActive(nowColor);
            ColorEvent(nowColor);
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
        redPannelObjects.SetActive(false);
        greenPannelObjects.SetActive(false);
        bluePannelObjects.SetActive(false);
        switch (color)
        {
            case "None":
                break;
            case "Red":
                redPannelObjects.SetActive(true);
                greenPannelObjects.SetActive(false);
                bluePannelObjects.SetActive(false);
                break;
            case "Green":
                redPannelObjects.SetActive(false);
                greenPannelObjects.SetActive(true);
                bluePannelObjects.SetActive(false);
                break;
            case "Blue":
                redPannelObjects.SetActive(false);
                greenPannelObjects.SetActive(false);
                bluePannelObjects.SetActive(true);
                break;
            case "Magenta":
                redPannelObjects.SetActive(true);
                greenPannelObjects.SetActive(false);
                bluePannelObjects.SetActive(true);
                break;
            case "Cyan":
                redPannelObjects.SetActive(false);
                greenPannelObjects.SetActive(true);
                bluePannelObjects.SetActive(true);
                break;
            case "Yellow":
                redPannelObjects.SetActive(true);
                greenPannelObjects.SetActive(true);
                bluePannelObjects.SetActive(false);
                break;
        }
    }
    private void ColorEvent(string color)
    {
        colorEvent.Invoke(color);
    }
}

public class ColorEvent : UnityEvent<string> { }
