using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IaPatrouilleAleatoire : MonoBehaviour
{
    NavMeshAgent agentAleatoire;

    public int NouveauTatget;

    [SerializeField]
    private Vector3 ZonePatrol;

    //public GameObject Waypoint;

    // partie pour la patrouille du garde
   
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
        agentAleatoire = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {

        Distance = Vector3.Distance(Player.transform.position, this.transform.position);// calcule la distance avec le joueur 

        if (Distance <= Detection) // verifie si le joueur est dasn la zone de dectetion du garde
        {
            isAngered = true; // on lance le garde a la poursuite du joueur 
            Patrol = false; // on arrete la patroule du garde
            //Debug.Log("le player est dans la zone du garde ");
        }
        else if (Distance > Detection)// si le garde est or de porter de la zone de dection du garde 
        {
            isAngered = false; // on arrete la traque 
            Patrol = true; // on reprend la patrouile 
            UpdateDestination(); // on reactualise l'objectif du garde 
            //Debug.Log("le player est en securiter");
        }

        if (Patrol == true) // si le garde et en patrouille 
        {
            if (Vector3.Distance(transform.position, target) < 1)
            {

                StartCoroutine(SpawnTarget());
                Debug.Log("ma bite sa marche");
            }
        }
        if (Patrol == false) // si le garde traque le joueur 
        {
            //Si l'enemie detecte le joueur 
            if (isAngered == true)
            {
                agentAleatoire.SetDestination(Player.transform.position);
            }
            //si l'enemie ne detecte plus le joueur 
            if (isAngered == false)
            {
                Patrol = true;
              //  Debug.Log("on reprend la patroulle");

            }
        }
    }

    void UpdateDestination() // permet de choisir le point ou le garde doit aller 
    {
        target = new Vector3(
                Random.Range(transform.position.x - ZonePatrol.x / 2, transform.position.x + ZonePatrol.x / 2),
             1,
              Random.Range(transform.position.z - ZonePatrol.z / 2, transform.position.z + ZonePatrol.z / 2));
        agentAleatoire.SetDestination(target);
        Debug.Log("on choisi la cible");
    }
    private void OnDrawGizmos()
    {/* permet de materialiser la zone ou on peux faire apparetre les éléments 
      */
        Gizmos.color = Color.blue; // la zone sera rouge 
        Gizmos.DrawWireCube(transform.position, ZonePatrol); // c'est ce qui ma materialiser la zone a la position de cette obejct et a la taille choisie 
    }
    IEnumerator SpawnTarget()
    {
        yield return new WaitForSeconds(NouveauTatget);
        UpdateDestination();
        Debug.Log("nouveau point");
    }


}
