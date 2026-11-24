using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class dropskript : MonoBehaviour
{
    
    public inventory.item das;

    public SpriteRenderer picpic;
    public inventory inv;
    public GameObject player;
    public float speed;
    public bool clicked;
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inv  = GameObject.Find("Manger").GetComponent<inventory>();
        picpic = this.gameObject.GetComponent<SpriteRenderer>();
        picpic.sprite = das.pic;
        clicked = false;
        player = GameObject.Find("Player");
        target = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (clicked == true){
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position , speed * Time.deltaTime);
        }
        if(clicked == true && this.transform.position == target.transform.position)
        {
            int uhu = inv.durchsuchen(das);
            if(uhu < 0){
                inv.shoes.Add(das);
                Destroy(this.gameObject);
            }
            else
            {
                inv.shoes[uhu].anzahl ++;
                Destroy(this.gameObject);
            }
        }
    }
    public void aufheben(GameObject tar){
        clicked = true;
        target = tar;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (clicked == true && collision.gameObject.transform.CompareTag("Player"))
        {
            int uhu = inv.durchsuchen(das);
            if(uhu < 0){
                inv.shoes.Add(das);
                Destroy(this.gameObject);
            }
            else
            {
                inv.shoes[uhu].anzahl ++;
                Destroy(this.gameObject);
            }
        }
        else if (clicked == true && collision.gameObject.transform.CompareTag("npc"))
        {
            Destroy(this.gameObject);
        }
    }
    
}
