using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IaPatroulle : MonoBehaviour
{/*   */

    NavMeshAgent agentPatrouille;

    

    // partie pour la patrouille du garde
    public Transform[] waypoints; // liste des different point de la patrouille du garde
    int waypointIndex;
    Vector3 target; // le point que le garde va viser 

    //Partie pour la traque du joueur 
    public GameObject Player;
    public float Distance;
    public float Detection;

    public bool Patrol;

    public bool isAngered;
    void Start()
    {
        Patrol = true;
        agentPatrouille = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

   
    void Update()
    {
        
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);// calcule la distance avec le joueur 
        
        if (Distance <= Detection) // verifie si le joueur est dasn la zone de dectetion du garde
        {
            isAngered = true; // on lance le garde a la poursuite du joueur 
            Patrol = false; // on arrete la patroule du garde
          //  Debug.Log("le player est dans la zone du garde ");
        }
        else if (Distance > Detection)// si le garde est or de porter de la zone de dection du garde 
        {
            isAngered = false; // on arrete la traque 
            Patrol = true; // on reprend la patrouile 
            UpdateDestination(); // on reactualise l'objectif du garde 
          //  Debug.Log("le player est en securiter");
        }
        
        if (Patrol == true) // si le garde est en patrouille 
        {
            if (Vector3.Distance(transform.position, target) < 1)
            {
                IterateWaypointIndex();
                UpdateDestination();
               // Debug.Log("ma bite sa marche");
            }
        }
        if (Patrol == false) // si le garde traque le joueur 
        {
            //Si l'enemie detecte le joueur 
            if (isAngered == true)
            {
                agentPatrouille.SetDestination(Player.transform.position);
            }
            //si l'enemie ne detecte plus le joueur 
            if (isAngered == false)
            {
                Patrol = true;
               // Debug.Log("on reprend la patroulle");

            }
        }
    }
    
    void UpdateDestination() // permet de choisir le point ou le garde doit aller 
    {
        target = waypoints[waypointIndex].position;
        agentPatrouille.SetDestination(target);
       // Debug.Log("on choisi la cible");


    }    
    void IterateWaypointIndex()// Permet de changer de waypoint et reset quand on a finit la liste de waypoint
    {
        //Debug.Log("point suivant" + waypointIndex);
        waypointIndex += 1;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
           // Debug.Log("on recomence le tour");

        }
    }

    /* Attention les waypoint ne doive pas etre sur le sol il faut qu'il soit au dessue 
     si le sol est a 0 alors les waypoints doive etre a 1 
     */
}
