using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;
public class sordmovingscript : MonoBehaviour
{
    public GameObject attack;
    public enemyswordscript atti;
    public float speed;
    public float speed2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attack = transform.parent.gameObject;
        atti = attack.GetComponent<enemyswordscript>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0.6f,-0.124f,0f), speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f,0f,44f),speed2 * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        atti.Hitting(collision.gameObject);
    }
    public void Pariert()
    {
        Destroy(attack);
    }
}
