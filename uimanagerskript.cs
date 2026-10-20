using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
public class uimanagerskript : MonoBehaviour
{
    public List<GameObject> lasts = new List<GameObject>();
    public GameObject active;
    public GameObject talkbox;
    public TMP_Text said;
    public Image speaker;
    public bool ausgebabbelt;
    public GameObject lastone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ausgebabbelt = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sagwas(GameObject anweiser, string text, Sprite npcimage)
    {
        if(ausgebabbelt == true)
        {
            talkbox.SetActive(true);
            speaker.sprite = npcimage;
            StartCoroutine(Sprechen(text));
        }
    }
    public IEnumerator Sprechen (string text)
    {
        ausgebabbelt = false;
        string alreadysaid = null;
        foreach (char c in text)
        {
            alreadysaid += c;
            said.text = alreadysaid;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
