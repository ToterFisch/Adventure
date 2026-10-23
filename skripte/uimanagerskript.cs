using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class uimanagerskript : MonoBehaviour
{
    public TMP_Text[] choiceuis = new TMP_Text[3];
    public List<GameObject> lasts = new List<GameObject>();
    public GameObject active;
    public GameObject talkbox;
    public TMP_Text said;
    public Image speaker;
    public bool ausgebabbelt;
    public GameObject lastone;
    public float speakspeed;
    public GameObject content;
    public GameObject choicebox;
    public GameObject choiceui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ausgebabbelt = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ausgebabbelt == true)
        {
            talkbox.SetActive(false);
            said.gameObject.SetActive(false);
            Debug.Log("weggemacht");
            lastone.SendMessage("Done",5);
        }
        if(Input.GetKey(KeyCode.Space) && ausgebabbelt == false)
        {
            speakspeed = 0.02f;
            Debug.Log("skip");
        }
        else
        {
            speakspeed = 0.1f;
        }
    }
    public void Entscheide(GameObject anweiser, Sprite npcimage, string[] options)
    {
        talkbox.SetActive(true);
        content.SetActive(true);
        for(int i = 0; i<3; i++)
        {
            choiceuis[i].text = options[i];
        }
        lastone = anweiser;
    }
    public void Sag(GameObject anweiser, Sprite npcimage, string text)
    {
        if(ausgebabbelt == true)
        {
            talkbox.SetActive(true);
            said.gameObject.SetActive(true);
            speaker.sprite = npcimage;
            StartCoroutine(Sprechen(anweiser, text));
            lastone = anweiser;
            
        }
        
    }
    //copied this
    public IEnumerator Sprechen (GameObject anweiser, string text)
    {
        ausgebabbelt = false;
        string alreadysaid = null;
        foreach (char c in text)
        {
            alreadysaid += c;
            said.text = alreadysaid;
            yield return new WaitForSeconds(speakspeed);
            //until here
        }
        if (alreadysaid == text){
            ausgebabbelt = true;
        }
    }

}
