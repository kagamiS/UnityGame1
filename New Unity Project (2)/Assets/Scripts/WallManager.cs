using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
        
        for (int i = -31; i <= 31; i = i + 2)
        {
            for (int j = 17; j >= -17; j -= 2)
            {
                if (i==-31||i==31||j==17||j==-17)
                {
                    GameObject obj = Instantiate(wall, new Vector3(i, j, 0), Quaternion.identity);
                    GameObject parent = GameObject.Find("Walls");
                    obj.transform.parent = parent.transform;
                }





            }
        }
    }
    private void Reset()
    {
        wall = new GameObject();
        wall.AddComponent<BoxCollider2D>();
        wall.AddComponent<SpriteRenderer>();
        wall.AddComponent<Rigidbody2D>();
        wall.GetComponent<Rigidbody2D>().gravityScale = 0;
        wall.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        wall.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.6f, 1.6f);
        wall.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Block");
        wall.transform.position = new Vector3(-31, 17, 0);
        wall.layer = 10;
        wall.tag = "Wall";
    ;
    }
    private void Awake()
    {
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
