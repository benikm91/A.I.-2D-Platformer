using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour {

    [SerializeField] private PlayerController _playerController;
    private readonly IList<DuplicatePlayerInteract> _duplicatePlayerInteracts = new List<DuplicatePlayerInteract>();

    public void ReachedGoal(ChallengeGoal goal) 
    {
        _playerController.ReachedGoal(this);
    }

    public void Register(DuplicatePlayerInteract duplicatePlayer) 
    {
        _duplicatePlayerInteracts.Add(duplicatePlayer);
    }

    public void PlayBack(GameObject player, DuplicatePlayerInteract triggerer) 
    {
        foreach (var child in _duplicatePlayerInteracts) 
        {
            if (child == triggerer) continue;
            StartCoroutine(child.PlayBack(player));
        }
    }

}
