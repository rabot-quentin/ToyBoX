using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{/* Dans ce srcpite nous voyons comment faire apparetre un object aléatoir dans une zone donner 
  */
   
   public  GameObject objet; // l'élement qu'on fait apparetre aleatoirement

    [SerializeField]
    private Vector3 zoneSize; // represente la zone dans la qu'elle on fait apparetre l'élément 

    [SerializeField]
    private float dureElement; // la duret que l'element reste sur dans la scnene 


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))// ations que ce realise a chaque foit qu'on va utiliser la touche P 
        {
            GameObject instantiated = Instantiate(objet); // on fait apparetre l'élément 

            instantiated.transform.position = new Vector3(    // on modif la position d'intentiated pour definir l'endoit ou l'object va apparetre
                Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),  // on genaire un valeur aléatoir pour le x du l'object compris entre sa valeur actuel - le x du la zone 
                 1,
                  Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z / 2)
                );
            StartCoroutine(SuprimerElement());
        }

    }

    private void OnDrawGizmos()
    {/* permet de materialiser la zone ou on peux faire apparetre les éléments 
      */
        Gizmos.color = Color.red; // la zone sera rouge 
        Gizmos.DrawWireCube(transform.position, zoneSize); // c'est ce qui ma materialiser la zone a la position de cette obejct et a la taille choisie 
    }
    IEnumerator SuprimerElement()
    {
        yield return new WaitForSeconds(dureElement);
        Debug.Log(objet + " est detruie");
        DestroyImmediate(objet, true); 
    }
}
