using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPoints : MonoBehaviour
{
    [SerializeField] private Transform _pointer;
    [SerializeField] private float _reyLength;
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * _reyLength, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            _pointer.position = hit.point;
        }
    }
}
