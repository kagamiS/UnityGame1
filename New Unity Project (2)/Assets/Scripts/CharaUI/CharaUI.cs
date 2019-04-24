using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaUI : MonoBehaviour
{
    public GameObject target;

    private int PNumber;

    // Start is called before the first frame update
    void Start()
    {
        PNumber = target.GetComponent<PlayerController>().PlayerNumber;
        Vector3 vec = Vector3.zero;
        switch (PNumber)
        {
            case 1: vec = new Vector3(0, 0, 0); break;
            case 2: vec = new Vector3(Screen.width / 4, 0, 0); break;
            case 3: vec = new Vector3(Screen.width / 2, 0); break;
            case 4: vec = new Vector3(Screen.width / 4 * 3, 0, 0); break;
            default:
                break;
        }
       
        transform.position = vec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
