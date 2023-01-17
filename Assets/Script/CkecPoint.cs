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
    private void OnCollisionEnter(Collision player)
    {
        if (player.transform.tag == "mort")
        {

        }
        if(player.transform.tag == "checkpoint")
        {

        }
    }


    
}
