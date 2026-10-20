using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class iteminvskript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public inventory.item das;
    public Image picpic;
    public int fickdeinemutter;
    public bool mouseon;
    public inventory manager;
    public int was;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("Manger").GetComponent<inventory>();
        if(das.art == "head")
        {
            was = 0;
        }
        else if(das.art == "breast")
        {
            was = 1;
        }
        else if(das.art == "shoes")
        {
            was = 2;
        }
        else if(das.art == "weapon")
        {
            was = 3;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        picpic.sprite = das.pic;
        if (mouseon == true){
            if (Input.GetMouseButtonDown(0))
            {
                equip();
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                mouseon = false;
            }
            if(was > 2)
            {
                if(manager.donned[was] != null){
                    manager.waffenanzeigen[0].text = das.name;
                    manager.waffenanzeigen[1].text = das.schaden.ToString();
                    manager.waffenanzeigen[2].text = das.angriffsart.ToString();
                    manager.waffenanzeigen[3].text = das.schadensart.ToString();
                    
                    manager.waffenanzeigen[10].text = das.speed.ToString();
                    manager.waffenanzeigen[11].text = das.wert.ToString();
                    manager.waffenanzeigen[12].text = das.gewicht.ToString();
                    manager.waffenanzeigen[14].text = das.explanation;
                    manager.waffenanzeigenbild.sprite = das.pic;
                }
            }
            else if(was < 3)
            {
                if(manager.donned[was] != null){
                    manager.anzeigen[0].text = das.name;
                    manager.anzeigen[4].text = das.schadensreduktion.ToString();
                    manager.anzeigen[5].text = das.verteidigung.ToString();
                    manager.anzeigen[6].text = das.resistenz.ToString();
                    manager.anzeigen[10].text = das.speed.ToString();
                    manager.anzeigen[11].text = das.wert.ToString();
                    manager.anzeigen[12].text = das.gewicht.ToString();
                    manager.anzeigen[14].text = das.explanation;
                    manager.anzeigenbild.sprite = das.pic;
                }
            
        }
        }
        
    }
    public void equip()
    {
        if (manager.donned[manager.lastone] != das){
            manager.donned[manager.lastone] = das;
            manager.selecteditem = null;
            foreach(Transform child in manager.content.transform)
            {
                Destroy(child.gameObject);
            }
            manager.invents.SetActive(true);
            manager.iteminv.SetActive(false);
        }
                
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseon = true;
        manager.selecteditem = this.gameObject;
        if(was > 2)
        {
            
            manager.weaponex.SetActive(true);
            
        }
        else if(was < 3)
        {
            
            manager.armorex.SetActive(true);
        
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseon = false;
        manager.weaponex.SetActive(false);
        manager.armorex.SetActive(false);
    }
}
