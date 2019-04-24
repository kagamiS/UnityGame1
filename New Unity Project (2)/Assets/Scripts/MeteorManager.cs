using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public int StarCnt;     //每轮星星掉落数量
    public int StarTurn;    // 星星掉落轮数
    public float timeSpan;         // 每个星星掉落的时间间隔
    public float starTurnSpan;     // 每轮星星掉落的时间间隔
    public GameObject PrefabMeteor;
    GameObject meteor;

   
    float time = 0;
    float distance;
    List<Vector3> wallsTransform;
    List<GameObject> stars = new List<GameObject>();


    Vector3 startPos;
    Vector3 endPos;
    // Start is called before the first frame update
    private void Reset()
    {
        
        timeSpan = 5;
        starTurnSpan = 5;
    }


    void Start()
    {
        
        wallsTransform = WallPsoition.Pos;
        StartCoroutine(CreateMeteor());
    }

    public IEnumerator CreateMeteor()
    {
        for (int i = 0; i < StarTurn; i++)
        {
            for (int j = 0; j < StarCnt; j++)
            {
                startPos = new Vector3(Random.Range(-31, 31), transform.position.y, 0);
                do
                {
                    endPos = new Vector3(Random.Range(-31, 31), Random.Range(-17, 17), 0);
                } while (!isPositionOK(wallsTransform, endPos));
                meteor = Instantiate(PrefabMeteor, startPos, Quaternion.identity);
                if (startPos.x < endPos.x)
                {
                    Transform transform = meteor.GetComponent<Transform>();
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                meteor.GetComponent<meteor>().startPos = startPos;
                meteor.GetComponent<Transform>().transform.position = startPos;
                meteor.GetComponent<meteor>().endPos = endPos;
                meteor.GetComponent<meteor>().dropTime = Random.Range(1.5f, 3.5f);
                meteor.transform.parent = GameObject.Find("MeteorManager").transform;
                yield return new WaitForSeconds(timeSpan);

            }
            yield return new WaitForSeconds(starTurnSpan);

        }
        StopCoroutine(CreateMeteor());
    }
    
    bool isPositionOK(List<Vector3> Pos, Vector3 vec)
    {
        foreach (var pos in Pos)
        {
            distance = Vector3.Distance(vec, pos);
            if (distance < 2.3f)
            {
                return false;
            }

        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerController.IsBoss)
        {
            StarTurn = 0;
        }

    }
    private void FixedUpdate()
    {
        
    }
}
