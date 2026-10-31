using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class gefäßscript : MonoBehaviour
{
    public Sprite full;
    
    public Image img;
    public uimanagerskript manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        manager = GameObject.Find("Manger").GetComponent<uimanagerskript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gesprungen (int igor)
    {
        img = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        manager = GameObject.Find("Manger").GetComponent<uimanagerskript>();
        Debug.Log(igor);
        img.sprite = manager.fese[igor];
        
        Debug.Log("Scheißaufalles");
        
    }
}
