using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class gefäßscript : MonoBehaviour
{
    public Sprite full;
    public Sprite[] fese = new Sprite[4];
    public Image img;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        fese[0] = Resources.Load<Sprite>("gefäße_0");
        fese[1] = Resources.Load<Sprite>("gefäße_1");
        fese[2] = Resources.Load<Sprite>("gefäße_2");
        fese[3] = Resources.Load<Sprite>("gefäße_3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gesprungen (int igor)
    {
        Debug.Log(igor);
        if(fese[igor] != null)
        {
            img.sprite = fese[igor];
        }
        else
        {
            Debug.Log("Scheißaufalles");
        }
    }
}
