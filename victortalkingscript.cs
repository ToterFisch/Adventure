using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
// using UnityEngine.TilemapModule;    this doesnt work
public class victortalkingscript : MonoBehaviour
{
    public Tilemap detailsup;
    public TileBase[] food = new TileBase[5];
    public Vector3[] tisch = new Vector3[16];
    public Vector3[] wostehen = new Vector3[8];
    public bool met;
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
    public int merken;
    public bool test;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        bild = this.gameObject.GetComponent<SpriteRenderer>();
        mikro = GameObject.Find("Manger").GetComponent<uimanagerskript>();
        walk = this.gameObject.GetComponent<enemywalk2>();
        anna = this.gameObject.GetComponent<Animator>();
        einsatz = 1;
        met = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (test == true)
        {
            StartCoroutine(Tischabdecken());
            test = false;
        }
    }
    public IEnumerator küchendinge()
    {
        yield return new WaitForSeconds(Random.Range(1f,10f));
        walk.Move(this.gameObject,new Vector3(-67.5f,-1.5f,this.transform.position.z),5f,anna);
        while (this.transform.position != new Vector3(-67.5f,-1.5f, this.transform.position.z))
        {
            yield return new WaitForSeconds(5f);
        }
        einsatz = 300;
        for (int i = 0; i<3;i++){
            int ran = Random.Range(1,3);
            if (ran == 1)
            {
            walk.Move(this.gameObject,new Vector3(-69.5f,-2.5f,this.transform.position.z),5f,anna);
            while (this.transform.position != new Vector3(-69.5f,-2.5f, this.transform.position.z))
            {
                yield return new WaitForSeconds(5f);
            } 
            yield return new WaitForSeconds(30f);
            }
            else if (ran == 2)
            {
                walk.Move(this.gameObject,new Vector3(-65.5f,-2.5f,this.transform.position.z),5f,anna);
                while (this.transform.position != new Vector3(-69.5f,-2.5f, this.transform.position.z))
                {
                    yield return new WaitForSeconds(5f);
                } 
                yield return new WaitForSeconds(30f);
            }
            else if (ran == 3)
            {
                walk.Move(this.gameObject,new Vector3(-69.5f,-1.5f,this.transform.position.z),5f,anna);
                while (this.transform.position != new Vector3(-69.5f,-2.5f, this.transform.position.z))
                {
                    yield return new WaitForSeconds(5f);
                } 
                yield return new WaitForSeconds(30f);
            }
        }
    }
    public IEnumerator Tischdecken()
    {
        int t = 0;
        einsatz = 400;
        for (int i = 0; i<wostehen.Length; i++)
        {
            walk.Move(this.gameObject,wostehen[i],5f,anna);
            while (this.transform.position != wostehen[i])
            {
                yield return new WaitForSeconds(1f);
            } 
            
            int ran = Random.Range(0,4);
            detailsup.SetTile(detailsup.WorldToCell(tisch[t]),food[ran]);
            t++;
            yield return new WaitForSeconds(1f);
            ran = Random.Range(0,4);
            detailsup.SetTile(detailsup.WorldToCell(tisch[t]),food[ran]);
            t++;
            yield return new WaitForSeconds(1f);
        }
        walk.Move(this.gameObject,new Vector3(-67.5f,-1.5f,this.transform.position.z),5f,anna);
    }
    public IEnumerator Tischabdecken()
    {
        int t = 0;
        einsatz = 400;
        for (int i = 0; i<wostehen.Length; i++)
        {
            walk.Move(this.gameObject,wostehen[i],5f,anna);
            while (this.transform.position != wostehen[i])
            {
                yield return new WaitForSeconds(1f);
            } 
            
            int ran = Random.Range(0,4);
            detailsup.SetTile(detailsup.WorldToCell(tisch[t]),null);
            t++;
            yield return new WaitForSeconds(1f);
            ran = Random.Range(0,4);
            detailsup.SetTile(detailsup.WorldToCell(tisch[t]),null);
            t++;
            yield return new WaitForSeconds(1f);
        }
        walk.Move(this.gameObject,new Vector3(-67.5f,-1.5f,this.transform.position.z),5f,anna);
    }
    public void Done(int i)
    {
        if (met == false)
        {
            merken = einsatz;
            einsatz = 1;
            met = true;
        }
        if (einsatz == 1)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Hello there, my name is Victor. I am the main chef of this kloster. If you want food, we eat in the morning, noon and evening. It would be my honor to serve you some food to.");
            if (merken != 0)
            {
                einsatz = merken;
            }
        }
        else if (einsatz == 300)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Cooking is so stressfull. I am cooking a tasty meal right now, maybe we can talk later.");
            einsatz = 301;
        }
        else if (einsatz == 301)
        {
            einsatz = 300;
        }
    }
}
