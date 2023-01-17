using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacmentAleatoir : MonoBehaviour
{
    public GameObject point;



    [SerializeField]
    private Vector3 zoneSize2; // represente la zone dans la qu'elle on fait apparetre l'élément 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            point.transform.position = new Vector3(
                Random.Range(transform.position.x - zoneSize2.x / 2, transform.position.x + zoneSize2.x / 2), 
             1,
              Random.Range(transform.position.z - zoneSize2.z / 2, transform.position.z + zoneSize2.z / 2));
        }
    }
    private void OnDrawGizmos()
    {/* permet de materialiser la zone ou on peux faire apparetre les éléments 
      */
        Gizmos.color = Color.blue; // la zone sera rouge 
        Gizmos.DrawWireCube(transform.position, zoneSize2); // c'est ce qui ma materialiser la zone a la position de cette obejct et a la taille choisie 
    }
   
}
