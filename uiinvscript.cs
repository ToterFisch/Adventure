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
    public SpellBuildScript.Effect das = new SpellBuildScript.Effect("penis",null,"a penis",1,1f,"effect");
    public bool mouseon;
    public bool clicked;
    public GameObject lastlastparent;
    public GameObject lastparent;
    public GameObject nextparent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        builder = GameObject.Find("SpellBuildUi").GetComponent<SpellBuildScript>();
//        mainmage = GameObject.Find("MainMagicUIMenu").GetComponent<MainMagicUIScript>();
        lastparent = builder.effectinvcontent;
        Debug.Log(builder.effectinvcontent);
        Debug.Log(lastparent);
        mouseon = false;
        das.type = "effect";
        Debug.Log(das.type);
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
            if (Input.GetMouseButtonUp(0)) 
            {
                transform.SetParent(lastparent.transform);
                if (lastparent.CompareTag("position"))
                {
                    effectpossscript scripti = lastparent.GetComponent<effectpossscript>();
                    scripti.das = das;
                    scripti.belegt = true;
                }
            }
        }
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseon = true;
        builder.inspected = this.gameObject;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
        mouseon = false;
        builder.inspected = null;
    }
    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.transform.CompareTag("position") && collision.gameObject.GetComponent<effectpossscript>().belegt == false)
        {
            Debug.Log(das.type);
            Debug.Log(collision.gameObject.GetComponent<effectpossscript>().type);
            if(collision.gameObject.GetComponent<effectpossscript>().type == das.type){
            lastlastparent = lastparent;
            nextparent = collision.transform.gameObject;
            lastparent = collision.transform.gameObject;
            }
        }
    }
    public void OnTriggerExit2D (Collider2D collision)
    {
        
        if (collision.transform.CompareTag("position"))
        {
            nextparent = null;
            lastparent = lastlastparent;
            lastlastparent = null;
            collision.gameObject.GetComponent<effectpossscript>().belegt = false;
        }
    }
}
