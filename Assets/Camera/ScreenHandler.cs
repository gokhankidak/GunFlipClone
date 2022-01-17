using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHandler : MonoBehaviour
{
    [SerializeField] GunController _gunController;
    GameObject _gun;
    GameObject _leftGun;
    GameObject _rightGun;

    Vector3 _screenBounds;
    float _gunWidth;
    bool _isLeftCreated = false;
    bool _isRightCreated = false;

    // Start is called before the first frame update
    void Start()
    {
        _gun = _gunController.gun;
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _gunWidth = _gun.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Transform playerPos = _gun.transform;

        FollowMirrorObject();
        CreateMirrorObject(playerPos);
        DestroyAndReplaceOutsideObject(playerPos);
    }

    private void FollowMirrorObject()
    {
        if (_isRightCreated)
        {
            _rightGun.transform.position = _gun.transform.position + new Vector3(_screenBounds.x * 2, 0, 0);
            _rightGun.transform.rotation = _gun.transform.rotation;
        }
        else if (_isLeftCreated)
        {
            _leftGun.transform.position = _gun.transform.position + new Vector3(-_screenBounds.x * 2, 0, 0);
            _leftGun.transform.rotation = _gun.transform.rotation;
        }
    }

    private void DestroyAndReplaceOutsideObject(Transform playerPos)
    {
        if (playerPos.position.x < (_screenBounds.x + _gunWidth) * -1)
        {
            _rightGun.GetComponent<Rigidbody2D>().velocity = _gun.GetComponent<Rigidbody2D>().velocity;
            _gun.transform.position = _rightGun.transform.position;
            Destroy(_rightGun);
            _isRightCreated = false;
        }

        else if (playerPos.position.x > (_screenBounds.x + _gunWidth))
        {
            _leftGun.GetComponent<Rigidbody2D>().velocity = _gun.GetComponent<Rigidbody2D>().velocity;
            _gun.transform.position = _leftGun.transform.position;
            Destroy(_leftGun);
            _isLeftCreated = false;
        }
    }

    private void CreateMirrorObject(Transform playerPos)
    {
        if (playerPos.position.x < (-_screenBounds.x + _gunWidth) && !_isRightCreated)
        {
            _isRightCreated = true;
            _rightGun = Instantiate(_gun.gameObject, _gun.transform.position + new Vector3(_screenBounds.x * 2, 0, 0), Quaternion.identity);
            Destroy(_leftGun);
            _isLeftCreated = false;
        }

        else if (playerPos.position.x > (_screenBounds.x - _gunWidth) && !_isLeftCreated)
        {
            _isLeftCreated = true;
            _leftGun = Instantiate(_gun.gameObject, _gun.transform.position + new Vector3(-_screenBounds.x * 2, 0, 0), Quaternion.identity);
            Destroy(_rightGun);
            _isRightCreated = false;
        }
    }
}
