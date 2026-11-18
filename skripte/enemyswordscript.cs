using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class enemyswordscript : MonoBehaviour
{
    public float time;
    public swordattakskript.values werte;
    public GameObject hitted;
    public bool disarmed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(delete());
        disarmed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Hitting(GameObject target)
    {
        Debug.Log("wannahit: "+target.transform.tag);
        
        if (target.transform.CompareTag("Player"))
        {
            hitted = target;
        }
        else if (target.transform.CompareTag("attack"))
        {
            disarmed = true;
        }
    }
    public IEnumerator delete()
    {
        yield return new WaitForSeconds(time);
        if (disarmed == false && hitted != null)
        {
            hitted.SendMessage("Hit",werte);
        }
        Destroy(gameObject);
    }
}
