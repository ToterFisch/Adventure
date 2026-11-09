using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class slimescript : MonoBehaviour
{
    public int leben;
    public string resistenz;
    public int verteidigung;
    public Animator anna;
    public bool aggro;
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
        anna = this.gameObject.GetComponent<Animator>(); 
        player = GameObject.Find("Player").transform;
        rich = this.gameObject.GetComponent<Rigidbody2D>();
        penis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(aggro == true)
        {
            if (Vector3.Distance(tom.transform.position, player.transform.position) > distancetokeep)
            {
                if (Math.Abs(tom.transform.position.x - player.transform.position.x) > Math.Abs(tom.transform.position.y - player.transform.position.y))
                {
                    if(tom.transform.position.x > player.transform.position.x)
                    {
                        anna.SetInteger("richtung",1);
                    }
                    else
                    {
                        anna.SetInteger("richtung",2);
                    }
                }
                else
                {
                    if(tom.transform.position.y > player.transform.position.y)
                    {
                        anna.SetInteger("richtung",3);
                    }
                    else
                    {
                        anna.SetInteger("richtung",4);
                    }
                }
            }
        }
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
        if (werte.kind != resistenz){
            for (int i = werte.damage; i > 0; i--)
            {
                if (verteidigung > 0)
                {
                    verteidigung --;
                }
                else
                {
                    leben --;
                }
            }
            penis = true;
            Vector2 playe = new Vector2 (player.position.x,player.position.y);
            Vector2 to = new Vector2 (this.gameObject.transform.position.x,this.gameObject.transform.position.y);
            Vector2 dir = to-playe;  
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(dir*force);
            Debug.Log("Done?");
            penis = false;
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
