using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Contr : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    RaycastHit _hit;
    private string _isGrounded = "Ground";
    private bool _right;
    private Rigidbody _rigidbody;
 

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        moveControl();
        jumpControl();
    }


    private void moveControl()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        transform.Translate(movement * _speed * Time.fixedDeltaTime);
    }

    private void jumpControl()
    {
        Ray raycast1 = new Ray(transform.position, Vector3.down.normalized);
        Physics.Raycast(raycast1, out _hit, 0.5f);
        if (_isGrounded == _hit.collider.tag)
        {
            if (_hit.distance < 0.5f)
            {
                _right = true;
                if (_right == true)
                {
                    if (Input.GetKey("space"))
                    {
                        _rigidbody.AddForce(0, _jumpForce, 0, ForceMode.Impulse);
                    }

                }
            }
        }
        if (_right == true)
        {
            if (Input.GetKey("space"))
            {
                _rigidbody.AddForce(0, _jumpForce, 0, ForceMode.Impulse);
            }
        
        }
    }
}   
