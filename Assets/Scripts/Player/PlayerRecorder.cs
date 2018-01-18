using System.Collections.Generic;
using UnityEngine;

public struct PlayerState
{
    public struct AnimatorParams
    {
        public readonly bool _grounded;
        public readonly float _velocityX;
        public readonly bool _jetpackUse;

        public AnimatorParams(bool grounded, float velocityX, bool jetpackUse)
        {
            _grounded = grounded;
            _velocityX = velocityX;
            _jetpackUse = jetpackUse;
        }
    }

    public readonly Vector3 _position;
    public readonly Vector3 _localScale;
    public readonly AnimatorParams _animatorParams;

    public PlayerState(Transform t, Animator a) : this(t.position, t.localScale, new AnimatorParams(a.GetBool("grounded"), a.GetFloat("velocityX"), a.GetBool("jetpackUse")))
    { }

    public PlayerState(Vector3 position, Vector3 localScale, AnimatorParams animatorParams)
    {
        _position = position;
        _localScale = localScale;
        _animatorParams = animatorParams;
    }

    public void Apply(GameObject to, Animator animator) 
    {
        to.transform.position = _position;
        to.transform.localScale = _localScale;
        animator.SetBool("grounded", _animatorParams._grounded);
        animator.SetFloat("velocityX", _animatorParams._velocityX);
        animator.SetBool("jetpackUse", _animatorParams._jetpackUse);
    }
}

[RequireComponent(typeof(Animator))]
public class PlayerRecorder : MonoBehaviour
{
    
    private Animator _animator;

    private event System.Action OnFixedUpdate;

    public Queue<PlayerState> PlayBack = null;
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
        if (PlayBack != null && PlayBack.Count > 0) 
        {
            var recording = PlayBack.Dequeue();
            recording.Apply(gameObject, _animator);
        }
        if (OnFixedUpdate != null) OnFixedUpdate.Invoke();
    }
}
