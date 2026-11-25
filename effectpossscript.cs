using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Data;

public class effectpossscript : MonoBehaviour
{
    public string name;
    public SpellBuildScript.Effect das;
    public GameObject zugewiesen;
    public string type;
    public bool belegt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        belegt = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
