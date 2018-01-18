using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class PlayerCloneRecordPlayer : MonoBehaviour
{
    public Queue<PlayerState> PlayBack = null;

    private Animator _animator;

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
    }
}
