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
            if (Input.GetMouseButtonDown(0))
            {
                equip();
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
                Debug.Log(child.name);
                Destroy(child.gameObject);
            }
            Debug.Log("were in");
            manager.invents.SetActive(true);
            manager.iteminv.SetActive(false);
        }
                
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseon = true;
        manager.selecteditem = this.gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseon = false;
        
    }
}
