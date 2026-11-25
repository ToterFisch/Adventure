using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class MainMagicUIScript : MonoBehaviour
{
    public GameObject rangedtier3;
    public GameObject buildSpace;
    public SpellBuildScript builder;
    
    public class Spell
    {
        public List<string> effects;
        public List<int> strength;
        public string name;
        public float cooldown;
        public int manacost;//not shure if im gonna need this
        public Spell(List<string> effects,List<int> strength,string name,float cooldown,int manacost)
        {
            this.effects = effects;
            this.strength = strength;
            this.name = name;
            this.cooldown = cooldown;
            this.manacost = manacost;
        }
    }
    public playermovement uiman;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiman = GameObject.Find("Player").GetComponent<playermovement>(); 
        builder = GameObject.Find("SpellBuildUi").GetComponent<SpellBuildScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenBuildSpace(GameObject tier)
    {
        buildSpace.SetActive(true);
        builder.currentier = tier;
        uiman.uiopen = buildSpace;
        tier.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
