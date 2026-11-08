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
    public int ungeduld = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        bild = this.gameObject.GetComponent<SpriteRenderer>();
        mikro = GameObject.Find("Manger").GetComponent<uimanagerskript>();
        walk = GameObject.Find("Manger").GetComponent<enemywalk2>();
        anna = this.gameObject.GetComponent<Animator>();
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
            if(einsatz == 1){
                walk.Move(this.gameObject,new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z), 3f, anna);
                einsatz = 100;
                mikro.uiman.uiopen = this.gameObject;
            }
        }
    }
    public void Done (int i)
    {
        
        if(einsatz == 100)
        {
            mikro.uiman.uiopen = null;
            mikro.Sag(this.gameObject,bild.sprite,"Praised be the gods and you as you are theire eyes and ears in this world.");
            einsatz = 2;

        }
        else if(einsatz == 2)
        {
            mikro.Sag(this.gameObject,bild.sprite,"The gods have send you and we are here to reseive. You are our blessing and we will serve you as long as you need.");
            einsatz = 3;
        }
        else if(einsatz == 3)
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
                einsatz = 5;
            }
            if (i == 3)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Be our guest. Do you want to understand the rules of this world, or will you be fine on your own?");
                einsatz = 10;
            }
        }
        else if(einsatz == 4)
        {
            if (i == 5){
                mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"How am I supposed to do that?", "The realms?", "I understand."});
            }
            else if (i == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"It is easyer than you would think. Just explore and discover the world, help its inhabitants and if the gods want something specific from you, they will tell.");
            }
            else if (i == 2)
            {
                mikro.Sag(this.gameObject,bild.sprite,"The three realms. There is the Fungae lands in the west, the Baat kingdom in the south and the free land in the east. And the three big dragons just lay in these parts with theyre tribes on top. One is only a two day journey from here.");
            }
            else if (i == 3)
            {
                einsatz = 3;
                Done(5);
            }
        }
        else if(einsatz == 5)
        {
            if (i == 5)
            {
                mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"How will you prepare me?","What gods do you serve?","I understand."});
            }
            if (i == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"We will give you a bed when you need it, feed you, teach you some basics and the history of the world which we preserve and give you council whenever you need it.");
            }
            if (i == 2)
            {
                mikro.Sag(this.gameObject,bild.sprite,"We dont know much of the gods, they are there, somewhere behind this portal. We dont have names, nor numbers or words of them. All we know we know from prophets. And never has someone returned from climbing into that portal.");
            }
            if(i==3)
            {
                einsatz = 3;
                Done(5);
            }        
        }
        else if(einsatz == 10)
        {
            if (i == 5)
            {
                mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"I do know the rules of this world.","Please teach me some basics",""});
            }
            if (i == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Then feel free to take the items out of these chests and be on your way. If you should have some questions after all feel free to just ask any monk");
                einsatz = 8;
            }
            if (i == 2)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Ill be glad to help you. First please take the items out of the chests over there. The old prophecies say you should leftclick on them, but i dont know what is meant.");
                einsatz = 11;
            }
            if(i==3)
            {
                einsatz = 10;
                Done(5);
            } 
        }
        else if(einsatz == 11)
        {
            einsatz = 12;
        }
        else if(einsatz == 12)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Did you collect the items?");
            einsatz = 13;
        }
        else if (einsatz == 13)
        {
            if (i == 5)
            {
                mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"Yes i did.","No i didnt.","How do i do that."});
            }
            if (i == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Perfectly, then please equip this new gear. For this topic the prophecies tell us that you should press some kind of R to open your inventory. There you should be able to interact with some kind of item slots?");
                einsatz = 14;
            }
            if (i == 2)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Please do so.");
                ungeduld ++;
            }
            if (i == 3)
            {
                mikro.Sag(this.gameObject,bild.sprite,"The old prophecies talk about leftclicking the chest to open it and then left clicking the items to collect them. But i cannot understand what that is supposed to mean.");
            }
        }
        else if (einsatz == 14)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Have you equipped your gear already?");
            einsatz = 15;
        }
        else if (einsatz == 15)
        {
            if (i == 5){
                mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"Yes i equipped it.","No i didnt.","How do i do that." });
            }
            if (i == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Great, then please follow me to the training court.");
                einsatz = 16;
            }
            if (i == 2)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Please do so.");
            }
            if (i == 3)
            {
                mikro.Sag(this.gameObject,bild.sprite,"The old prophecies say you should press some kind of R to open an inventory and then there are supposed to be item slots with which you can interact. I wonder what that means.");
            }
        }
        else if (einsatz == 16)
        {
            
            walk.Move(this.gameObject,new Vector3(-64.5f,33.5f,transform.position.z), 3f, anna);
            einsatz = 17;
            
        }
        else if (einsatz == 17)
        {
            if(transform.position == new Vector3(-64.5f, 33.5f, transform.position.z))
            {
                mikro.Sag(this.gameObject,bild.sprite,"I would really love to teach you further, but as you see the lazy developer isnt done with this area yet so you are gonna have to wait for next weeks patch");
            }
        }
    }
}
