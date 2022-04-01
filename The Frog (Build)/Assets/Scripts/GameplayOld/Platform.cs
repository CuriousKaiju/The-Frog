using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("PLATFORM PARAMS")]

    [SerializeField] private Vector3 _rotationDirection;
    [SerializeField] private float _rotationSpeed;

    public Transform _pointForPlayer;
    public bool _playerOnPlatform;

    private bool _switch = true;
    private MeshCollider _platformCollider;

    void Start()
    {
        _platformCollider = GetComponent<MeshCollider>();
    }

    void Update()
    {
        if(_playerOnPlatform)
        {
            PlatfromRotation();
        }
    }
    private void PlatfromRotation()
    {
        transform.Rotate(_rotationDirection * _rotationSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!_playerOnPlatform)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(!_playerOnPlatform)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
    public void CollorChanger()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
    public void RotationDirectionSwitcher(Vector3 rotationDir)
    {
        _rotationDirection = rotationDir;
    }

}

