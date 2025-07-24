using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 20.0f;
    private float verticalInput;
    private float horizontalInput;

    public Animator animator;
    public SpriteRenderer playerRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Input Handler
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Movement Handler
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Animation Handler
        if (horizontalInput != 0 && verticalInput == 0)
        {
            animator.SetBool("Idle_Left", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Idle_Back", false);

            if (horizontalInput > 0)
            {
                playerRenderer.flipX = true;
            }
            else
            {
                playerRenderer.flipX = false;
            }
        }
        else if (verticalInput > 0 && horizontalInput == 0)
        {
            animator.SetBool("Idle_Left", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Idle_Back", true);

        }
        else
        {
            animator.SetBool("Idle_Left", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Idle_Back", false);
        }
    }
}
