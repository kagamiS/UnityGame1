using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_back : MonoBehaviour
{
    public GameObject target;
    private RectTransform hpRect;
    private float maxHP;
    private float hp;
    private int PNumber;
    // Start is called before the first frame update
    private void Reset()
    {
        
    }
    void Start()
    {
        hpRect = transform.GetChild(0).GetComponent<RectTransform>();
        maxHP = target.GetComponent<PlayerController>().MaxHp;
        PNumber = target.GetComponent<PlayerController>().PlayerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        hp = target.GetComponent<PlayerController>().Hp;

        //Vector3 vec = Vector3.zero;
        //switch (PNumber)
        //{
        //    case 1: vec = new Vector3(100, 50, 0); break;
        //    case 2: vec = new Vector3(300, 50, 0); break;
        //    case 3: vec = new Vector3(500, 50, 0); break;
        //    case 4: vec = new Vector3(700, 50, 0); break;
        //    default:
        //        break;
        //}

        //transform.position = vec;
        //Vector3 vec = Camera.main.WorldToScreenPoint(target.transform.position);
        //transform.position = vec+new Vector3(0,40,0);
        


        hpRect.localScale = new Vector3(hp / maxHP, 1, 1);

    }
}
