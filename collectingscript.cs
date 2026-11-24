using UnityEngine;

public class collectingscript : MonoBehaviour
{
    public GameObject parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = parent.transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("drop"))
        {
            dropskript script = collision.gameObject.GetComponent<dropskript>();
            if (script.das.angriffsart == "seed")
            {
                script.aufheben(parent);
            }
        }
    }
}
