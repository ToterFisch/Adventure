using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class enemyattackskript : MonoBehaviour
{
    public Animator anna;
    public tomtalkingscript tomtalk;
    public GameObject tom;
    public float itch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tom = GameObject.Find("Tom");
        anna = this.gameObject.GetComponent<Animator>();
        tomtalk = tom.GetComponent<tomtalkingscript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(swordattakskript.values werte)
    {
        Debug.Log("hit");
        if (werte.kind != tomtalk.resistenz){
            werte.damage -= tomtalk.schadensreduktion;
            for (int i = werte.damage; i > 0; i--)
            {
                if (tomtalk.verteidigung > 0)
                {
                    tomtalk.verteidigung --;
                }
                else
                {
                    tomtalk.leben --;
                }
            }
            StartCoroutine(GotHit());
        }
    }
    public IEnumerator GotHit()
    {
        int before = anna.GetInteger("richtung");
        Debug.Log("before: "+before);
        anna.SetInteger("richtung", before+10);
        Debug.Log("after: "+anna.GetInteger("richtung"));
        yield return new WaitForSeconds(itch);
        Debug.Log("afterafter: "+anna.GetInteger("richtung"));
        anna.SetInteger("richtung", before);
    }
}
