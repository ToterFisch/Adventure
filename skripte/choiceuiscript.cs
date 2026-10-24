using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Data;
public class choiceuiscript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text text;
    public int zahl;
    public bool mouseon;
    public uimanagerskript manni;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouseon = false;
        manni = GameObject.Find("Manger").GetComponent<uimanagerskript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseon == true && Input.GetMouseButtonDown(0))
        {
            if(text.text != null)
            {
                manni.talkbox.SetActive(false);
                manni.content.SetActive(false);
                manni.uiman.uiopen = null;
                manni.lastone.SendMessage("Done",zahl);
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseon = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseon = false;
    }
}
