using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [Header("MOVEMENT PARAMS")]

    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] private float _desiredDuration;
    private float _elapsedTime;

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        float perocentageComplete = _elapsedTime / _desiredDuration;
        transform.position = Vector3.Lerp(_startPos.position, _endPos.position, _curve.Evaluate(perocentageComplete));
    }
}
