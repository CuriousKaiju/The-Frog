using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [Header("RAYCAST PARAMS")]

    [SerializeField] private float _rayLangth;

    public GameObject _targetPlatform;

    private GameObject _selectablePlatform;
    private RaycastHit _hit;

    void Update()
    {
        DrawRay();
    }
    private void DrawRay()
    {
        
        Debug.DrawRay(transform.position, transform.up * _rayLangth, Color.red);

        if(Physics.Raycast(transform.position, transform.up, out _hit, _rayLangth))
        {
            if (_hit.collider.gameObject.CompareTag("Platform")) //Если луч попал в платформу и платформа находится достаточно близко
            {
                _selectablePlatform = _hit.collider.gameObject; //Поместили пересеченную платформу сюда

                if (_targetPlatform && _targetPlatform != _selectablePlatform) // Если таргет платформа есть и при этом она не равна текущему выбранному объекту
                {
                    _targetPlatform.GetComponent<PlatformLogic>().Deselect(); // текущую платформу развыделяем
                    _targetPlatform = _selectablePlatform; //Присвоили полю таргет, текущую платформу
                    _targetPlatform.GetComponent<PlatformLogic>().Select();
                }
                else
                {
                    _targetPlatform = _selectablePlatform; //Присвоили полю таргет, текущую платформу
                    _targetPlatform.GetComponent<PlatformLogic>().Select();
                }
            }
        }
        else
        {
            if(_targetPlatform)
            {
                _targetPlatform.GetComponent<PlatformLogic>().Deselect();
                _targetPlatform = null;
                _selectablePlatform = null;
            }
        }
    }
}
