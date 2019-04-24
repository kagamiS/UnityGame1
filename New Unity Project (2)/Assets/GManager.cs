using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerController;

public class GManager : MonoBehaviour
{
    GameObject[] player;
    List<GameObject> players = new List<GameObject>();

    GameObject boss;
    public static int x = 1;       //游戏阶段
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        foreach (var p in player)
        {
            players.Add(p);
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (x==1)
        {
            foreach (var p in players)
            {

                if (p.GetComponent<PlayerController>().team == PlayerController.PlayerTeam.Boss)
                {
                    x = 2;
                    boss = p;
                    players.Remove(p);
                    break;
                }
            }
        }
        else
        {
            foreach (var p in players)
            {
                p.GetComponent<PlayerController>().team = PlayerController.PlayerTeam.Team;
            }
            
        }
        if (IsBoss)
        {
            if (boss.GetComponent<PlayerController>().Hp==0||
                (players[0].GetComponent<PlayerController>().Hp==0&&
                players[1].GetComponent<PlayerController>().Hp == 0 &&
                players[2].GetComponent<PlayerController>().Hp == 0 ))
            {
                SceneManager.LoadScene("GameOver");
            }
        }


    }

    void changeUIPos()
    {

    }
}
