using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rigid.velocity = new Vector2(x * 10, y * 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("player trigger");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("player collision");
    }
}
