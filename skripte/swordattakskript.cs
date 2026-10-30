using UnityEngine;
using System.Collections;
public class swordattakskript : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer;
    public float time;
    public class values
    {
        public int damage;
        public string kind;
        public values (int damage, string kind)
        {
            this.damage = damage;
            this.kind = kind;
        }
    }
    public values werte;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(delete());
        this.transform.SetParent(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pariert()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("npc"))
        {
            collision.transform.gameObject.SendMessage("Hit", werte);
        }
    }
    public IEnumerator delete()
    {

        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }
}