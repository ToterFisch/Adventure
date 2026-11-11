using UnityEngine;

public class barrelscript : MonoBehaviour
{
    public GameObject slime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //i need one for every direction so i gotta make 4 functions or one with an if statement nvm found a solution
    public void SpawnSlime(int i)
    {
        Vector3[] directions = new Vector3[4]{new Vector3(this.transform.position.x,this.transform.position.y+0.5f,this.transform.position.z),new Vector3(this.transform.position.x+0.5f,this.transform.position.y,this.transform.position.z),new Vector3(this.transform.position.x,this.transform.position.y-0.5f,this.transform.position.z),new Vector3(this.transform.position.x-0.5f,this.transform.position.y,this.transform.position.z)};
        Instantiate(slime,directions[i],this.transform.rotation);
    }
}
