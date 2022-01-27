using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5f;
    public float maxDistance;
    public float damage = 3f;
    public GameObject player;
    public Vector3 aimDirection;

    // Update is called once per frame
    void Update()
    {
        //Get direction of movement
        Vector3 aimDirection = player.GetComponent<PlayerGun>().aimDirection;
        Vector3 direction = new Vector3(aimDirection.x,aimDirection.y, 0);
        //Move bullet
        Vector3 movement = direction * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
