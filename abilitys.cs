using UnityEngine;
using System.Collections.Generic;
public class abilitys : MonoBehaviour
{
    public class spell
    {
        public int costs;
        public string explanation;
        public spell(int costs, string explanation)
        {
            this.costs = costs;
            this.explanation = explanation;
        }
    }
    public Dictionary< string, spell> playerspells = new Dictionary< string, spell>()
    {
        {"Eisstachel", new spell(1,"Applyes 3 Frost to enemy")}
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
