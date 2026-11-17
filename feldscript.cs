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
    public TileBase[] seeds = new TileBase[10];
    public string[] seedname = new string[10];
    public List<plant> plants = new List<plant>();
    public List<string> plantnames = new List<string>();
    public TileBase[] saladtiles = new TileBase[3];
    public inventory inv;
    public class plant
    {
        public Vector3Int where;
        public string name;
        public int status;
        public float growing;
        public TileBase currentlook;
        public TileBase[] looks;
        public plant(Vector3Int where, string name, TileBase currentlook, TileBase[] looks)
        {
            this.where = where;
            this.name = name;
            this.status = 0;
            this.growing = 0;
            this.currentlook = currentlook;
            this.looks = looks;
        }
        public void Grow()
        {
            status ++;
            currentlook = look[status];
            map.SetTile(where,look[status]);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlantDown();
        }
        
    }
    public void PlantDown()
    {
        Vector3Int selectedfield = map.WorldToCell(camera.ScreenToWorldPoint(Input.mousePosition));
        TileBase targettile = map.GetTile(selectedfield);
        Debug.Log(inv.donned[3]);
        if(targettile == erde){
            if (inv.donned[3].schadensart == "seed")
            {
                int o = System.Array.IndexOf(seedname,inv.donned[3].name);
                if (inv.donned[3].anzahl == 1){
                    map.SetTile(selectedfield, seeds[o]);
                    plants.Add(new plant(selectedfield,inv.donned[3].angriffsart)); //note for me: you have to continue here you want to make it make a plant which is added to the list of plants
                    inv.shoes.Remove(inv.donned[3]);
                    inv.donned[3] = null;
                }
                else if(inv.donned[3].anzahl > 1)
                {
                    map.SetTile(selectedfield, seeds[o]);
                    planted.Add(selectedfield);
                    plantnames.Add(seedname,inv.donned[3].name);
                    inv.donned[3].anzahl --;
                }
            }
        }
    }

}
