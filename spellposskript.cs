using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class spellposskript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string lastone;
    public bool mouseon;
    public abilitys manager;
    public Image im;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("Manger").GetComponent<abilitys>();
        im = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseon == true){
            if (Input.GetMouseButtonDown(0)){
                if (!manager.playerspellsdonned.ContainsKey(manager.selectedspell.GetComponent<spellinvspellskript>().name)){
                    if (lastone == null){
                        manager.playerspellsdonned.Add(manager.selectedspell.GetComponent<spellinvspellskript>().name,manager.playerspells[manager.selectedspell.GetComponent<spellinvspellskript>().name]);
                        lastone = manager.selectedspell.GetComponent<spellinvspellskript>().name;
                        im.sprite = manager.selectedspell.GetComponent<spellinvspellskript>().pic;
                        manager.selectedspell = null;
                        im.rectTransform.sizeDelta = new Vector2(50,50);
                    }
                    else 
                    {
                        manager.playerspellsdonned.Remove(lastone);
                        manager.playerspellsdonned.Add(manager.selectedspell.GetComponent<spellinvspellskript>().name,manager.playerspells[manager.selectedspell.GetComponent<spellinvspellskript>().name]);
                        lastone = manager.selectedspell.GetComponent<spellinvspellskript>().name;
                        im.sprite = manager.selectedspell.GetComponent<spellinvspellskript>().pic;
                        manager.selectedspell = null;
                        im.rectTransform.sizeDelta = new Vector2(50,50);
                    }
                }
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
