using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;




public class truhenskript : MonoBehaviour
{
    public Sprite[] info = new Sprite[5];
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Offnen(){
        if(offen==false){
            foreach (inventory.item ito in Contains)
                {
                    GameObject obj = Instantiate(drop, transform.position, transform.rotation);
                    Debug.Log("innendrinne");
                    dropskript script = obj.GetComponent<dropskript>();
                    if(script != null){
                    Debug.Log("simmanochdrinne");
                    Debug.Log(script.das.name + "wasndalos");
                    script.das = ito;
                    }
                    Debug.Log("penis");
                }
            offen=true;
            kistenbild.sprite=closed;
        }
    }
}
