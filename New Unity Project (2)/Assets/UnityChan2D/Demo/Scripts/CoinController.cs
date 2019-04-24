using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public AudioClip getCoin;
    public GameObject Coin;
    private GameObject newcoin;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {

            //PointController.instance.AddCoin();
            AudioSourceController.instance.PlayOneShot(getCoin);

            Vector3 newpos = Camera.main.ViewportToWorldPoint
            (new Vector3(Random.Range(0.1f, 0.9f),
            Random.Range(0.1f, 0.9f), 0));
            newcoin = Instantiate(Coin,
                new Vector3(newpos.x, newpos.y, 0),
                Quaternion.identity);

            other.gameObject.GetComponent<PlayerController>().StarCnt++;

            Destroy(gameObject);
        }
    }
    private void Update()
    {
        
    }
}
