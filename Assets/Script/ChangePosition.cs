using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public Transform[] waypoint;
    [SerializeField]
    private float timer = 0f;
    public float timeGood = 10f; 
    Vector3 Position;

    public void Update()
    {
        timer++; 
        if (timer == timeGood)
        {
            Debug.Log("Changement place");
            Position = waypoint[Random.Range(0, waypoint.Length)].position;
            transform.position = Position;
            timer = 0f; 
        }
       

    }

 

}
