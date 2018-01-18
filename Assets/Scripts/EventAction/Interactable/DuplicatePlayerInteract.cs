using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DuplicatePlayerInteract : Interactable
{
    [SerializeField] private GameObject _playerClone;
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
            StartCoroutine(Record(go.GetComponent<PlayerRecorder>(), go.GetComponent<PlayerController>()));
    }

    public IEnumerator PlayBack() 
    {
        if (_recordings != null) 
        {
            var playerClone = Instantiate(_playerClone, transform.position, Quaternion.identity);
            playerClone.GetComponent<PlayerCloneRecordPlayer>().PlayBack = new Queue<PlayerState>(_recordings);
            yield return new WaitForSeconds(_duration);
            Destroy(playerClone);
        }
    }

    private IEnumerator Record(PlayerRecorder playerRecorder, PlayerController playerController)
    {
        _controller.PlayBackOtherDuplicatePlayerInteracts(this);
        playerRecorder.enabled = true;
        playerRecorder.StartRecording();
        playerController.StartCloneControl(_controller);
        yield return new WaitForSeconds(_duration);
        playerController.StopCloneControl();
        _recordings = playerRecorder.StopRecording();
        playerRecorder.enabled = false;
    }

}
