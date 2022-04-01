using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialJump : MonoBehaviour
{
    [Header("INITAL JUMP PARAMS")]

    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private GameObject _startPlatform;
    [SerializeField] private Transform _initPoint;

    [SerializeField] private float _desiredTimeForInitialJump;

    private float _elapsedTime;

    private Transform _startPosition;

    void Start()
    {
        _startPosition = _startPlatform.GetComponent<PlatformLogic>().GetTransformOfTargetPlayerSlot(_startPosition);
    }
    void Update()
    {
        InitiatePosition();
    }
    private void InitiatePosition()
    {
        _elapsedTime += Time.deltaTime;
        float percentageComplete = _elapsedTime / _desiredTimeForInitialJump;
        transform.position = Vector3.Lerp(_initPoint.position, _startPosition.position, _curve.Evaluate(percentageComplete));
        if(percentageComplete >= 1)
        {
            _startPlatform.GetComponent<PlatformLogic>().PlayerOnPlatform(gameObject);
            GetComponent<InitialJump>().enabled = false;
            GetComponent<PlayerControl>().enabled = true;
        }
    }
}
