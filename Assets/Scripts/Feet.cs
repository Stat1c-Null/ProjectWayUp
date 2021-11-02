using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public GameObject player;
    private float speed;
    public MovingPlatform mp;

    public bool touchPlat = false;
  
    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
    }
    //Move player with platform
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            touchPlat = true;
            //player.transform.position = other.gameObject.transform.position; // for some instance in time 

        
        }

        else
        {

            touchPlat = false;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            player.transform.parent = null; // maybe 
        }
    }

    public void Update()
    {

        if (touchPlat)
        {

            player.gameObject.transform.position = new Vector2( player.gameObject.transform.position.x + speed * Time.deltaTime,
                player.gameObject.transform.position.y);

        }

    }
}
