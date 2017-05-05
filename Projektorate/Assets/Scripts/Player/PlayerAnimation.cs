using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public Animator Animator;
    public bool Moving;
    public AnimationState MoveDirection;

    private AnimationState _currentState;
    private AnimationStance _currentStance;

    /// <summary>
    /// Current animation state, within current stance
    /// </summary>
    public enum AnimationState
    {
        Idle = 0,
        Run = 1,
        RunForward = 2,
        RunForwardRight = 3,
        RunRight = 4,
        RunBackRight = 5,
        RunBack = 6,
        RunBackLeft = 7,
        RunLeft = 8,
        RunForwardLeft = 9,
        Cast = 10,
        Praise = 30
    }

    /// <summary>
    /// Top level of the animation hierarchy. Which of the 3 Animation statemachines are we gonna use
    /// </summary>
    public enum AnimationStance
    {
        Idle = 0,
        Aiming = 1,
        Casting = 2
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// Check which animation in Aiming substatemachine we should use
    /// </summary>
    private void CheckAimAnimation()
    {        
            if (!Moving)
                SetAnimation(AnimationState.Idle);
            else if (Moving && MoveDirection == AnimationState.RunForward)
                SetAnimation(AnimationState.RunForward);
            else if (Moving && MoveDirection == AnimationState.RunForwardRight)
                SetAnimation(AnimationState.RunForwardRight);
            else if (Moving && MoveDirection == AnimationState.RunRight)
                SetAnimation(AnimationState.RunRight);
            else if (Moving && MoveDirection == AnimationState.RunBackRight)
                SetAnimation(AnimationState.RunBackRight);
            else if (Moving && MoveDirection == AnimationState.RunBack)
                SetAnimation(AnimationState.RunBack);
            else if (Moving && MoveDirection == AnimationState.RunBackLeft)
                SetAnimation(AnimationState.RunBackLeft);
            else if (Moving && MoveDirection == AnimationState.RunLeft)
                SetAnimation(AnimationState.RunLeft);
            else if (Moving && MoveDirection == AnimationState.RunForwardLeft)
                SetAnimation(AnimationState.RunForwardLeft);
    }

    
    /// <summary>
    /// Changes the animation state if it's not already same
    /// </summary>
    /// <param name="animation"></param>
    public void SetAnimation(AnimationState animation)
    {
        if(animation != _currentState)
        {
            _currentState = animation;
            Animator.SetInteger("animState", (int)animation);
        }        
    }

    public void OnEnable()
    {
        Animator.enabled = true;
    }

    public void OnDisable()
    {
        Animator.enabled = false;
    }
}
