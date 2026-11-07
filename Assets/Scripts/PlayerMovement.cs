using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float movementSpeed = 10f;
   [SerializeField] private float jumpHight = 5f;

   private Vector2 moveInput;
   private InputSystem_Actions inputActions;

   void Start()
   {
      
   }

   void OnMove(InputValue value)
   {  
      moveInput = value.Get<Vector2>();
      print(moveInput.ToString());
   }

   

   void Update()
   {
      

      /* float moveValue = movementSpeed * Time.deltaTime;
      float jumpValue = jumpHight * Time.deltaTime;

      if (moveVector.x < 0)
      {
         gameObject.transform.Translate(-moveValue, 0, 0);
      }
      else if (moveVector.x > 0)
      {
         gameObject.transform.Translate(moveValue, 0, 0);
      }

      if (jumpAction.IsPressed())
      {
         gameObject.transform.Translate(0, jumpValue, 0);
      } */
   }
}
