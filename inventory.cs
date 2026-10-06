using UnityEngine;
using System.Collections.Generic;
public class inventory : MonoBehaviour
{
    public bool invan;
    public GameObject iteminv;
    public GameObject itemui;
    public GameObject content;
    public GameObject selecteditem;
    public GameObject spellpos;
    public Sprite feuerball;
    public List<item> shoes;
    public List<item> breast;
    public List<item> head;
    public List<item> weapons;
    public List<item> charms;
    public class item
    {
        public string name;
        public int schaden;
        public int angriffsart;
        public int schadensreduktion;
        public int verteidigung;
        public string art;
        public string explanation;
        public Sprite pic;
        public item(string name,int schaden,int angriffsart,int schadensreduktion,int verteidigung,string art, string explanation, Sprite pic)
        {
            this.name = name;
            this.schaden = schaden;
            this.angriffsart = angriffsart;
            this.schadensreduktion = schadensreduktion;
            this.verteidigung = verteidigung;
            this.art = art;
            this.explanation = explanation;
            this.pic = pic;
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invan = false;
        shoes = new List<item>(){new item("penis",1,1,1,1,"penis","einfach Penis", feuerball)};
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            
        }
    }
    public void invon(List<item> das,GameObject cont,GameObject itin){
        if (invan == false){
                itin.SetActive(true);
                foreach (item ito in das)
                {
                    GameObject obj = Instantiate(itemui, Vector3.zero, Quaternion.identity);
                    obj.transform.SetParent(cont.transform);
                    iteminvskript script = obj.GetComponent<iteminvskript>();
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
                invan = true;
            }
            else if (invan == true){
                iteminv.SetActive(false);
                for (int i = 0; i < content.transform.childCount; i=i+1)
                {
                    Destroy(content.transform.GetChild(i).gameObject);
                }       
                invan = false;
            }
    }
}