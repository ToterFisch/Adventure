using UnityEngine;
using System.Collections;
public class trainingspuppenscript : MonoBehaviour
{
    public int leben;
    public float itch;
    public Animator anna;
    public string resistenz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anna = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(swordattakskript.values werte)
    {
        Debug.Log("hit");
        if (werte.kind != resistenz){
            for (int i = werte.damage; i > 0; i--){
                leben --;
            }
            StartCoroutine(GotHit());
        }
    }
    public IEnumerator GotHit()
    {
        anna.SetInteger("hit",1);
        yield return new WaitForSeconds(itch);
        anna.SetInteger("hit",0);
    }
}
