using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerRecorder : MonoBehaviour
{
    
    private Animator _animator;

    private event System.Action OnFixedUpdate;

    private IList<PlayerState> _recording = new List<PlayerState>();

    public void InsertRecording() 
    {
        _recording.Add(new PlayerState(transform, _animator));
    }

    public void StartRecording() 
    {
        OnFixedUpdate += InsertRecording;
    }

    public IList<PlayerState> StopRecording() 
    {
        OnFixedUpdate -= InsertRecording;
        var result = _recording;
        _recording = new List<PlayerState>();
        return result;
    }

    void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (OnFixedUpdate != null) OnFixedUpdate.Invoke();
    }
}
