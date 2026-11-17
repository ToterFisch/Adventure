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
    public inventory inv;
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
            Vector3Int selectedfield = map.WorldToCell(camera.ScreenToWorldPoint(Input.mousePosition));
            TileBase targettile = map.GetTile(selectedfield);
            
            if(targettile == erde){
                if (inv.donned[3].angriffsart == "seed")
                {
                    int o = System.Array.IndexOf(seedname,inv.donned[3].schadensart);
                    map.SetTile(selectedfield, seeds[o]);
                    inv.shoes.Remove(inv.donned[3]);
                }
                
            }
        }
    }
}
