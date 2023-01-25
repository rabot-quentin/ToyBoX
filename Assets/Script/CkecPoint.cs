using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkecPoint : MonoBehaviour
{
    public Vector3 respawnPoint; 
   
    void Start()
    {
        respawnPoint = transform.position;
    }
    private void OnCollisionEnter(Collision Player)
    {
        if (Player.transform.tag == "mort")
        {
            transform.position = respawnPoint;
        }
        if(Player.transform.tag == "checkpoint")
        {
            respawnPoint = Player.transform.position;
        }
    }    
}
