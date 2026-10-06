using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class truhenskript : MonoBehaviour
{
    
    public bool offen;
    public Sprite closed;
    public SpriteRenderer kistenbild;
    public GameObject drop;
    public inventory inv;
    public List<inventory.item> Contains = new List<inventory.item>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offen=false;
        kistenbild = this.gameObject.GetComponent<SpriteRenderer>();
        inv  = GameObject.Find("Manger").GetComponent<inventory>();
        Contains.Add(new inventory.item("penis",1,1,1,1,"penis","einfach Penis", closed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void offnen(){
        if(offen==false){
            foreach (inventory.item ito in Contains)
                {
                    GameObject obj = Instantiate(drop, transform.position, transform.rotation);
                    
                    dropskript script = obj.GetComponent<dropskript>();
                    Debug.Log(ito.name+"huhu");
                    script.name = ito.name;
                    script.schaden = ito.schaden;
                    script.angriffsart = ito.angriffsart;
                    script.schadensreduktion = ito.schadensreduktion;
                    script.verteidigung = ito.verteidigung;
                    script.art = ito.art;
                    script.description = ito.explanation;
                    script.pic = ito.pic;
                    
                    Debug.Log("penis");
                }
            offen=true;
            kistenbild.sprite=closed;
        }
    }
}
