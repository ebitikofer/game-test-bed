using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;
    public Rigidbody rb;
    public float score;
    public int intScore;
    public Text scoreText;
	
	// Update is called once per frame
	void Update() {

        //check if object is rotating
        if (rb.angularVelocity.magnitude >= 0)
        {
            score += rb.angularVelocity.magnitude;
            intScore = ((int)score); // / 100 ) ^ ( (int)score / 100 );
            scoreText.text = intScore.ToString();
        
        }

    // scoreText.text = player.position.z.ToString("0");

	}
}
