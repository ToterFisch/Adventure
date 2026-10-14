using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class dropskript : MonoBehaviour
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
    public inventory inv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inv  = GameObject.Find("Manger").GetComponent<inventory>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void aufheben(){
        
        inv.shoes.Add(new inventory.item(name,schaden,angriffsart,schadensart,schadensreduktion,verteidigung,resistenz,effekt,effektstaerke,geschw,speed,wert,gewicht,art,explanation,pic));
        Destroy(this.gameObject);
    }
}
