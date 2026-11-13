using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class beardotalkingscript : MonoBehaviour
{
    public GameObject barrel;
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
    public int todo;
    public enemywalk2 walk;
    public float speed;
    public Animator anna;
    public GameObject player;
    public GameObject bett;
    public int ungeduld = 0;
    public bool tutorial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        bild = this.gameObject.GetComponent<SpriteRenderer>();
        mikro = GameObject.Find("Manger").GetComponent<uimanagerskript>();
        walk = this.gameObject.GetComponent<enemywalk2>();
        anna = this.gameObject.GetComponent<Animator>();
        einsatz = 1;
        tutorial = true;
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
    public void Tageszeit(int i)
    {
        if(tutorial = false){
        int ran = Random.Range(1,3);
        if (i == 1)
        {
            StartCoroutine(Essenfassen());
        }
        if (i == 2)
        {
            Debug.Log("running: "+ran);
            if(ran == 1)
            {
                StartCoroutine(Talktopeasents());
            }
            if(ran == 2)
            {
                StartCoroutine(Talktopeasents());
            }
            if(ran == 3)
            {
                StartCoroutine(Talktopeasents());
            }
        }
        if (i == 3)
        {
            StartCoroutine(Essenfassen());
        }
        if (i == 4)
        {
            Debug.Log("running: "+ran);
            if(ran == 1)
            {
                StartCoroutine(Talktopeasents());
            }
            if(ran == 2)
            {
                StartCoroutine(Talktopeasents());
            }
            if(ran == 3)
            {
                StartCoroutine(Talktopeasents());
            }
        }
        if (i == 5)
        {
            StartCoroutine(Essenfassen());
        }
        if (i == 6)
        {
            StartCoroutine(Goodnight());
        }
        }
    }
    public IEnumerator Goodnight()
    {
        yield return new WaitForSeconds(Random.Range(1f,30f));
        walk.Move(this.gameObject,new Vector3(-59.5f,1.5f,this.transform.position.z),5f,anna);
        while (this.transform.position != new Vector3(-59.5f,1.5f, this.transform.position.z))
        {
            yield return new WaitForSeconds(5f);
        }
        //the bed is gonna follow soon
        bett.SendMessage("Schlafen",this.gameObject);
        yield return new WaitForSeconds(Random.Range(280f,340f));
        bett.SendMessage("Aufstehen",this.gameObject);
    }
    public IEnumerator Essenfassen()
    {
        yield return new WaitForSeconds(Random.Range(1f,30f));
        walk.Move(this.gameObject,new Vector3(-67.5f,6.5f,this.transform.position.z),5f,anna);
        while (this.transform.position != new Vector3(-67.5f,6.5f, this.transform.position.z))
        {
            yield return new WaitForSeconds(5f);
        }
        yield return new WaitForSeconds(Random.Range(60f,80f));
    }
    //I am writing this line to get hackatime to track a minute of time so i can post a clarifying devlog oh there it is (somehow it got two minutes)
    public IEnumerator Talktopeasents()
    {
        yield return new WaitForSeconds(Random.Range(1f,10f));
        int ran = Random.Range(1,3);
        if (ran == 1)
        {
            walk.Move(this.gameObject,new Vector3(-76.5f,39.5f,this.transform.position.z),3f,anna);
            while (this.transform.position != new Vector3(-76.5f, 39.5f, this.transform.position.z))
            {
                yield return new WaitForSeconds(5f);
            }
            einsatz = 1001;
            yield return new WaitForSeconds(Random.Range(20f,60f));
            walk.Move(this.gameObject,new Vector3(-83.5f,34.5f,this.transform.position.z),3f,anna);
            yield return new WaitForSeconds(Random.Range(20f,60f));
            walk.Move(this.gameObject,new Vector3(-76.5f,36.5f,this.transform.position.z),3f,anna);
        }
        else if(ran == 2)
        {
            walk.Move(this.gameObject,new Vector3(-50.5f,57.5f,this.transform.position.z),3f,anna);
            while (this.transform.position != new Vector3(-50.5f,57.5f, this.transform.position.z))
            {
                yield return new WaitForSeconds(5f);
            }
            einsatz = 1001;
            yield return new WaitForSeconds(Random.Range(20f,60f));
            walk.Move(this.gameObject,new Vector3(-53.5f,61.5f,this.transform.position.z),3f,anna);
            yield return new WaitForSeconds(Random.Range(20f,60f));
            walk.Move(this.gameObject,new Vector3(-50.5f,65.5f,this.transform.position.z),3f,anna);
        }
        else if(ran == 3)
        {
            walk.Move(this.gameObject,new Vector3(-29.5f,36.5f,this.transform.position.z),3f,anna);
            while (this.transform.position != new Vector3(-29.5f,36.5f, this.transform.position.z))
            {
                yield return new WaitForSeconds(5f);
            }
            einsatz = 1001;
            yield return new WaitForSeconds(Random.Range(20f,60f));
            walk.Move(this.gameObject,new Vector3(-23.5f,39.5f,this.transform.position.z),3f,anna);
            yield return new WaitForSeconds(Random.Range(20f,60f));
            walk.Move(this.gameObject,new Vector3(-25.5f,36.5f,this.transform.position.z),3f,anna);
        }
    }
    
    public IEnumerator Guardtheportal()
    {
        yield return new WaitForSeconds(Random.Range(1f,30f));
        walk.Move(this.gameObject,new Vector3(-54.5f,33.5f,this.transform.position.z),3f,anna);
        while (this.transform.position != new Vector3(-54.5f,33.5f, this.transform.position.z))
        {
            yield return new WaitForSeconds(5f);
        }
        einsatz = 1001;
        yield return new WaitForSeconds(Random.Range(60f,120f));
        walk.Move(this.gameObject,new Vector3(-55.5f,36.5f,this.transform.position.z),3f,anna);
        while (this.transform.position != new Vector3(-55.5f,36.5f, this.transform.position.z))
        {
            yield return new WaitForSeconds(5f);
        }
    }
    public IEnumerator TrainMagic()
    {
        yield return new WaitForSeconds(Random.Range(1f,20f));
        walk.Move(this.gameObject,new Vector3(-38.5f,33.5f,this.transform.position.z),3f,anna);
        while (this.transform.position != new Vector3(-38.5f,33.5f, this.transform.position.z))
        {
            yield return new WaitForSeconds(5f);
        }
        //at this point he is supposed to be doing some magical training but i dont have the animations or an idea what it should look like yet
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
                einsatz = 140;
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
        else if (einsatz == 140)
        {
            einsatz = 14;
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
                einsatz = 18;
            }
        }
        else if (einsatz == 18)
        {
            mikro.Sag(this.gameObject,bild.sprite,"I think that you should know how to punch, but the ancient prophecies also do have to say something for doing so. It is written that you can use the items equipped on the right and left slot by pressing the corresponding mouse button. Sounds like giberish if you ask me. But try by hitting the training dummy.");
            einsatz = 119;        
        }
        else if (einsatz == 119)
        {
            einsatz = 120;
        }
        else if (einsatz == 120)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Can you see how the puppet reacts when hit?");
            einsatz = 19;
        }
        else if (einsatz == 19)
        {
            if (i == 5)
            {
                mikro.Entscheide(this.gameObject,bild.sprite, new string[3]{"Yeah i can see it.", "No i cannot see it.", "How do i attack?"});
            }
            else if (i == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"This is how getting hit looks for most enemys and yourself. You can pary an enemy attack by hitting it with your own attack. You will notice that every type of weapon has a different way to attack, be aware that they also deal different types of damage. Every enemy and some equipment have resistences against a specific kind of damage, which will not affect them.");
                einsatz = 20;
            }
            else if (i == 2)
            {
                mikro.Sag(this.gameObject,bild.sprite,"That is odd. Try again. And make shure you hit it with an attack that does not deal poison damage.");
            }
            else if (i == 3)
            {
                mikro.Sag(this.gameObject,bild.sprite,"The old prophecies say you can use the items equipped on the right and left slot by pressing the corresponding mouse button. I hope that helps you, because i dont understand it.");
            }
        }
        else if (einsatz == 20)
        {
            mikro.Sag(this.gameObject,bild.sprite,"If you have equipped some armour it will save your health for a few hits. It regenerates itself so it can be used often. If you want you can go on training with the dummies. Talk to me if you want to fight your first enemy.");
            einsatz = 121;
        }
        else if (einsatz == 121)
        {
            einsatz = 21;
        }
        else if (einsatz == 21)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Do you want to battle your first enemy?");
            einsatz = 22;
        }
        else if (einsatz == 22)
        {
            if(i == 5){
                mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"Yes i am ready.","Please wait another minute.",""});
            }
            else if (i == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Ok, now im gonna let a slime out of the barrel over there. He will jump at you and try to hurt you. Fight and kill him, but be aware he is resistent to smash damage.");
                einsatz = 23;
            }
            else if (i == 2)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Just talk to me as soon as you are ready.");
            }
        }
        else if (einsatz == 23)
        {
            walk.Move(this.gameObject,new Vector3(-63.5f,30.5f,this.transform.position.z), 3f, anna);
            einsatz = 24;
        }
        else if (einsatz == 24)
        {
            if(this.transform.position == new Vector3(-64.5f, 30.5f, this.transform.position.z))
            {
                Debug.Log("sendthemessage");
                barrel.SendMessage("SpawnSlime",1);
                einsatz = 25;
            }
        }
        else if (einsatz == 25)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Great you have slain the slime. Now you are ready for the world. Let me show you this kloster.");
            einsatz = 26;
        }
        else if (einsatz == 26)
        {
            walk.Move(this.gameObject,new Vector3(-52.5f,17.5f,this.transform.position.z), 3f, anna);
            einsatz = 270;
        }
        else if (einsatz == 270)
        {
            einsatz = 27;
        }
        else if (einsatz == 27)
        {
            if (transform.position == new Vector3(-52.5f, 17.5f, this.transform.position.z))
            {
                mikro.Sag(this.gameObject,bild.sprite,"These are our gardens where we grow all the food we need.");
                einsatz = 28;
            }
        }
        else if (einsatz == 28)
        {
            walk.Move(this.gameObject,new Vector3(-52.5f,7.5f,this.transform.position.z), 3f, anna);
            einsatz = 290;
        }
        else if (einsatz == 290)
        {
            einsatz = 29;
        }
        else if (einsatz == 29)
        {
            if (transform.position == new Vector3(-52.5f,7.5f,this.transform.position.z))
            {
                mikro.Sag(this.gameObject,bild.sprite,"This is our living house. Here we sleep, cook, eat and make all the stuff we need. You can always come here to eat at our table.");
                einsatz = 30;
            }
        }
        else if (einsatz == 30)
        {
            walk.Move(this.gameObject,new Vector3(-53.5f,49.5f,this.transform.position.z), 3f, anna);
            einsatz = 310;
        }
        else if (einsatz == 310)
        {
            einsatz = 31;
        }
        else if (einsatz == 31)
        {
            if (transform.position == new Vector3(-53.5f,49.5f,this.transform.position.z))
            {
                mikro.Sag(this.gameObject,bild.sprite,"This is one of the three great entrance halls of the kloster. Here the pilgrims come to bring theire biddings and hope that the prophets will help them. They would appreciate it if you found the time to help them.");
                einsatz = 32;
            }
        }
        else if (einsatz == 32)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Be on your way then, i will no longer hold you of your holy duties. Im shure the gods will bless you with on of theire orders soon enough. And as i said, you can always come back.");
            einsatz = 33;
        }
        else if (einsatz == 33)
        {
            walk.Move(this.gameObject,new Vector3(-52.5f,7.5f,this.transform.position.z), 3f, anna);
            einsatz = 498;
            tutorial = false;
        }
        
        
        else if (einsatz == 498)
        {
            einsatz = 499;
        }
        else if (einsatz == 499)
        {
            mikro.Sag(this.gameObject,bild.sprite,"How can i help you?");
            einsatz = 500;
        }
        else if (einsatz == 500)
        {
            if(i == 5){
                mikro.Entscheide(this.gameObject,bild.sprite,new string[3]{"Why am i here, why have the gods send me here.","Can i help you somehow.","Forget it"});
            }
            else if (i == 1)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Dont worry so much. You are doing fine. Just do whatever you want, or help the people around here.");
                einsatz = 498;
            }
            else if (i == 2)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Well it would help me if you could get rid of the rats in the cellar of the living house.");
                einsatz = 470;
            }
            else if (i == 3)
            {
                mikro.Sag(this.gameObject,bild.sprite,"Well goodbye then.");
                einsatz = 498;
            }
        }


        else if (einsatz == 1001)
        {
            mikro.Sag(this.gameObject,bild.sprite,"Oh hey, youre here again. I was just helping these pour souls. How can i help you?");
            einsatz = 500;
        }
    }
}
