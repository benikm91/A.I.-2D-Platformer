using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    private ChallengeController _currentChallenge;
    private Rigidbody2D _rb2d;
    private PlayerInputController _playerInputController;
    private Animator _animator;
    private PlayerState? _playerState = null;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerInputController = GetComponent<PlayerInputController>();
        _animator = GetComponent<Animator>();
    }

    public bool IsSteeringClone { get { return !_playerInputController.enabled; } }

    public void StartCloneControl(ChallengeController challenge) 
    {
        _currentChallenge = challenge;
        var interactableWatcher = GetComponent<InteractableWatcher>();
        interactableWatcher.enabled = false;
        _playerState = new PlayerState(transform, _animator);
    }

    public void ReachedGoal(ChallengeController challenge) 
    {
        if (challenge == _currentChallenge) _playerState = null;
    }

    public void StopCloneControl() 
    {
        _currentChallenge = null;
        var interactableWatcher = GetComponent<InteractableWatcher>();
        interactableWatcher.enabled = true;
        if (_playerState.HasValue) _playerState.Value.Apply(gameObject, _animator);
    }

}
