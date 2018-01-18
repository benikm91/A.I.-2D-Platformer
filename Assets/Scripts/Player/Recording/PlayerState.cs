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
