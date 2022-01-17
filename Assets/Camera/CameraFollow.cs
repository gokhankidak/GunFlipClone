using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GunController _gunController;
    [SerializeField] float _followOffset = -2f;
    [SerializeField] float _followingdelay;

    void FixedUpdate()
    {
        if(_gunController.gun.transform.position.y + _followOffset > transform.position.y )
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, _gunController.gun.transform.position.y + _followOffset,-10),_followingdelay*Time.deltaTime);
    }
}
