using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    [SerializeField] GameObject _camera;
    private Transform _tr;
    private void Start()
    {
        _tr = transform;
    }
    void Update()
    {
        _tr.SetPositionAndRotation(_tr.position, new Quaternion(_tr.rotation.x,_camera.transform.rotation.y,_tr.rotation.z,_tr.rotation.w));
    }
}
