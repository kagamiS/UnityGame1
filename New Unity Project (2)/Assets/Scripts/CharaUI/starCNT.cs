using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starCNT : MonoBehaviour
{
    public GameObject player;
    Text starCnt;
    // Start is called before the first frame update
    void Start()
    {
        starCnt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        starCnt.text = player.GetComponent<PlayerController>().gettedStar.ToString();
    }
}
