using UnityEngine;
using System.Collections;
public class swordattakskript : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer;
    public float time;
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
    public IEnumerator delete()
    {

        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }
}