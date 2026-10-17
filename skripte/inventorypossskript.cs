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
            if(art > 2)
            {
                if(manager.donned[art] != null){
                    manager.anzeigen[0].text = manager.donned[art].name;
                    manager.anzeigen[1].text = manager.donned[art].schaden.ToString();
                    manager.anzeigen[2].text = manager.donned[art].angriffsart.ToString();
                    manager.anzeigen[3].text = manager.donned[art].schadensart.ToString();
                    
                    manager.anzeigen[10].text = manager.donned[art].speed.ToString();
                    manager.anzeigen[11].text = manager.donned[art].wert.ToString();
                    manager.anzeigen[12].text = manager.donned[art].gewicht.ToString();
                    manager.anzeigen[14].text = manager.donned[art].explanation;
                }
            }
            else if(art < 3)
            {
                if(manager.donned[art] != null){
                    manager.anzeigen[0].text = manager.donned[art].name;
                    manager.anzeigen[4].text = manager.donned[art].schadensreduktion.ToString();
                    manager.anzeigen[5].text = manager.donned[art].verteidigung.ToString();
                    manager.anzeigen[6].text = manager.donned[art].resistenz.ToString();
                    manager.anzeigen[10].text = manager.donned[art].speed.ToString();
                    manager.anzeigen[11].text = manager.donned[art].wert.ToString();
                    manager.anzeigen[12].text = manager.donned[art].gewicht.ToString();
                    manager.anzeigen[14].text = manager.donned[art].explanation;
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseon = true;
        if(art > 2)
        {
            if(manager.donned[art].wert != 0){
                
                manager.weaponex.SetActive(true);
            }
        }
        else if(art < 3)
        {
            if(manager.donned[art].wert != 0){
                Debug.Log("rüstung");
                manager.armorex.SetActive(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseon = false;
        manager.weaponex.SetActive(false);
        manager.armorex.SetActive(false);
    }
    /*manager.anzeigen[0].text = manager.donned[art].name;
    manager.anzeigen[1].text = manager.donned[art].schaden.ToString();
    manager.anzeigen[2].text = manager.donned[art].angriffsart.ToString();
    manager.anzeigen[3].text = manager.donned[art].schadensart.ToString();
    manager.anzeigen[4].text = manager.donned[art].schadensreduktion.ToString();
    manager.anzeigen[5].text = manager.donned[art].verteidigung.ToString();
    manager.anzeigen[6].text = manager.donned[art].resistenz.ToString();
    manager.anzeigen[7].text = manager.donned[art].effekt;
    manager.anzeigen[8].text = manager.donned[art].effektstaerke.ToString();
    manager.anzeigen[9].text = manager.donned[art].geschw.ToString();
    manager.anzeigen[10].text = manager.donned[art].speed.ToString();
    manager.anzeigen[11].text = manager.donned[art].wert.ToString();
    manager.anzeigen[12].text = manager.donned[art].gewicht.ToString();
    manager.anzeigen[13].text = manager.donned[art].art;
    manager.anzeigen[14].text = manager.donned[art].explanation;*/
}
