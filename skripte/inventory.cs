using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;





public class inventory : MonoBehaviour
{
    public GameObject anzeigendingens;
    public TMP_Text[] anzeigen = new TMP_Text[15];
    
    public TMP_Text[] waffenanzeigen = new TMP_Text[15];
    public Image anzeigenbild;
    public Image waffenanzeigenbild;
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
    public uimanagerskript uman;
    public playermovement uiman;

    public int lastone;
    [System.Serializable]
    public class item
    {
        public string name;
        
        //fuer waffen
        public int schaden;
        public string angriffsart;
        public string schadensart;
        
        //fuer ruestung
        public int schadensreduktion;
        public int verteidigung;
        public string resistenz;

        //fuer ausrustung
        public string effekt;
        public int effektstaerke;
        public float geschw;
        public int speed;

        
        //fuer alles
        public int wert;
        public int gewicht;
        public string art;
        public string explanation;
        public Sprite pic;

        public item(string name,int schaden,string angriffsart, string schadensart,int schadensreduktion,int verteidigung,string resistenz, string effekt, int effektstaerke, float geschw, int speed, int wert, int gewicht, string art, string explanation, Sprite pic)
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
    //0:head; 1:breast; 2:shoes; 3:left; 4:right
    public List<item> shoes;
    public item[] donned = new item[5];
    public Image[] pospic = new Image[5];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invan = false;
        shoes = new List<item>(){};
        uiman = GameObject.Find("Player").GetComponent<playermovement>();
        uman = this.gameObject.GetComponent<uimanagerskript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < 5; i++)
        {
            if(donned[i] != null){
                pospic[i].sprite = donned[i].pic;
            }
        }
       
    }
    public void R()
    {
        if(uiman.uiopen == null && iteminv.activeInHierarchy != true){
            invents.SetActive(true);
            anzeigendingens.SetActive(true);
            invan = true;
            uiman.uiopen = invents;
        }
        else if (uiman.uiopen == iteminv)
        {
            selecteditem = null;
            foreach(Transform child in content.transform)
            {
                Debug.Log(child.name);
                Destroy(child.gameObject);
            }
            Debug.Log("were in");
            iteminv.SetActive(false);
            anzeigendingens.SetActive(false);
            uiman.uiopen = null;
        }
        else
        {
            Escape();
        }
    }
    public void Escape()
    {
        
        if(invan == true && iteminv.activeInHierarchy == true){
            selecteditem = null;
            foreach(Transform child in content.transform)
            {
                Debug.Log(child.name);
                Destroy(child.gameObject);
            }
            Debug.Log("were in");
            invents.SetActive(true);
            iteminv.SetActive(false);
            uiman.uiopen = invents;
        }
            
        else if(invents.activeInHierarchy == true)
        {
            Debug.Log("definitly here");
            invents.SetActive(false);
            anzeigendingens.SetActive(false);
            invan = false;
            uiman.uiopen = null;
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
                        script.das = ito;
                    
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