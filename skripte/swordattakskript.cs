using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;
public class swordattakskript : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer;
    public float time;
    public bool disarmed;
    public List<GameObject> liste = new List<GameObject>();
    public class values
    {
        public int damage;
        public string kind;
        public values (int damage, string kind)
        {
            this.damage = damage;
            this.kind = kind;
        }
    }
    public values werte;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(delete());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pariert()
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Hut(collision);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Hot();
    }
    public void Hut(Collider2D collision)
    {
        Debug.Log("wannahit: "+collision.transform.tag);
        
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("npc") || collision.transform.CompareTag("attack"))
        {
            liste.Add(collision.gameObject);
        }
        
    }
    public void Hot()
    {
        foreach (GameObject collision in liste)
        {
            if (collision.transform.CompareTag("attack"))
            {
                disarmed = true;
                
            }
        }
        foreach (GameObject collision in liste)
        {
            if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("npc"))
            {
                if(disarmed == false){
                    collision.SendMessage("Hit",werte);
                    
                }
            }
        }
        liste.Clear();
    }
    public IEnumerator delete()
    {

        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }
}