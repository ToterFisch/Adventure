using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class daytimescript : MonoBehaviour
{
    public float timer;
    public float overall;
    public float current;
    public float currentmod;
    public float[] tageszeit = new float[7];
    public float lang;
    public float kurz;
    public int zeit;
    public List<GameObject> npcs = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current = lang;
        currentmod = 1;
        zeit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < tageszeit[zeit])
        {
            timer += Time.deltaTime;
            overall += Time.deltaTime;
        }
        else
        {
            timer = 0;
            zeit ++;
            zeit = zeit%6;
            foreach (GameObject obj in npcs)
            {
                obj.SendMessage("Tageszeit",zeit);
            }
            
        }
    }
}
