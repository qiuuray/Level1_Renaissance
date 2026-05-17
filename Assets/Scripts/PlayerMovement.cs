using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        anim.SetBool("IsWalking", true);

        if (context.canceled)
        {
            anim.SetBool("IsWalking", false);
            
            anim.SetFloat("LastInputX", moveInput.x);
            anim.SetFloat("LastInputY", moveInput.y);
        }
        
        moveInput = context.ReadValue<Vector2>();

        anim.SetFloat("InputX", moveInput.x);
        anim.SetFloat("InputY", moveInput.y);
    }
    
  
    
}
