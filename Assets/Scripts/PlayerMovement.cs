using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;

	public float forwardForce = 2000f;	// Variable that determines the forward force
	public float sidewaysForce = 500f;  // Variable that determines the sideways force
    public float upwardForce = 1;  // Variable that determines the sideways force
    public float ystop = -8f;

    // We marked this as "Fixed"Update because we
    // are using it to mess with physics.
    void FixedUpdate ()
	{
		// Add a forward force
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d"))	// If the player is pressing the "d" key
		{
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a"))  // If the player is pressing the "a" key
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

        if (Input.GetKey("space"))  // If the player is pressing the "a" key
        {
            // Add a force to the left
            rb.AddForce(0, upwardForce, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < ystop)
		{
			FindObjectOfType<GameManager>().EndGame();
		}

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


    }
}
