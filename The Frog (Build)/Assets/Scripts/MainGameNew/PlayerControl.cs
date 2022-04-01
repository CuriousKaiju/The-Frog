using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("JUMP PARAMS")]

    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private bool _playerCanJump;
    [SerializeField] private float _desiredTimeForJump;
    private float _elapsedTime;

    [Header("PLAYER DETAILS")]

    [SerializeField] private GameObject _collisionDetector;
    private CollisionCheck _collisionDetectorScript;

    [Header("OTHER DETAILS")]

    [SerializeField] private GameObject _currentPlatform;
    private Transform _currentPlatformTransform;

    [SerializeField] private GameObject _targetPlatform;
    private Transform _targetPlatformPlayerSlotTransform;


    void Start()
    {
        _collisionDetectorScript = _collisionDetector.GetComponent<CollisionCheck>();
    }
    void Update()
    {
        if(_playerCanJump && Input.touchCount > 0)
        {
            Tap();
        }
        else if(!_playerCanJump)
        {
            PlayerMovementToPlatform();
        }
    }
    public void PlayerGrounded()
    {
        _playerCanJump = true;
        _elapsedTime = 0;
    }
    public void PlayerOutGround()
    {
        _playerCanJump = false;
        _currentPlatform.GetComponent<PlatformLogic>().PlayerOutPlatform(gameObject);

    }
    private void PlayerMovementToPlatform()
    {
        _elapsedTime += Time.deltaTime;
        float perocentageComplete = _elapsedTime / _desiredTimeForJump;
        transform.position = Vector3.Lerp(_currentPlatformTransform.position, _targetPlatformPlayerSlotTransform.position, _curve.Evaluate(perocentageComplete));
        if(perocentageComplete >= 1)
        {
            _elapsedTime = 0;
        }
    }
    private void Tap()
    {
        SetTargetPlatform();
        if(_targetPlatform)
        {
            PlayerOutGround();
        }
        else
        {

        }
    }

    public void SetCurrentPlatform(GameObject currentPlatform)
    {
        _currentPlatform = currentPlatform;
        _currentPlatformTransform = _currentPlatform.GetComponent<Transform>();
    }
    private void SetTargetPlatform()
    {
        
        _targetPlatformPlayerSlotTransform = _targetPlatform.transform;
    }
}
