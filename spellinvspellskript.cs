using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class spellinvspellskript : MonoBehaviour
{
    public int cost;
    public string name;
    public string description;
    public Sprite pic;
    public Image picpic;
    public TMP_Text costtext;
    public TMP_Text descrtext;
    public TMP_Text nametext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        costtext.text = cost.ToString();
        nametext.text = name;
        descrtext.text = description;
        picpic.sprite = pic;
    }
}
