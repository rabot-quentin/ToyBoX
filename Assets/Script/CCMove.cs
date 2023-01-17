using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMove : MonoBehaviour
{/* Ce scrpit permet un deplacement a la 3 eme personne avec le charactrer controlleur la camera n'est pas controlabe
  */

    public float speed ; // la vitesse de deplacement
    public int speedRotation; // la vitesse avec le joueur va tourner 
    public float jumpSpeed; // la force de saut 
    public float gravity; // le parametre qui va permet au joueur de rester d'avoir un graviter qui s'applique sur lui 
    private Vector3 moveDirection = Vector3.zero;
    CharacterController Cc;
   
    void Start()
    {
        Cc = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        if (Cc.isGrounded) // si le joueur est en contact avec le sol 
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical")); // permet au joueur d'avancer sur l'axe x 
            moveDirection = transform.TransformDirection(moveDirection * speed); // le parametre qui applique le deplacement du joueur 
           

            if (Input.GetButtonDown("Jump")) // si le joueur veux sauter 
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime; // application de la graviter sur le joueur 

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * speedRotation);//* se qui permet au joueur de tourner avec les toutche Q et D            
        Cc.Move(moveDirection * Time.deltaTime); 


    }
}
