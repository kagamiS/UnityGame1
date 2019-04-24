using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesManager : MonoBehaviour
{
    List<Vector3> wallsTransform;
    public int stoneCnt = 10;
    GameObject prefabStone;
    GameObject stone;
    float distance;
    Vector3 stonePos;
    List<GameObject> stones = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        wallsTransform = WallPsoition.Pos;
        
        for (int i = 0; i < stoneCnt; i++)
        {
             
            do
            {
                stonePos = new Vector3(Random.Range(-31, 31), Random.Range(-17, 17), 0);
            } while (!isPositionOK(wallsTransform,stonePos) || !isPositionOK(stones, stonePos));
            

            stone = Instantiate(prefabStone, stonePos,Quaternion.identity);
            stone.transform.parent = GameObject.Find("Stones").transform;
            stones.Add(stone);
        }
        
    }

    bool isPositionOK(List<Vector3>Pos,Vector3 vec)
    {
        foreach (var pos in Pos)
        {
            distance = Vector3.Distance(vec, pos);
            if (distance<2.3f)
            {
                return false;
            }
            
        }
        return true;
    }
    bool isPositionOK(List<GameObject>objs ,Vector3 vec)
    {
        if (objs.Count==0)
        {
            return true;
        }
        else
        {
            foreach (var obj in objs)
            {
                distance = Vector3.Distance(vec, obj.transform.position);
                if (distance<2.3f)
                {
                    return false;
                }
            }
            return true;
        }
    }



    private void Awake()
    {
        prefabStone = Resources.Load<GameObject>("stone");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
