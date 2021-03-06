using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;

    public Vector3 jump;
    public float forwardForce = 2000f;  // Variable that determines the forward force
    public float backwardForce = 100f;  // Variable that determines the forward force
    public float sidewaysForce = 500f;  // Variable that determines the sideways force
    public float upwardForce = 1;  // Variable that determines the sideways force
    public float ystop = -8f;

    public bool isGrounded;

    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // We marked this as "Fixed"Update because we
    // are using it to mess with physics.
    void FixedUpdate ()
	{
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Touch myTouch = Input.GetTouch(0);

        // Touch[] myTouches = Input.touches;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))	// If the player is pressing the "d" key
		{
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  // If the player is pressing the "a" key
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))  // If the player is pressing the "a" key
        {
            // Add a force to the left
            rb.AddForce(0, 0, -backwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)  // If the player is pressing the "space" key
        {
            // Add a force to the left
            rb.AddForce(0, upwardForce, 0, ForceMode.Impulse);
            isGrounded = false;
        }

        if (rb.position.y < ystop)
		{
			FindObjectOfType<GameManager>().EndGame();
		}

        if (Input.touchCount == 1)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    // Add a force to the left
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    // Add a force to the right
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
            }
        } else if(Input.touchCount == 2 && isGrounded)
        {
            rb.AddForce(0, upwardForce, 0, ForceMode.Impulse);
            isGrounded = false;
        }


    }
}
