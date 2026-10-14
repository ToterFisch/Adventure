using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class inventory : MonoBehaviour
{
    public bool invan;
    public GameObject iteminv;
    public GameObject invents;
    public GameObject armorex;
    public GameObject weaponex;
    public GameObject itemui;
    public GameObject content;
    public GameObject selecteditem;
    public GameObject spellpos;
    public Sprite feuerball;
    
    public List<item> shoes;
    public item[] donned = new item[5];
    public Image[] pospic = new Image[5];
    //0:head; 1:breast; 2:shoes; 3:left; 4:right
    public int lastone;
    public class item
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

        public item(string name,int schaden,int angriffsart, string schadensart,int schadensreduktion,int verteidigung,string resistenz, string effekt, int effektstaerke, int geschw, int speed, int wert, int gewicht, string art, string explanation, Sprite pic)
        {
            this.name = name;
            this.schaden = schaden;
            this.angriffsart = angriffsart;
            this.schadensart = schadensart;
            this.schadensreduktion = schadensreduktion;
            this.verteidigung = verteidigung;
            this.resistenz = resistenz;
            this.effekt = effekt;
            this.effektstaerke = effektstaerke;
            this.geschw = geschw;
            this.speed = speed;
            this.wert = wert;
            this.gewicht = gewicht;
            this.art = art;
            this.explanation = explanation;
            this.pic = pic;
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invan = false;
        shoes = new List<item>(){new item("penis",1,1,"idiotie",1,1,"penis","einfach Penis",1,1,1,1,1,"shoes","panis", feuerball)};
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            invents.SetActive(true);
        }
        for (int i = 0; i < 5; i++)
        {
            if(donned[i] != null){
                pospic[i].sprite = donned[i].pic;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            selecteditem = null;
            foreach(Transform child in content.transform)
            {
                Debug.Log(child.name);
                Destroy(child.gameObject);
            }
            Debug.Log("were in");
            invents.SetActive(true);
            iteminv.SetActive(false);
        }
    }
    public void invon(List<item> das,GameObject cont,GameObject itin, string was, int waswas){
        //if (invan == false){
        for (int i = 0; i < das.Count; i++)
        {
            Debug.Log(das[i].art+was+waswas);
        }
                itin.SetActive(true);
                invents.SetActive(false);
                foreach (item ito in das)
                {
                        if(ito.art == was || was == null){
                        GameObject obj = Instantiate(itemui, Vector3.zero, Quaternion.identity);
                        obj.transform.SetParent(cont.transform);
                        iteminvskript script = obj.GetComponent<iteminvskript>();
                        Debug.Log(ito.name+"huhu");
                        script.name = ito.name;
                        script.schaden = ito.schaden;
                        script.angriffsart = ito.angriffsart;
                        script.schadensart = ito.schadensart;
                        script.schadensreduktion = ito.schadensreduktion;
                        script.verteidigung = ito.verteidigung;
                        script.resistenz = ito.resistenz;
                        script.effekt = ito.effekt;
                        script.effektstaerke = ito.effektstaerke;
                        script.geschw = ito.geschw;
                        script.speed = ito.speed;
                        script.wert = ito.wert;
                        script.gewicht = ito.gewicht;
                        script.art = ito.art;
                        script.explanation = ito.explanation;
                        script.pic = ito.pic;
                    
                        Debug.Log("penis");
                    }
                }
                invan = true;
        /*}
            else if (invan == true){
                iteminv.SetActive(false);
                for (int i = 0; i < content.transform.childCount; i=i+1)
                {
                    Destroy(content.transform.GetChild(i).gameObject);
                }       
                invan = false;
            }*/
        lastone = waswas;
    }
}