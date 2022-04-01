using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("JUMP SETTINGS")]

    [SerializeField] private Transform _losePoint;
    [SerializeField] private float _jumpDesiredTime;
    private float _elapsedTime;

    [Header("COLLISION PARAMS")]

    [SerializeField] private GameObject _сollisionDetectorObj;
    private CollisionDetector _collisionDetectorScript;
    public bool _playerCanJump = true;

    [Header("PLATFORM PARAMS")]

    [SerializeField] private GameObject _targetPlatform;
    [SerializeField] private GameObject _currentPlatform;
    private bool _switcher = false;

    void Start()
    {
        _collisionDetectorScript = _сollisionDetectorObj.GetComponent<CollisionDetector>();
    }
  
    void Update()
    {
        if(!_playerCanJump)
        {
            JumpMovement();
        }
        else if ((Input.touchCount > 0) && (_playerCanJump = true))
        {
            JumpInitiation();
        }
    }

    private void JumpInitiation()
    {
        _playerCanJump = false;
        _сollisionDetectorObj.SetActive(false);
        transform.parent = null;
        _currentPlatform.GetComponent<Platform>()._playerOnPlatform = false;

        if(_сollisionDetectorObj.GetComponent<CollisionDetector>()._targetPlatformOfCollision != null)
        {
            _targetPlatform = _сollisionDetectorObj.GetComponent<CollisionDetector>()._targetPlatformOfCollision.gameObject;
        }
        else
        {
            _losePoint.transform.parent = null;
            _targetPlatform = _losePoint.gameObject;
        }

        _currentPlatform.GetComponent<Platform>().CollorChanger();
    }

    private void JumpGrounded()
    {
        _playerCanJump = true;
        _elapsedTime = 0;
        _сollisionDetectorObj.SetActive(true);
        transform.parent = _targetPlatform.transform.parent;
        _currentPlatform = _targetPlatform.transform.parent.gameObject;
        _currentPlatform.GetComponent<Platform>().CollorChanger();
        if(_switcher)
        {
            _currentPlatform.GetComponent<Platform>().RotationDirectionSwitcher(Vector3.up);
        }
        else
        {
            _currentPlatform.GetComponent<Platform>().RotationDirectionSwitcher(Vector3.down);
        }
        _switcher = !_switcher;
        _currentPlatform.GetComponent<Platform>()._playerOnPlatform = true;
        _targetPlatform = null;
        _collisionDetectorScript.ColliderEnabler();
    }

    private void JumpMovement()
    {

        _elapsedTime += Time.deltaTime;
        float perocentageCompleate = _elapsedTime / _jumpDesiredTime;
        transform.position = Vector3.Lerp(_currentPlatform.GetComponent<Platform>()._pointForPlayer.position, _targetPlatform.transform.position, perocentageCompleate);

        if (transform.position == _losePoint.position)
        {
            Debug.Log(1);
        }
        else if (transform.position == _targetPlatform.transform.position)
        {
            JumpGrounded();
        }
    }

}
