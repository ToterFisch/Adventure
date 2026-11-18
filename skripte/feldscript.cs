using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class feldscript : MonoBehaviour
{

    public Camera camera;
    public Tilemap map;
    public TileBase erde;
    public TileBase[][] seeds = new TileBase[10][];
    public string[] seedname = new string[10];
    
    public List<string> plantnames = new List<string>();
    public TileBase[] saladtiles = new TileBase[3];
    public inventory inv;
    public float[] wachszeiten = new float[10];
    public GameObject drop;
    public inventory.item[] crops= new inventory.item[10];
    public class plant
    {
        public Vector3Int where;
        public string name;
        public int status;
        public float wachszeit;
        public float growing;
        public TileBase[] looks;
        public Tilemap map;
        public plant(Vector3Int where, string name, TileBase[] looks, Tilemap map, float wachszeit)
        {
            this.where = where;
            this.name = name;
            this.status = 0;
            this.growing = 0;
            this.looks = looks;
            this.map = map;
            this.wachszeit = wachszeit;
            
        }
        public void Grow()
        {
            if(status < 2){
                if (growing >= wachszeit)
                {
                    status ++;
                    map.SetTile(where,looks[status]);
                    growing = 0;
                }
            }
        }
    }
    public List<plant> plants = new List<plant>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
        seeds[0] = saladtiles;
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (plant pflanz in plants)
        {
            pflanz.growing += Time.deltaTime;
            pflanz.Grow();
        }
    }
    public void PlantDown()
    {
        Vector3Int selectedfield = map.WorldToCell(camera.ScreenToWorldPoint(Input.mousePosition));
        TileBase targettile = map.GetTile(selectedfield);
        Debug.Log(inv.donned[3]);
        plant pflanz = IsPlant(selectedfield);
        if(targettile == erde){
            if (inv.donned[3].angriffsart == "seed")
            {
                int o = System.Array.IndexOf(seedname,inv.donned[3].schadensart);
                if (inv.donned[3].anzahl == 1){
                    map.SetTile(selectedfield, seeds[o][0]);
                    plants.Add(new plant(selectedfield,inv.donned[3].schadensart,seeds[o],map,wachszeiten[o]));
                    inv.shoes.Remove(inv.donned[3]);
                    inv.donned[3] = null;
                }
                else if(inv.donned[3].anzahl > 1)
                {
                    map.SetTile(selectedfield, seeds[o][0]);
                    plants.Add(new plant(selectedfield,inv.donned[3].schadensart,seeds[o],map,wachszeiten[o]));
                    inv.donned[3].anzahl --;
                }
            }
        }
        
    }
    public void Harvest()
    {
        Vector3Int selectedfield = map.WorldToCell(camera.ScreenToWorldPoint(Input.mousePosition));
        TileBase targettile = map.GetTile(selectedfield);
        Debug.Log(inv.donned[3]);
        plant pflanz = IsPlant(selectedfield);
        if (pflanz != null)
        {
            if (pflanz.status == 2){
                map.SetTile(pflanz.where, erde);
                plants.Remove(pflanz);
                GameObject crop = Instantiate(drop, pflanz.where, transform.rotation);
                Debug.Log("innendrinne");
                dropskript script = crop.GetComponent<dropskript>();
                if(script != null){
                    script.das = crops[System.Array.IndexOf(seedname,pflanz.name)];
                }
            Debug.Log("penis");
            }
        }
    }
    public plant IsPlant(Vector3Int wo)
    {
        foreach (plant pflanz in plants)
        {
            if (pflanz.where == wo)
            {
                return pflanz;
            }
        }
        return null;
    }
}
