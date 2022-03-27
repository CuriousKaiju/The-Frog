using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _distanceBetweenPlayerAndCamara;
    [SerializeField] private float _desiredCameraMovementTime;
    [SerializeField] private AnimationCurve _curve;

    private float _perocentageComplete;
    private float _elapsedTime;
    private Transform _playerCurrentPosition;
    private CharacterController _characterControllerScript;


    private void Start()
    {
        _characterControllerScript = _player.GetComponent<CharacterController>();
        _playerCurrentPosition = _player.GetComponent<Transform>();
    }

    void Update()
    {
        if(!_characterControllerScript._playerCanJump)
        {
            CameraPositionChanger();
        }
    }
    private void CameraPositionChanger()
    {
        _elapsedTime += Time.deltaTime;
        _perocentageComplete = _elapsedTime / _desiredCameraMovementTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, Vector3.Lerp(transform.position, _playerCurrentPosition.position, _curve.Evaluate(_perocentageComplete)).z);
        if (_perocentageComplete >= 1)
        {
            _elapsedTime = 0;
            _perocentageComplete  = 0;
        }
    }
}
