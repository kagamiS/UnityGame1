using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControll : MonoBehaviour
{
    public GameObject Player;


    private Camera m_Camera;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = GetComponent<Camera>();
        //offset = m_Camera.transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Screen.SetResolution(1920, 1080,true);
        //transform.position = Player.transform.position + offset;
        if (Input.GetAxis("Mouse ScrollWheel")<0)
        {
            m_Camera.orthographicSize += 0.3f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            m_Camera.orthographicSize -= 0.3f;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
