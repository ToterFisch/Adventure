using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class iteminvskript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string name;
     
    //fuer waffen
    public int schaden;
    public int angriffsart;
    public string schadensart;
        
    //fuer ruestung
    public int schadensreduktion;
    public int verteidigung;
    public string resistenz;

    //fuer ausrustung
    public string effekt;
    public int effektstaerke;
    public int geschw;
    public int speed;

        
    //fuer alles
    public int wert;
    public int gewicht;
    public string art;
    public string explanation;
    public Sprite pic;
    public Image picpic;
    public int fickdeinemutter;
    public bool mouseon;
    public inventory manager;
    public int was;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("Manger").GetComponent<inventory>();
        if(art == "head")
        {
            was = 0;
        }
        else if(art == "breast")
        {
            was = 1;
        }
        else if(art == "shoes")
        {
            was = 2;
        }
        else if(art == "right")
        {
            was = 3;
        }
        else if(art == "left")
        {
            was = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        picpic.sprite = pic;
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
                    manager.anzeigen[0].text = name;
                    manager.anzeigen[1].text = schaden.ToString();
                    manager.anzeigen[2].text = angriffsart.ToString();
                    manager.anzeigen[3].text = schadensart.ToString();
                    
                    manager.anzeigen[10].text = speed.ToString();
                    manager.anzeigen[11].text = wert.ToString();
                    manager.anzeigen[12].text = gewicht.ToString();
                    manager.anzeigen[14].text = explanation;
                }
            }
            else if(was < 3)
            {
                if(manager.donned[was] != null){
                    manager.anzeigen[0].text = name;
                    manager.anzeigen[4].text = schadensreduktion.ToString();
                    manager.anzeigen[5].text = verteidigung.ToString();
                    manager.anzeigen[6].text = resistenz.ToString();
                    manager.anzeigen[10].text = speed.ToString();
                    manager.anzeigen[11].text = wert.ToString();
                    manager.anzeigen[12].text = gewicht.ToString();
                    manager.anzeigen[14].text = explanation;
                }
            
        }
        }
        
    }
    public void equip()
    {
        if (manager.donned[manager.lastone] != new inventory.item (name,schaden,angriffsart,schadensart,schadensreduktion,verteidigung,resistenz,effekt,effektstaerke,geschw,speed,wert,gewicht,art,explanation,pic)){
            manager.donned[manager.lastone] = new inventory.item (name,schaden,angriffsart,schadensart,schadensreduktion,verteidigung,resistenz,effekt,effektstaerke,geschw,speed,wert,gewicht,art,explanation,pic);
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
