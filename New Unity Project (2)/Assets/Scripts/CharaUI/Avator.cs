using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avator : MonoBehaviour
{
    int playernum;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        //image = GameObject.Find("text").transform.GetChild(0).GetChild(0).GetComponent<Image>();
        //GetComponent<Image>().overrideSprite = image.sprite;
        playernum = GetComponentInParent<Transform>().GetComponentInParent<Transform>().GetComponentInParent<PlayerController>().PlayerNumber;
        switch (playernum)
        {
            case 1: image.sprite = Resources.Load<Sprite>("juese1"); break;
            case 2: image.sprite = Resources.Load<Sprite>("jiqi 1"); break;
            case 3: image.sprite = Resources.Load<Sprite>("shi1"); break;
            case 4: image.sprite = Resources.Load<Sprite>("shitouren1"); break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
