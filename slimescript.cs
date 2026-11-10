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
    public string schadensart;
    public int damage;
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
    public Vector3 target;
    public float howfar;
    public float speed;
    public float timer;
    public float weiter;
    public bool jump;
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
            if (timer < weiter)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                jump = true;
                if (Math.Abs(this.gameObject.transform.position.x - player.transform.position.x) > Math.Abs(this.transform.position.y - player.transform.position.y))
                {
                    if(this.gameObject.transform.position.x > player.transform.position.x)
                    {
                        target = new Vector3(transform.position.x-howfar,transform.position.y,transform.position.z);
                    }
                    else
                    {
                        target = new Vector3(transform.position.x+howfar,transform.position.y,transform.position.z);
                    }
                }
                else
                {
                    //why have i wrote this.gameObject.transform instead of just this.transform.position here????
                    if(this.gameObject.transform.position.y > player.transform.position.y)
                    {
                        target = new Vector3(transform.position.x,transform.position.y-howfar,transform.position.z);
                    }
                    else
                    {
                        target = new Vector3(transform.position.x,transform.position.y+howfar,transform.position.z);
                    }
                }
            }
        }
        if (jump == true)
        {
            if (this.transform.position != target)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed*Time.deltaTime);                   
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
    public void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.transform.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("Hit", new swordattakskript.values(damage,schadensart));
            penis = true;
            jump = false;
            timer = 0;
            Vector2 playe = new Vector2 (player.position.x,player.position.y);
            Vector2 to = new Vector2 (this.gameObject.transform.position.x,this.gameObject.transform.position.y);
            Vector2 dir = to-playe;  
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(dir*force);
            Debug.Log("Done?");
            penis = false;
        }

    }
    //this didnt work
    /*public IEnumerator DaJump(Vector3 target)
    {
        while (this.transform.position != target)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed*Time.deltaTime);
        }
        yield return new WaitForSeconds(0.1f);
    }*/
}
