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
    public float force;
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tom = GameObject.Find("Tom");
        anna = this.gameObject.GetComponent<Animator>();
        tomtalk = tom.GetComponent<tomtalkingscript>();
        player = GameObject.Find("Player").transform;
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
            Vector2 playe = new Vector2 (player.transform.x,player.transform.y);
            Vector2 to = new Vector2 (tom.transform.x,tom.transform.y);
            Vector2 dir = playe-to;
            Vector2.Normalize(dir);
            tom.GetComponent<Rigidbody2D>().AddForce(transform.up*force);
            Debug.Log("Done?");
            StartCoroutine(GotHit());
        }
        tomtalk.aggro=true;
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
