using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class fungaltalkingscript : MonoBehaviour
{
    public uimanagerskript mikro;
    public SpriteRenderer bild;
    public int einsatz;
    public int todo;
    public enemywalk2 walk;
    public float speed;
    public Animator anna;
    public GameObject player;
    public GameObject bett;
    public int ungeduld = 0;
    public int merken;
    public bool test;
    public int letztetageszeit;
    public beardotalkingscript beardo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        bild = this.gameObject.GetComponent<SpriteRenderer>();
        mikro = GameObject.Find("Manger").GetComponent<uimanagerskript>();
        walk = this.gameObject.GetComponent<enemywalk2>();
        anna = this.gameObject.GetComponent<Animator>();
        einsatz = 1;
        met = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Done(int i)
    {
        if (met == false)
        {
            met = true;
            mikro.Sag(this.gameObject,bild.sprite,"Praised be the gods and you as you are theire eyes and ears on this world. I hope you have found your way into this world quite nicely. I am Fungal the main gardener of this kloster.");

        }
        if (met == true)
        {
            if (einsatz == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"I love our gardens and all the plants. Everything grows and is usefull. My live is perfect here.");
                einsatz = 2;
            }
            else if (einsatz == 2)
            {
                if (i == 5)
                {
                    mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"How can i make things grow. It must be very complex?","What did you do before you came to this kloster?","May your plants grow high and fertile ill be on my way."});
                }
                if (i == 1)
                {
                    mikro.Sag(this.gameObject,bild.sprite,"Oh it is actually quite easy. Do you want me to teach you how to do that. Plant friends can always count on my help!");
                    einsatz = 3;
                }
                if (i == 2)
                {
                    mikro.Sag(this.gameObject,bild.sprite,"It is an old tale, that happened a long time ago. You may not be able to tell from how i look, but i am very old. Do you want to hear my story?");
                    einsatz = 4;
                }
                if(i == 3)
                {
                    mikro.Sag(this.gameObject,bild.sprite,"May the gras grow green where ever you go.");
                    einsatz = 1;
                }
            }
            else if (einsatz == 3)
            {
                if (i == 5)
                {
                    mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"It would please me to know how to tame the nature.","I short of time to do such things in the moment",""});
                }
                if (i == 1)
                {
                    mikro.Sag(this.gameObject,bild.sprite,"So lets start with planting. To plant crops you need some farming soil like this around me and seeds. You can take some out of the chest over there. Then you just take the seeds and hit the ground with it.");
                    einsatz = 6;
                }
                if (i == 2)
                {
                    mikro.Sag(this.gameObject,bild.sprite,"Well i understand that you are one young lad and send from the gods. You will have a lot to do.");
                    einsatz = 1;
                }
            }
            else if (einsatz == 4)
            {
                if (i == 5)
                {
                    mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"I would love to hear what you have to tell.","Sadly i dont have the time for that in the moment.",""});
                }
                if (i == 1)
                {
                    mikro.Sag(this.gameObject,bild.sprite,"So hear now my story it is an old tale full of grim dispair. When i was a young lad the piltzs lived free and gay beneath the sky in the wonderfull valley of flowers.");
                    einsatz = 5;
                }
                if (i == 2)
                {
                    mikro.Sag(this.gameObject,bild.sprite,"Well i understand that you are one young lad and send from the gods. You will have a lot to do.");
                    einsatz = 1;
                }

            }
            else if (einsatz == 5)
            {
                mikro.Sag(this.gameObject,bild.sprite,"But one day one of the great three dragons began to move and to fly to find a new place to lay down in sleep. And with his kinship on his back he choose this valley to be their new home.");
                einsatz = 7;
            }
            else if(einsatz == 6)
            {
                einsatz = 8;
            }
            else if(einsatz == 7)
            {
                mikro.Sag(this.gameObject,bild.sprite,"We could see them coming from a great distance, and when we realized the danger all our great heroes and soldiers gathered to defend our home. Me, a farmers boy and my family hid in the townhall of tulip town.");
                einsatz = 9;
            }
            else if(einsatz == 8)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Do you see the little seedling sprouting out of the dirt?");
                einsatz = 10;
            }








            else if(einsatz == 10)
            {
                if (i == 5)
                {
                    mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"Yes i can see them.","No i can not see them.","How do i plant something again?"});
                }
                if (i == 1)
                {
                    mikro.Sag(this.gameObject,bild.sprite,"It is the great wonder of life. All it takes now for it to become a fullgrown plant is time and some water here and then. When it is fully grown you can just hit it again to harvest it. Did you understand everything?");
                }
                if (i == 2)
                {
                    mikro.Sag(this.gameObjectt,bild.sprite,"Then you probably havent planted it yet. try again doing so.");
                    einsatz = 8;
                }
            }
        }
    }
}
