using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputController), typeof(Animator))]
[RequireComponent(typeof(InteractableWatcher))]
public class PlayerController : MonoBehaviour
{

    private Vector2? _oldGravity = null;
    private ChallengeController _currentChallenge;
    private InteractableWatcher _interactableWatcher;
    private Rigidbody2D _rb2d;
    private PlayerInputController _playerInputController;
    private Animator _animator;
    private PlayerState? _playerState = null;
    private bool ChallengeCompleted { get { return _currentChallenge != null && _playerState == null; } }

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerInputController = GetComponent<PlayerInputController>();
        _animator = GetComponent<Animator>();
        _interactableWatcher = GetComponent<InteractableWatcher>();
    }

    public bool IsSteeringClone { get { return !_playerInputController.enabled; } }

    public void StartCloneControl(ChallengeController challenge) 
    {
        UnityEngine.Assertions.Assert.IsNull(_currentChallenge);
        UnityEngine.Assertions.Assert.IsFalse(_playerState.HasValue);
        UnityEngine.Assertions.Assert.IsFalse(_oldGravity.HasValue);
        _currentChallenge = challenge;
        _playerState = new PlayerState(transform, _animator);
        _interactableWatcher.enabled = false;
        _oldGravity = Physics2D.gravity;

    }

    public void ReachedGoal(ChallengeController challenge) 
    { }

    public void StopCloneControl() 
    {
        UnityEngine.Assertions.Assert.IsNotNull(_currentChallenge);
        UnityEngine.Assertions.Assert.IsTrue(_playerState.HasValue);
        UnityEngine.Assertions.Assert.IsTrue(_oldGravity.HasValue);
        if (!_currentChallenge.Completed) 
        {
            _playerState.Value.Apply(gameObject, _animator);
            Physics2D.gravity = _oldGravity.Value;
        }
        _interactableWatcher.enabled = true;
        _currentChallenge = null;
        _playerState = null;
        _oldGravity = null;
    }

}
