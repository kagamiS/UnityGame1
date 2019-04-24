using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float dropTime;
    public GameObject prefabStar;
    public MeteorType type;
    GameObject star;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == endPos)
        {
            switch (type)
            {
                case MeteorType.PointStar:
                    star = Instantiate(prefabStar, transform.position, Quaternion.identity);
                    break;
                case MeteorType.ItemStar:
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, Vector3.Distance(startPos, endPos) / dropTime * Time.deltaTime);
        if (transform.localScale.x > 0)
        {
            transform.localScale += new Vector3(5/dropTime, 5 / dropTime, 0)*Time.deltaTime;
        }
        else
        {
            transform.localScale += new Vector3(-5 / dropTime, 5 / dropTime, 0) * Time.deltaTime;
        }
    }


    public enum MeteorType
    {
        PointStar,
        ItemStar,
    }
}
