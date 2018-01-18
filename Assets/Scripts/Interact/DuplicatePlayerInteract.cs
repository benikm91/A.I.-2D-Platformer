using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DuplicatePlayerInteract : Interactable
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _duration;
    [SerializeField] private ChallengeController _controller;
    private IList<PlayerState> _recordings;

    public void Awake()
    {
        _controller.Register(this);
    }

    public override void Interact(GameObject go)
    {
        if (go.tag == "Player")
        {
            StartCoroutine(Record(go));
        }
    }

    public IEnumerator PlayBack(GameObject player) 
    {
        if (_recordings != null) 
        {
            var newPlayer = Instantiate(player, this.transform.position, Quaternion.identity);
            var recordPosition = newPlayer.GetComponent<PlayerRecorder>();
            newPlayer.GetComponent<PlayerInputController>().enabled = false;
            newPlayer.GetComponent<PlayerAnimationController>().enabled = false;
            newPlayer.GetComponent<PlayerHorizontalMovementController>().enabled = false;
            newPlayer.GetComponent<PlayerJetpackController>().enabled = false;
            newPlayer.GetComponent<InteractableWatcher>().enabled = false;
            newPlayer.GetComponent<Rigidbody2D>().gravityScale = 0;
            newPlayer.tag = "PlayerClone";
            recordPosition.enabled = true;
            recordPosition.PlayBack = new Queue<PlayerState>(_recordings);
            yield return new WaitForSeconds(_duration);
            Destroy(newPlayer);
        }
    }

    private IEnumerator Record(GameObject player)
    {
        _controller.PlayBack(player, this);
        var recorder = player.GetComponent<PlayerRecorder>();
        recorder.enabled = true;
        recorder.StartRecording();
        var oldGravity = Physics2D.gravity;
        var playerController = player.GetComponent<PlayerController>();
        playerController.StartCloneControl(_controller);
        yield return new WaitForSeconds(_duration);
        playerController.StopCloneControl();
        _recordings = recorder.StopRecording();
        recorder.enabled = false;
        Physics2D.gravity = oldGravity;
    }

}
