using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{

    public Transform _targetPlatformOfCollision;
    public Transform _currentPlatform;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            _targetPlatformOfCollision = other.gameObject.transform.GetChild(0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            _targetPlatformOfCollision = null;
        }
    }
    public void ColliderEnabler()
    {
        _targetPlatformOfCollision = null;
    }
}
