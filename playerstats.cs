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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inv = GameObject.Find("Manger").GetComponent<inventory>();
        leben = gefcount*4;
        CalculateValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CalculateValues()
    {
        verteidigung = inv.donned[0].verteidigung+inv.donned[1].verteidigung+inv.donned[2].verteidigung;
        schadensreduktion = inv.donned[0].schadensreduktion+inv.donned[1].schadensreduktion+inv.donned[2].schadensreduktion;
        leben = gefcount*4-damagetaken;
        UpdateLife();
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
        
        for(int i = Mathf.RoundToInt(Mathf.Ceil((leben-damagetaken) / 4)); i > 0; i--)
        {
            GameObject gefickt = Instantiate(gefäß,Vector3.zero, Quaternion.identity);
            gefickt.transform.SetParent(lebensanzeige.transform);
            if(i == 1)
            {
                gefickt.SendMessage("Gesprungen",Mathf.RoundToInt((leben-damagetaken)%4));
            }
        }
        /*for(int i = Mathf.RoundToInt(Mathf.Ceil(verteidigung-rüstunglost / 4)); i > 0; i--)
        {
            GameObject fucked = Instantiate(rüfäß,Vector3.zero, Quaternion.identity);
            fucked.transform.SetParent(rüstungsanzeige.transform);
            if(i == 1)
            {
                fucked.SendMessage("Gesprungen",(verteidigung-rüstunglost)%4);
            }
        }*/
            
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
            StartCoroutine(GotHit());
            UpdateLife();
        }
    }
    public IEnumerator GotHit()
    {
        yield return new WaitForSeconds(1f);
    }
}
