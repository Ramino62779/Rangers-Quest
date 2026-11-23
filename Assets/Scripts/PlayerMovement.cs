using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float movementSpeed = 10f;
   [SerializeField] private float jumpHight = 5f;

   private Vector2 moveInput;
   private InputSystem_Actions inputActions;

   private void Awake()
   {
      inputActions = new InputSystem_Actions();
   }

   private void OnEnable()
   {
      inputActions.Player.Enable();
   }

   private void OnDisable()
   {
      inputActions.Player.Disable();
   }

   void Start()
   {

   }

   void Update()
   {
      moveInput = inputActions.Player.Move.ReadValue<Vector2>();
      print("moveInput: " + moveInput);
      float moveValue = movementSpeed * Time.deltaTime;
      float jumpValue = jumpHight * Time.deltaTime;

      /* 
      

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
