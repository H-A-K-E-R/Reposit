using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grenade : MonoBehaviour
{

    [SerializeField] private GameObject _grenade;
    private Transform _grenadeSpawner;
    [SerializeField] private float _force;
    private Rigidbody _rigidbody;
 


    private void Start()
    {
        this._rigidbody = GetComponent<Rigidbody>();
        _grenadeSpawner = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        grenadeThrow();
    }
    private void grenadeThrow()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _rigidbody = ((GameObject)Instantiate(_grenade, _grenadeSpawner.position, _grenadeSpawner.rotation)).GetComponent<Rigidbody>();
            _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
        }
    }
}
