using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int value = 1;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.PickUp();
            Debug.Log(player.pickups);
            //Player.CoinsCount++;
            //Debug.Log(Player.CoinsCount);
            Destroy(this.gameObject);
        }
    }
}
