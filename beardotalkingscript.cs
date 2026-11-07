using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class beardotalkingscript : MonoBehaviour
{
   public int leben;
    public int schadensreduktion;
    public int verteidigung;
    public int schaden;
    public string resistenz;
    public string schadensart;
    public bool aggro;
    public uimanagerskript mikro;
    public SpriteRenderer bild;
    public int einsatz;
    public enemywalk2 walk;
    public float speed;
    public Animator anna;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bild = this.gameObject.GetComponent<SpriteRenderer>();
        mikro = GameObject.Find("Manger").GetComponent<uimanagerskript>();
        walk = GameObject.Find("Manger").GetComponent<enemywalk2>();
        einsatz = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Angesprochen()
    {
        
        Done(5);
    }
    public void Trigger(int i)
    {
        if (i == 1)
        {
            walk.Move(this.gameObject,new Vector3(player.transform.positon.x,transform.position.y,transform.position.z), 3f, anna);
            Done(5);
        }
    }
    public void Done (int i)
    {
        if(einsatz == 0)
        {
            mikro.Sag(this.gameObject,bild.sprite,"You shouldnt be able to talk to me right now, are you cheating?");
        }
        if(einsatz == 1)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Praised be the gods and you as you are theire eyes and ears in this world.");
            einsatz = 2;
        }
        if(einsatz == 2)
        {
            mikro.Sag(this.gameObject,bild.sprite,"The gods have send you and we are here to reseive. You are our blessing and we will serve you as long as you need.");
            einsatz = 3;
        }
        if(einsatz == 3)
        {
            if (i == 5){
                mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"Where am I?", "Who are you?", "Please guide me."});
            }
            if (i == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"You are in the world, on the continent, in the middle of the realms, the gods send you here through the portal to see and interact with the world through youre eyes and with your limbs.");
                einsatz = 4;
            }
            if (i == 2)
            {
                mikro.Sag(this.gameObject,bild.sprite,"I am Bartolo, a monk in this kloster, as we call it. Me and my fellow monks live here to serve the gods by guarding theire portal and welcoming theire prophets. We will prepare you for the world.");
                einsatz = 21;
            }
            if (i == 3)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Be our guest. Do you want to understand the rules of this world, or will you be fine on your own?");
                einsatz = 31;
            }
        }
        if(einsatz == 4)
        {
            mikro.Entscheide(this.gameObject,bild.sprite,new string[]{})
        }
    }
}
