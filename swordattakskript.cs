using UnityEngine;
using System.Collections;
public class swordattakskript : MonoBehaviour
{
    public float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(delete());
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