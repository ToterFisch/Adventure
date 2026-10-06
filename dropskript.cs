using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class dropskript : MonoBehaviour
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
        if (art == "Schuhe"){
            inv.shoes.Add(new inventory.item(name,schaden,angriffsart,schadensreduktion,verteidigung,art,description,pic));
        }
        else if (art == "Torso"){
            inv.breast.Add(new inventory.item(name,schaden,angriffsart,schadensreduktion,verteidigung,art,description,pic));
        }
        Destroy(this.gameObject);
    }
}
