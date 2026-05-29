using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class spellinvspellskript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int cost;
    public string name;
    public string description;
    public Sprite pic;
    public Image picpic;
    public TMP_Text costtext;
    public TMP_Text descrtext;
    public TMP_Text nametext;
    public bool mouseon;
    public abilitys manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("Manger").GetComponent<abilitys>();
    }

    // Update is called once per frame
    void Update()
    {
        costtext.text = cost.ToString();
        nametext.text = name;
        descrtext.text = description;
        picpic.sprite = pic;
        if (mouseon == true){
            if (Input.GetMouseButtonDown(0)){
                manager.selectedspell= this.gameObject;
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
