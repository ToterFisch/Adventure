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
        Debug.Log("iscalled");
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
        Debug.Log("getscalled");
        for (int i = 0; i<liste.Count; i++)
        {
            if (liste[i].transform.CompareTag("attack"))
            {
                disarmed = true;
                liste[i].SendMessage("Pariert");
                Debug.Log("Disarmed");
            }
        }
        Debug.Log("in the middle");
        for (int i = 0; i<liste.Count; i++)
        {
            if (liste[i].transform.CompareTag("Player") || liste[i].transform.CompareTag("npc"))
            {
                Debug.Log("itsplayer");
                if(disarmed == false){
                    liste[i].SendMessage("Hit",werte);
                    Debug.Log("hitit");
                }
            }
        }
        Debug.Log("at the end");
        liste.Clear();
    }
    public IEnumerator delete()
    {
        
        yield return new WaitForSeconds(time);
        Hot();
        Destroy(gameObject);
        
    }
}