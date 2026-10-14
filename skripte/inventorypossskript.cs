using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class inventorypossskript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int art;
    public string was;
    public inventory.item lastone;
    public bool mouseon;
    public inventory manager;
    public Image im;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("Manger").GetComponent<inventory>();
        im = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseon == true){
            if (Input.GetMouseButtonDown(0))
            {
                mouseon = false;
                manager.invon(manager.shoes,manager.content,manager.iteminv,was,art);
            }
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
}
