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
    public void Move(GameObject npc, Vector3 target, float speed, Animator anna)
    {
        Vector3Int npcposs = map.WorldToCell(npc.transform.position);
        Vector3Int targetposs = map.WorldToCell(target);
        path.Add(Pathfinding(npcposs,targetposs,new List<Vector3Int>()));
        
        StartCoroutine(Walking(npc,speed,anna));
        
    }
    public Vector3Int Pathfinding(Vector3Int npc, Vector3Int target, List<Vector3Int> didnot)
    {
        Vector3Int[] dir = new Vector3Int[4] {npc + Vector3Int.up, npc + Vector3Int.right, npc + Vector3Int.down, npc + Vector3Int.left};
        TileBase[] dirs = new TileBase[4]{map.GetTile(dir[0]), map.GetTile(dir[1]), map.GetTile(dir[2]), map.GetTile(dir[3])};
        int ydir = 5;
        int xdir = 5;
        if(npc != target)
        {
            didnot.Add(npc);
            if (Math.Abs(npc.x-target.x) > Math.Abs(npc.y - target.y))
            {
                if(npc.y > target.y)
                {
                    ydir = 2;
                }
                else
                {
                    ydir = 0;
                }
                if(npc.x > target.x)
                {
                    xdir = 3;
                    if(dirs[xdir] == null && Istok(dir[xdir],didnot))
                    {
                        path.Add(Pathfinding(dir[xdir],target,didnot));
                        return npc;
                    }
                    else if(dirs[ydir] == null && Istok(dir[ydir],didnot))
                    {
                        path.Add(Pathfinding(dir[ydir],target,didnot));
                        return npc;
                    }
                    else if (dirs[Math.Abs(ydir-2)] == null && Istok(dir[Math.Abs(ydir - 2)], didnot))
                    {
                        path.Add(Pathfinding(dir[Math.Abs(ydir-2)],target,didnot));
                        return npc;
                    }
                    else
                    {
                        //not quite shure what to do here  kinda should head back or something
                        return Vector3Int.zero;
                    }
                }
                else
                {
                    xdir = 1;
                    if(dirs[xdir] == null && Istok(dir[xdir], didnot)){
                        path.Add(Pathfinding(dir[xdir],target,didnot));
                        return npc;
                    }
                    else if(dirs[ydir] == null && Istok(dir[ydir],didnot))
                    {
                        path.Add(Pathfinding(dir[ydir],target,didnot));
                        return npc;
                    }
                    else if (dirs[Math.Abs(ydir-2)] == null && Istok(dir[Math.Abs(ydir - 2)], didnot))
                    {
                        path.Add(Pathfinding(dir[Math.Abs(ydir-2)],target,didnot));
                        return npc;
                    }
                    else
                    {
                        //not quite shure what to do here  kinda should head back or something
                        return Vector3Int.zero;
                    }
                }
                
            }
            else
            {
                if(npc.x > target.x)
                {
                    xdir = 3;
                }
                else
                {
                    xdir = 1;
                }
                if(npc.y > target.y)
                {
                    ydir = 2;
                    if(dirs[ydir] == null && Istok(dir[ydir],didnot))
                    {
                        path.Add(Pathfinding(dir[ydir],target,didnot));
                        return npc;
                    }
                    else if(dirs[xdir] == null && Istok(dir[xdir],didnot))
                    {
                        path.Add(Pathfinding(dir[xdir],target,didnot));
                        return npc;
                    }
                    else if (dirs[(xdir +10)%4] == null && Istok(dir[(xdir +10)%4], didnot))
                    {
                        path.Add(Pathfinding(dir[(xdir +10)%4],target,didnot));
                        return npc;
                    }
                    else
                    {
                        //not quite shure what to do here  kinda should head back or something
                        return Vector3Int.zero;
                    }
                }
                else
                {
                    ydir = 0;
                    if(dirs[ydir] == null && Istok(dir[ydir],didnot))
                    {
                        path.Add(Pathfinding(dir[ydir],target,didnot));
                        return npc;
                    }
                    else if(dirs[xdir] == null && Istok(dir[xdir],didnot))
                    {
                        path.Add(Pathfinding(dir[xdir],target,didnot));
                        return npc;
                    }
                    else if (dirs[(xdir +10)%4] == null && Istok(dir[(xdir +10)%4], didnot))
                    {
                        path.Add(Pathfinding(dir[(xdir +10)%4],target,didnot));
                        return npc;
                    }
                    else
                    {
                        //not quite shure what to do here  kinda should head back or something
                        return Vector3Int.zero;
                    }
                }
            }
        }
        else
        {
            return Vector3Int.zero;
        }
    }
    //for later: xdir + 10 mod4
    public IEnumerator Walking(GameObject npc, float speed, Animator anna)
    {
        Debug.Log("iswalking"+npc.transform.name);
        anna.SetInteger("laufend", 1);
        while (path.Count > 1){
            if(npc.transform.position != new Vector3 (map.GetCellCenterWorld(path.LastOrDefault()).x,map.GetCellCenterWorld(path.LastOrDefault()).y,npc.transform.position.z))
            {
                npc.transform.position = Vector3.MoveTowards(npc.transform.position, new Vector3 (map.GetCellCenterWorld(path.LastOrDefault()).x,map.GetCellCenterWorld(path.LastOrDefault()).y,npc.transform.position.z), speed * Time.deltaTime);
            }
            else
            {
                path.Remove(path.LastOrDefault());
            }
            if(npc.transform.position.x > map.GetCellCenterWorld(path.LastOrDefault()).x)
            {
                //links
                anna.SetInteger("richtung", 1);
            }
            else
            {
                anna.SetInteger("richtung", 0);
            }
            yield return new WaitForSeconds(0.01f);
        }
        anna.SetInteger("laufend", 0);
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
