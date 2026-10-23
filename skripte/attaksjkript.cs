using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject swordattack;
    public Transform player;
    public float distanceFromPlayer;
    public float speed;
    public bool cando;
    public string todo;
    public inventory invman;
    public void Start()
    {
        cando=true;
        invman = GameObject.Find("Manger").GetComponent<inventory>();
    }
    public void Update()
    {
        //this skript was written by ai because i didnt want to do it, i will update it with my own version at some point i hope
        //just hate this math stuff
        Vector3 mousePosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = player.position.z;

        Vector3 direction =
            mousePosition - player.position;

        direction.z = 0f;

        if (direction.sqrMagnitude < 0.001f)
            return;

        direction.Normalize();

        // Objekt mit Abstand zum Spieler platzieren
        transform.position =
            player.position + direction * distanceFromPlayer;

        // Objekt selbst zur Maus ausrichten
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation =
            Quaternion.Euler(0f, 0f, angle);
        //this part is written by me again



        if(Input.GetMouseButtonDown(0)){
            int layerMask = LayerMask.GetMask("truhe","npc","Default");
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layerMask);
            if(hit.collider != null){
                if (hit.collider.gameObject.transform.CompareTag("truhe")){
                    hit.collider.gameObject.SendMessage("Offnen");
                }
                else if(hit.collider.gameObject.transform.CompareTag("drop")){
                    hit.collider.gameObject.SendMessage("aufheben");
                }
                else if(hit.collider.gameObject.transform.CompareTag("npc")){
                    hit.collider.gameObject.SendMessage("Angesprochen");
                }
            }
            else if (cando==true){
                this.gameObject.SendMessage(invman.donned[3].angriffsart);
                Debug.Log(invman.donned[3].art);
                cando = false;
                StartCoroutine(makeready(3));
            }
        }
    }
    public void sword(){
        GameObject swordle = Instantiate(swordattack,transform.position,transform.rotation);
        
        swordle.transform.Rotate(new Vector3(0,0,-90));
    }
    public IEnumerator makeready(int wepint)
    {
        
        yield return new WaitForSeconds(invman.donned[wepint].geschw);
        cando=true;
    }
    
}
