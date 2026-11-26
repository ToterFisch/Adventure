using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Data;
public class tierscript : MonoBehaviour
{
    public effectpossscript namestuff;
    public string maineffect;
    public int number1;
    public string sideeffect1;
    public int number2;
    public string sideeffect2;
    public int number3;
    public string sideeffect3;
    public int multplier;
    public int multplier2;
    public float cooldown;
    public float basiscooldown;
    public GameObject namestuffr;
    public effectpossscript maineffectr;
    public effectpossscript number1r;
    public effectpossscript sideeffect1r;
    public effectpossscript number2r;
    public effectpossscript sideeffect2r;
    public effectpossscript number3r;
    public effectpossscript sideeffect3r;
    public effectpossscript multplierr;
    public effectpossscript multplier2r;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = basiscooldown;
    }
}
