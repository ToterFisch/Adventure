using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Data;
public class uiinvscript : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public SpellBuildScript builder;
    public MainMagicUIScript mainmage;
    public SpellBuildScript.Effect das;
    public bool mouseon;
    public bool clicked;
    public GameObject lastparent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        builder = GameObject.Find("SpellBuildUi").GetComponent<SpellBuildScript>();
//        mainmage = GameObject.Find("MainMagicUIMenu").GetComponent<MainMagicUIScript>();
        lastparent = builder.effectinvcontent;
        Debug.Log(builder.effectinvcontent);
        Debug.Log(lastparent);
        mouseon = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (mouseon == true)
        {
            if (Input.GetMouseButton(0))
            {
                transform.SetParent(GameObject.Find("SpellBuildUi").transform);
                transform.position = Input.mousePosition;
            }
            else {transform.SetParent(lastparent.transform);}
        }
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseon = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseon = false;
    }
    public void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("gehittet");
        if (transform.CompareTag("position"))
        {
            transform.SetParent(collision.transform.parent);
            lastparent = collision.transform.parent.gameObject;
            Debug.Log("gewechselt");
        }
    }
}
