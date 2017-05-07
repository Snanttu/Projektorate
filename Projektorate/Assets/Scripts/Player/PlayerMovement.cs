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

	private void Update()
	{
		_rigidbody = GetComponent<Rigidbody>();
		Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));                
			
	}

    /// <summary>
    /// takes keyboard Input and increases horizontal & vertical velocity of player times Speed. Called from InputController
    /// </summary>
    public void Move(float inputX, float inputZ)
    {      
        if (inputX != 0 || inputZ != 0)
        {                        
            _moveDirection = Vector3.zero;
            Vector3 previousLocation = transform.position;
            _moveDirection.x = inputX / 2;
            _moveDirection.z = inputZ / 2;            

            _rigidbody.velocity = _moveDirection.normalized * _moveSpeed;
			float step = _turnSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, _moveDirection, step, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);
            
        }
        else
        {            
            _rigidbody.velocity = Vector3.zero;
        }
    }

    
}
