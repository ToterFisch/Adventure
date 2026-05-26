using UnityEngine;
using System.Collections.Generic;
public class abilitys : MonoBehaviour
{
    public bool invan;
    public GameObject spellinv;
    public GameObject spellui;
    public GameObject content;
    
    
    public class spell
    {
        public int costs;
        public string explanation;
        public spell(int costs, string explanation)
        {
            this.costs = costs;
            this.explanation = explanation;
        }
    }
    public Dictionary< string, spell> playerspells = new Dictionary< string, spell>()
    {
        {"Eisstachel", new spell(1,"Applyes 3 Frost to enemy")}
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invan = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            if (invan == false){
                spellinv.SetActive(true);
                foreach (KeyValuePair<string, spell> spello in playerspells)
                {
                    GameObject obj = Instantiate(spellui, Vector3.zero, Quaternion.identity);
                    obj.transform.SetParent(content.transform);
                    spellinvspellskript script = obj.GetComponent<spellinvspellskript>();
                    script.name = spello.Key;
                    script.cost = spello.Value.costs;
                    script.description = spello.Value.explanation;
                }
                invan = true;
            }
            else if (invan == true){
                spellinv.SetActive(false);
                for (int i = 0; i < content.transform.childCount; i=i+1)
                {
                    Destroy(content.transform.GetChild(i).gameObject);
                }       
                invan = false;
            }
        }
    }
}
