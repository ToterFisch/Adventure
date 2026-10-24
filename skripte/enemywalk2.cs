using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class enemywalk2 : MonoBehaviour
{
    public Tilemap map;
    public Vector3 target;
    public List<Vector3Int> path = new List<Vector3Int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(GameObject npc, Vector3 target, float speed)
    {
        
    }
    /*public Vector3Int Pathfinding(Vector3Int npc, Vector3Int target, List<Vector3Int> didnot)
    {
        Vector3Int[] dir = new Vector3Int[4] {npc + Vector3Int.up, npc + Vector3Int.right, npc + Vector3Int.down, npc + Vector3Int.left};
        TileBase[] dirs = new TileBase[4]{map.GetTile(dir[0]), map.GetTile(dir[1]), map.GetTile(dir[2]), map.GetTile(dir[3])};
        if(npc != target)
        {
            didnot.Add(npc);
            if (Math.Abs(npc.x-target.x) > Math.Abs(npc.y - target.y))
            {
                if(npc.x > target.x)
                {
                    if(dirs[3] == null && Istok(dir[3],didnot))
                    {
                        path.Add(Pathfinding(dir[3],target,didnot));
                        path.Add(npc);
                    }
                }
            }
        }
    }*/
    public void Walking()
    {
        
    }
    public bool Istok(Vector3Int o, List<Vector3Int> didnot)
    {
        for (int i = 0; i < didnot.Count; i++)
        {
            if (o == didnot[i])
            {
                return false;
            }
        }
        return true;
    }
}
