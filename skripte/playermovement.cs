using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class playermovement : MonoBehaviour
{
    public float speed;
    public int walking;
    public int direction;
    public Rigidbody2D richard;
    public Animator anna;
    public inventory inventory;
    public GameObject uiopen;
    public uimanagerskript npctalk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 1;
        inventory = GameObject.Find("Manger").GetComponent<inventory>();
        npctalk = GameObject.Find("Manger").GetComponent<uimanagerskript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W) && uiopen == null){
            movement.y += 1;
        }
        if (Input.GetKey(KeyCode.S) && uiopen == null){
            movement.y -= 1;
        }
        if (Input.GetKey(KeyCode.A) && uiopen == null)
        {
            movement.x -= 1;
            direction = 1;
        }
        if (Input.GetKey(KeyCode.D) && uiopen == null)
        {
            movement.x += 1;
            direction = 2;
        }

        if (movement != Vector2.zero)
        {
            movement = movement.normalized;
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            walking = 1;
        }
        else
        {
            walking = 0;
        }

        anna.SetInteger("laufend", walking);
        anna.SetInteger("richtung", direction);

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(uiopen == inventory.invents || uiopen == null || uiopen == inventory.iteminv)
            {
                inventory.R();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiopen == inventory.invents|| uiopen == inventory.iteminv)
            {
                inventory.Escape();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (uiopen == npctalk.talkbox)
            {
                npctalk.Space();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (uiopen == npctalk.talkbox)
            {
                npctalk.Antispace();
            }
        }
    }
}
