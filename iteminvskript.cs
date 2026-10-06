using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class iteminvskript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string name;
    public int schaden;
    public int angriffsart;
    public int schadensreduktion;
    public int verteidigung;
    public string art;
    public string description;
    public Sprite pic;
    public Image picpic;
    
    public bool mouseon;
    public inventory manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("Manger").GetComponent<inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
        picpic.sprite = pic;
        if (mouseon == true){
            if (Input.GetMouseButtonDown(0)){
                manager.selecteditem = this.gameObject;
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
