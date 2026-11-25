using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class SpellBuildScript : MonoBehaviour
{
    
    public class Effect
    {
        public string name;
        public Sprite image;
        public string description;
        public float cooldown;
        public string type;
        public Effect(string name, Sprite image, string description,float cooldown,string type)
        {
            this.name = name;
            this.image = image;
            this.description = description;
            this.cooldown = cooldown;
            this.type = type;
        }
    }
    public class Factor
    {
        public string name;
        public int strength;
        public string description;
        public float cooldown;
        public string type;
        public Factor(string name,int strength,string description,float cooldown,string type)
        {
            this.name = name;
            this.strength = strength;
            this.description = description;
            this.cooldown = cooldown;
            this.type = type;
        }
    }
    public List<Effect> effectsowned = new List<Effect>();
    public List<Factor> factorsowned = new List<Factor>();
    public List<Factor> multiplierowned = new List<Factor>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Aufreihen(List<item> das,GameObject content, string was, int waswas)
    {
        for (int i = 0; i < das.Count; i++)
        {
            Debug.Log(das[i].art+was+waswas);
        }
        for (int i = 0; i < das.Count; i++)
        {
            
            GameObject obj = Instantiate(itemui, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(cont.transform);
            iteminvskript script = obj.GetComponent<iteminvskript>();
            script.das = ito;
            
            Debug.Log("penis");
            
        }
        
    }
}
