using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float walkingSpeed = 3f;
   [SerializeField] private float runningSpeed = 6f;
   [SerializeField] private float jumpHight = 5f;

   private Vector2 moveInput;
   private InputSystem_Actions inputActions;
   private Rigidbody2D myRigidBody2D;
   private Animator myAnimator;

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
      myAnimator = GetComponentInChildren<Animator>();
   }

   void Update()
   {
      moveInput = inputActions.Player.Move.ReadValue<Vector2>();

      FlipSprite();
      AnimatePlayer();
   }

   void FixedUpdate()
   {
      MovePlayer();
   }

   void MovePlayer()
   {
      Vector2 velocity = myRigidBody2D.linearVelocity;
      

      if (inputActions.Player.Walk.IsPressed())
      {
         velocity.x = moveInput.x * walkingSpeed;
      }
      else
      {
         velocity.x = moveInput.x * runningSpeed;
      }

      myRigidBody2D.linearVelocity = velocity;
   }

   //Flip scaling horizontally to face walking direction
   void FlipSprite()
   {
      if (Mathf.Abs(moveInput.x) > Mathf.Epsilon)
      {
         transform.localScale = new Vector3(Mathf.Sign(moveInput.x), 1f, 1f);
      }
   }

   void AnimatePlayer()
   {
      if (Mathf.Abs(myRigidBody2D.linearVelocity.x) > Mathf.Epsilon)
      {
         if (inputActions.Player.Walk.IsPressed())
         {
            myAnimator.SetBool("isWalking", true);
            myAnimator.SetBool("isRunning", false);
         }
         else
         {
            myAnimator.SetBool("isRunning", true);
            myAnimator.SetBool("isWalking", false);
         }
      }
      else
      {
         myAnimator.SetBool("isWalking", false);
         myAnimator.SetBool("isRunning", false);
      }
   }
}
