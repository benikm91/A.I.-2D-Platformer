using UnityEngine;

public class ChallengeGoal : MonoBehaviour {

    [SerializeField] private ChallengeController _challengeController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            _challengeController.ReachedGoal(this);
        }
    }

}
