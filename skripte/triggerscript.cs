using UnityEngine;

public class triggerscript : MonoBehaviour
{
    public int das;
    public string target;
    public GameObject reciever;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag(target))
        {
            reciever.SendMessage("Trigger", das);
        }
    }
}
