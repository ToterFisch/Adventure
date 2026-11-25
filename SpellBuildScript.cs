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
    public TMP_Text[] effecttexts = new TMP_Text[3];
    // 1:name/strength,2:cooldown,3:description
    public Image effectbild;
    public TMP_Text[] factortexts = new TMP_Text[3];
    public GameObject currentier;
    public GameObject spellui;
    public GameObject effectinvcontent;
    public class Effect
    {
        public string name;
        public Sprite image;
        public int strength;
        public string description;
        public float cooldown;
        public string type;
        public Effect(string name, Sprite image, string description , int strength,float cooldown,string type)
        {
            this.name = name;
            this.image = image;
            this.description = description;
            this.strength = strength;
            this.cooldown = cooldown;
            this.type = type;
        }
    }
    public List<Effect> effectsowned = new List<Effect>();
    public List<Effect> factorsowned = new List<Effect>();
    public List<Effect> multiplierowned = new List<Effect>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Anzeigen(Effect das)
    {
        if (das.type == "effect")
        {
            effecttexts[0].text = das.name;
            effecttexts[1].text = das.cooldown.ToString();
            effecttexts[2].text = das.description;
            effectbild.sprite = das.image;
        }
    }
    public void Aufreihen(List<Effect> das,GameObject content,GameObject ui, string was)
    {
        for (int i = 0; i < das.Count; i++)
        {
            GameObject obj = Instantiate(ui, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(content.transform);
            uiinvscript script = obj.GetComponent<uiinvscript>();
            script.das = das[i];
            
        }
    }
    public void Schließen(GameObject content)
    {
        foreach(Transform child in content.transform)
        {
            Debug.Log(child.name);
            Destroy(child.gameObject);
        }
    }
}
