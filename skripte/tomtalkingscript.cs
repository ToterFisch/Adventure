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
        if (einsatz == 8)
        {
            mikro.Sag(this.gameObject, bild.sprite, "Praised be the gods and you as their prophet!");
        }
        if (einsatz == 9)
        {
            mikro.Sag(this.gameObject, bild.sprite, "Oh no no. How can i get out of here?");
        }
    }
    public void Done(int i)
    {
        if (einsatz == 2)
        {
            mikro.Entscheide(this.gameObject,bild.sprite, new string[3] {"What... me... the gods?...","How can I help you?",""});
            einsatz = 3;
        }
        else if (einsatz == 3)
        {
            if(i == 1)
            {
                mikro.Sag(this.gameObject, bild.sprite, "Yeah, you are a prophet arent you? So the gods send you here to see and interact with the world they created.");
                einsatz = 4;
            }
            else if(i == 2)
            {
                mikro.Sag(this.gameObject, bild.sprite, "I would want to ask you if you could deliver my prayer to the gods. You see i am great distress and need their help.");
                einsatz = 5;
            }
        }
        else if (einsatz == 5)
        {
            mikro.Sag(this.gameObject, bild.sprite, "So i grew up in a little village in the valley of flowers not far from here, but as i got older i wanted to see the world"+
            " outside of the valley. So one day i packed up my things and just started the journey because i couldnt wait any longer... well i got here and then soon my money went out."
            + "So now im kinda stuck here and need to get some money or a way to move on. Could you please ask the gods for that.");
            einsatz = 6;
        }
        else if (einsatz == 6)
        {
            mikro.Entscheide(this.gameObject, bild.sprite, new string[3] {"I will take your prayer to the gods.", "This is your own mess, get out of it yourself.","The gods command me to tend to your problems myself and now."});
            einsatz = 7;
        }
        else if (einsatz == 7)
        {
            if(i == 1 || i == 3)
            {
                mikro.Sag(this.gameObject, bild.sprite, "Thank you, praised be the gods and you as their prophet");
                einsatz = 8;
            }
            else if(i == 2)
            {
                mikro.Sag(this.gameObject, bild.sprite, "I praise the gods and help the prophets how do i deserve this");
                einsatz = 9;
            }
        }
        else if (einsatz == 4)
        {
            mikro.Entscheide(this.gameObject, bild.sprite, new string[3] {"Oh Yeah of course, how could i forget that.", "How do you know that and me not?", "How do i show my god this world?"});
            einsatz = 10;
        }
        else if (einsatz == 10)
        {
            if(i == 1)
            {
                mikro.Sag(this.gameObject, bild.sprite, "I would want to ask you if you could deliver my prayer to the gods. You see i am great distress and need their help.");
                einsatz = 5;
            }
            if (i == 2)
            {
                mikro.Sag(this.gameObject, bild.sprite, "Well you are only the second prophet i ever met. The other one knew about this circumstance, he actually told me about it."
                + "If you want to know more about it you should maybe ask a clerik in the monastery at the portal. Could i still ask you for some divine help?");
                einsatz = 5;
            }
            if (i == 3)
            {
                mikro.Sag(this.gameObject, bild.sprite, "Another prophet once told me he does it by exploring the world and helping people, maybe that could also work for you.");
                einsatz = 2;
            }
        }
    }
}
