using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float movementSpeed = 10f;
   [SerializeField] private float jumpHight = 5f;

   private Vector2 moveInput;
   private InputSystem_Actions inputActions;
   private Rigidbody2D myRigidBody2D;

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
      myRigidBody2D = GetComponent<Rigidbody2D>();
   }

   void Update()
   {
      moveInput = inputActions.Player.Move.ReadValue<Vector2>();
   }

   void FixedUpdate()
   {
      PlayerMove();
   }

   void PlayerMove()
   {
      Vector2 velocity = myRigidBody2D.linearVelocity;
      velocity.x = moveInput.x * movementSpeed;
      myRigidBody2D.linearVelocity = velocity;
   }
}
