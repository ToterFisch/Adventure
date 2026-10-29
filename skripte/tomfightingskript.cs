using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


public class tomfightingskript : MonoBehaviour
{
    public tomtalkingscript tomtalk;
    
    public GameObject player;
    public GameObject tom;
    public float distance;
    public float distancetokeep;
    
    public GameObject spear;
    public GameObject sword;
    
    
    public bool cando;
    public float geschw;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        tom = GameObject.Find("Tom");
        tomtalk = tom.GetComponent<tomtalkingscript>();
        tomtalk.aggro = false;
        cando = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(tomtalk.aggro == true)
        {
            
            if (Vector3.Distance(tom.transform.position, player.transform.position) > distancetokeep)
            {
                tom.transform.position = Vector3.MoveTowards(tom.transform.position, player.transform.position, speed*Time.deltaTime);
                
            }
            else
            {
                if(cando == true)
                {
                    Attack(spear);
                    Debug.Log("attack");
                    cando = false;
                    StartCoroutine(makeready());
                }
            }
        }
    }

    public IEnumerator makeready()
    {
        yield return new WaitForSeconds(geschw);
        cando=true;
    }

    public void Attack(GameObject attak)
    {
        //be aware this is the ai part of the script that i changed a little to make it work here
        //just hate this math stuff
        Vector3 position = player.transform.position;
        position.z = tom.transform.position.z;
        Vector3 direction = position - tom.transform.position;
        direction.z = 0f;
        if (direction.sqrMagnitude < 0.001f)
            return;
        direction.Normalize();
        // Objekt mit Abstand zum Spieler platzieren
        transform.position = tom.transform.position + direction * distance;
        // Objekt selbst zur Maus ausrichten
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //this part is written completley by me again
        GameObject atta = Instantiate(attak,transform.position,transform.rotation);
        atta.transform.Rotate(new Vector3(0,0,-90));
        atta.transform.SetParent(tom.transform);
    }
    public void Damage(int damage, string kind)
    {
        if (kind == tomtalk.resistenz){
            damage -= schadensreduktion;
            for (int i = damage; i > 0; i--)
            {
                if (verteidigung > 0)
                {
                    tomtalk.verteidigung --;
                }
                else
                {
                    tomtalk.leben --;
                }
            }
        }
    }
}
