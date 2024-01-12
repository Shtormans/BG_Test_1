using UnityEngine;

public static class HashNameAnimator
{
    public static readonly int IdleState = Animator.StringToHash("Idle");
    public static readonly int RunState = Animator.StringToHash("Run");
    public static readonly int JumpState = Animator.StringToHash("Jump");
    public static readonly int SlideState = Animator.StringToHash("Slide");
    public static readonly int DieState = Animator.StringToHash("Die");
}
