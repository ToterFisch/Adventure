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
    public bool penis;
    public float dampeningRate;
    public Rigidbody2D rich;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //why did i do this stuff with tom isnt this script attached to him?
        tom = GameObject.Find("Tom");
        anna = this.gameObject.GetComponent<Animator>();
        tomtalk = tom.GetComponent<tomtalkingscript>();
        player = GameObject.Find("Player").transform;
        rich = tom.GetComponent<Rigidbody2D>();
        penis = false;
    }
    public void Update()
    {
        if(tomtalk.aggro == true)
        {
            rich.constraints = RigidbodyConstraints2D.None;
            rich.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rich.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(rich.velocity.magnitude != 0) 
        {
            Vector3 dampeningDirection = rich.velocity.normalized * -1.0f;
	        rich.AddForce( dampeningDirection * dampeningRate);
        }
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
            penis = true;
            Vector2 playe = new Vector2 (player.position.x,player.position.y);
            Vector2 to = new Vector2 (tom.transform.position.x,tom.transform.position.y);
            Vector2 dir = to-playe;  
            tom.GetComponent<Rigidbody2D>().AddForce(dir*force);
            Debug.Log("Done?");
            penis = false;
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
