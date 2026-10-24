using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class enemywalk : MonoBehaviour
{
    public Tilemap map;
    public Vector3 target;
    public List<Vector3> path = new List<Vector3>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //this didnt work and i found so many issues that i desided i would just go and make a new skript which will hopefully work better
    public void Move(GameObject npc, Vector3 target, float speed, List<Vector3Int> didnot)
    {
        
        Vector3Int npcposs = map.WorldToCell(npc.transform.position);
        Vector3Int targetposs = map.WorldToCell(target);
        Vector3Int[] dir = new Vector3Int[4] {npcposs + Vector3Int.up, npcposs + Vector3Int.right, npcposs + Vector3Int.down, npcposs + Vector3Int.left};
        TileBase[] dirs = new TileBase[4]{map.GetTile(dir[0]), map.GetTile(dir[1]), map.GetTile(dir[2]), map.GetTile(dir[3])};
        Debug.Log("gotmessage"+npcposs+targetposs);
        didnot.Add(npcposs);
        if (map.WorldToCell(path.LastOrDefault()) != targetposs){
            Debug.Log("notthere");
            if (Math.Abs(npcposs.x-targetposs.x) > Math.Abs(npcposs.y - targetposs.y))
            {
                Debug.Log("x");
                //if the x-difference is higher than the y-difference
                if(npcposs.x > targetposs.x)
                {
                    //if you have to walk left
                    if(dirs[3] == null && Istok(dir[3],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[3]),speed);
                        Move(npc,target,speed,didnot);
                    }
                    else if (dirs[2] == null && Istok(dir[2],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[2]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[3]);
                    }
                    else if (dirs[0] == null && Istok(dir[0],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[0]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[3]);
                        didnot.Add(dir[2]);
                    }
                    else if (dirs[1] == null && Istok(dir[1],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[1]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[3]);
                        didnot.Add(dir[2]);
                        didnot.Add(dir[0]);
                    }
                }
                else
                {
                    if(dirs[1] == null && Istok(dir[1],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[1]),speed);
                        Move(npc,target,speed,didnot);
                    }
                    else if (dirs[2] == null && Istok(dir[2],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[2]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[1]);
                    }
                    else if (dirs[0] == null && Istok(dir[0],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[0]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[1]);
                        didnot.Add(dir[2]);
                    }
                    else if (dirs[3] == null && Istok(dir[3],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[3]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[1]);
                        didnot.Add(dir[2]);
                        didnot.Add(dir[0]);
                    }
                }
            }
            else
            {
                Debug.Log("y");
                if(npcposs.y > targetposs.y)
                {
                    Debug.Log("mussnachunten");
                    if(dirs[2] == null && Istok(dir[2],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[2]),speed);
                        Move(npc,target,speed,didnot);
                    }
                    else if (dirs[1] == null && Istok(dir[1],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[1]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[2]);
                    }
                    else if (dirs[3] == null && Istok(dir[3],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[3]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[1]);
                        didnot.Add(dir[2]);
                    }
                    else if (dirs[0] == null && Istok(dir[0],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[0]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[3]);
                        didnot.Add(dir[2]);
                        didnot.Add(dir[1]);
                    }
                }
                else
                {
                    if(dirs[0] == null && Istok(dir[0],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[0]),speed);
                        Move(npc,target,speed,didnot);
                    }
                    else if (dirs[1] == null && Istok(dir[1],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[1]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[0]);
                    }
                    else if (dirs[3] == null && Istok(dir[3],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[3]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[1]);
                        didnot.Add(dir[0]);
                    }
                    else if (dirs[2] == null && Istok(dir[2],didnot))
                    {
                        Go(npc,map.CellToWorld(dir[2]),speed);
                        Move(npc,target,speed,didnot);
                        didnot.Add(dir[3]);
                        didnot.Add(dir[0]);
                        didnot.Add(dir[1]);
                    }
                }
            }
        }
    }
    public void Go(GameObject npc, Vector3 target, float speed)
    {
        path.Add(target); 
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
