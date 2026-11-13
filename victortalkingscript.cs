using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class victortalkingscript : MonoBehaviour
{
    public uimanagerskript mikro;
    public SpriteRenderer bild;
    public int einsatz;
    public int todo;
    public enemywalk2 walk;
    public float speed;
    public Animator anna;
    public GameObject player;
    public GameObject bett;
    public int ungeduld = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        bild = this.gameObject.GetComponent<SpriteRenderer>();
        mikro = GameObject.Find("Manger").GetComponent<uimanagerskript>();
        walk = this.gameObject.GetComponent<enemywalk2>();
        anna = this.gameObject.GetComponent<Animator>();
        einsatz = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator küchendinge()
    {
        
    }
}
