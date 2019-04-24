using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPsoition : MonoBehaviour
{
    Transform[] wallTransform;
    public static List<Vector3> Pos = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        wallTransform = GetComponentsInChildren<Transform>();
        foreach (var wall in wallTransform)
        {
            Pos.Add(wall.transform.position);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
