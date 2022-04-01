using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    [Header("PARTS OF PLATFORM")]

    [SerializeField] private GameObject _slotForPlayer;
    [SerializeField] private GameObject _visualPlatform;
    [SerializeField] private GameObject _platformCollision;

    [Header("PLATFORM VARIABLES")]

    [SerializeField] private Vector3 _rotationDirection;
    [SerializeField] private bool _playerOnThePlatform = false;
    [SerializeField] private float _rotationSpeed;


    void Start()
    {
        

    }
    void Update()
    {
        if(_playerOnThePlatform)
        {
            PlatformRotation();
        }
    }
    public void Select()
    {
        _visualPlatform.GetComponent<Renderer>().material.color = Color.red;
    }
    public void Deselect()
    {
        _visualPlatform.GetComponent<Renderer>().material.color = Color.white;
    }
    public void PlayerOnPlatform(GameObject player)
    {
        _playerOnThePlatform = true;
        player.transform.parent = _slotForPlayer.transform;
        gameObject.GetComponent<Collider>().enabled = false;
        player.GetComponent<PlayerControl>().PlayerGrounded();
        player.GetComponent<PlayerControl>().SetCurrentPlatform(gameObject);
        Debug.Log(1);
    }
    public void PlayerOutPlatform(GameObject player)
    {
        _playerOnThePlatform = false;
        player.transform.parent = null;
        gameObject.GetComponent<Collider>().enabled = true;
        player.GetComponent<PlayerControl>().PlayerOutGround();
    }

    public Transform GetTransformOfTargetPlayerSlot(Transform slotVariable)
    {
        slotVariable = _slotForPlayer.transform;
        return slotVariable;
    }
    private void PlatformRotation()
    {
        transform.Rotate(_rotationDirection * _rotationSpeed);
    }
}
