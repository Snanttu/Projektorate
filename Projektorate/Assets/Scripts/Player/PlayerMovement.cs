using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    

    private Rigidbody _rigidbody;
    private Vector3 _moveDirectionRay;
    private Vector3 _moveDirection;
    public float _moveSpeed;
	public float _turnSpeed;
    private float _horizontalDirection;
    private float _verticalDirection;
	private Animator Animator;

	private bool _running;
	private bool _attacking;

	void Awake()
	{
		
		Animator = GetComponent<Animator>();
		_running = false;
		_attacking = false;

	}

	private void Update()
	{
		_rigidbody = GetComponent<Rigidbody>();
		Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		LightAttack(Input.GetAxis("Fire1"));
		HeavyAttack(Input.GetAxis("Fire2"));
		StopMoving (Input.GetAxis("Fire3"));

		if (_attacking == true)
		{            
			Animator.SetInteger("animState", 0);
		}
		else if (_running == true && _attacking == false) {
			Animator.SetInteger("animState", 1);
		}
		else {
			Animator.SetInteger("animState", 0);
		}
			
	}

    /// <summary>
    /// takes keyboard Input and increases horizontal & vertical velocity of player times Speed. Called from InputController
    /// </summary>
    public void Move(float inputX, float inputZ)
    {      
		if ((inputX != 0 || inputZ != 0) && _attacking == false)
        {                        
            _moveDirection = Vector3.zero;
            Vector3 previousLocation = transform.position;
            _moveDirection.x = inputX / 2;
            _moveDirection.z = inputZ / 2; 

			_running = true;

            _rigidbody.velocity = _moveDirection.normalized * _moveSpeed;
			float step = _turnSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, _moveDirection, step, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);
            
        }
        else
        {            
            _rigidbody.velocity = Vector3.zero;
			_running = false;
        }
    }

	public void LightAttack(float mouse0) {

		if (mouse0 != 0) {                
			_rigidbody.velocity = Vector3.zero;
			_running = false;
			_attacking = true;
		}

	}

	public void HeavyAttack(float mouse1) {

		if (mouse1 != 0) {                
			_rigidbody.velocity = Vector3.zero;
			_running = false;
			_attacking = false;
		}

	}

	public void StopMoving(float shift) {

		if (shift != 0) {                
			_rigidbody.velocity = Vector3.zero;
			_running = false;
		}

	}

	public void AttackDone() {
		_attacking = false;
	}

    
}
