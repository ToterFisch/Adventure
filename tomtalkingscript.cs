using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class tomtalkingscript : MonoBehaviour
{
    public uimanagerskript mikro;
    public SpriteRenderer bild;
    public int einsatz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bild = this.gameObject.GetComponent<SpriteRenderer>();
        mikro = GameObject.Find("Manger").GetComponent<uimanagerskript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Angesprochen()
    {
        if(einsatz == 1)
        {
            mikro.Sag(this.gameObject, bild.sprite, "Praised be the gods and you as you are there eyes, ears and hands on this world. Im Tom. Can I ask you for a favor?");
            einsatz = 2;
        }
    }
}
