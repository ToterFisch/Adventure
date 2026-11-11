using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class playerstats : MonoBehaviour
{
    public GameObject insidemap;
    public inventory inv;
    public int gefcount;
    
    public int leben;
    public int geld;
    
    public int rüstunglost;
    public int verteidigung;
    public int schadensreduktion;
    public int damagetaken;
    public GameObject lebensanzeige;
    public GameObject rüstungsanzeige;
    public GameObject gefäß;
    public GameObject rüfäß;
    public Animator anna;
    public float itch;
    public float timer;
    public float healtime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inv = GameObject.Find("Manger").GetComponent<inventory>();
        anna = this.gameObject.GetComponent<Animator>();
        leben = gefcount*4;
        CalculateValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (rüstunglost > 0 && timer < healtime)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= healtime)
        {
            timer = 0;
            rüstunglost --;
        }
    }
    public void CalculateValues()
    {
        verteidigung = inv.donned[0].verteidigung+inv.donned[1].verteidigung+inv.donned[2].verteidigung;
        schadensreduktion = inv.donned[0].schadensreduktion+inv.donned[1].schadensreduktion+inv.donned[2].schadensreduktion;
        leben = gefcount*4;
        UpdateLife();
    }

    public void Trigger(int i)
    {
        if (i == 100)
        {
            if (insidemap.activeInHierarchy)
            {
                insidemap.SetActive(false);
            }
            else
            {
                insidemap.SetActive(true);
            }
        }
        
    }
    public void UpdateLife()
    {
        foreach(Transform child in lebensanzeige.transform)
        {
            Debug.Log(child.name);
            Destroy(child.gameObject);
        }
        foreach(Transform child in rüstungsanzeige.transform)
        {
            Debug.Log(child.name);
            Destroy(child.gameObject);
        }
        Debug.Log("penus: "+(leben-damagetaken));
        Debug.Log("penis: " +Mathf.Ceil((leben-damagetaken) / 4f));
        
        for(int i = Mathf.RoundToInt(Mathf.Ceil((leben-damagetaken) / 4f)); i > 0; i--)
        {
            Debug.Log("Schritt"+i);
            
            GameObject gefickt = Instantiate(gefäß,Vector3.zero, Quaternion.identity);
            gefickt.transform.SetParent(lebensanzeige.transform);
            if(i == 1)
            {
                Debug.Log("modulo: "+(leben-damagetaken)%4);
                Debug.Log("unmodulo: "+(leben-damagetaken));
                gefickt.SendMessage("Gesprungen", Mathf.RoundToInt((leben-damagetaken)%4));
            }
        }
        for(int i = Mathf.RoundToInt(Mathf.Ceil((verteidigung-rüstunglost) / 4f)); i > 0; i--)
        {
            GameObject fucked = Instantiate(rüfäß,Vector3.zero, Quaternion.identity);
            fucked.transform.SetParent(rüstungsanzeige.transform);
            if(i == 1)
            {
                fucked.SendMessage("Gesprungen",(verteidigung-rüstunglost)%4);
            }
        }
            
    }
    public void Hit(swordattakskript.values werte)
    {
        Debug.Log("hit");
        if (werte.kind != inv.donned[1].resistenz){
            werte.damage -= schadensreduktion;
            for (int i = werte.damage; i > 0; i--)
            {
                if (verteidigung-rüstunglost > 0)
                {
                    rüstunglost++;
                }
                else
                {
                    damagetaken++;
                }
            }
            Debug.Log("starting coroutine");
            StartCoroutine(GotHit());
            CalculateValues();
        }
    }
    public IEnumerator GotHit()
    {
        Debug.Log("started coroutine");
        int before = anna.GetInteger("richtung");
        anna.SetTrigger("GotHit");
        yield return new WaitForSeconds(itch);
        anna.ResetTrigger("GotHit");
    }
}
