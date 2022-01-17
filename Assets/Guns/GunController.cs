using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunController : MonoBehaviour
{
    [SerializeField] GunSO _gunSO;
    [SerializeField] Vector3 _startingPos;
    Rigidbody2D _gunRigidbody;
    GameObject _gun;
    int _ammoCount;
    float _nextFireTime = 0;

    public UnityEvent onFire;
    public UnityEvent onTakeAmmo;

    public int ammoCount { get => _ammoCount;}
    public GameObject gun { get => _gun;}

    void Awake()
    {
        _gun = Instantiate(_gunSO.gun, _startingPos, Quaternion.Euler(new Vector3(0,0,-90)));
        RefreshAmmo();
        _gunRigidbody = _gun.GetComponent<Rigidbody2D>();

        _gunRigidbody.AddForce(_gunSO.recoilPower * Vector3.up);
    }

    public void RefreshAmmo()
    {
        _ammoCount = _gunSO.ammoCount;
        onTakeAmmo.Invoke();
    }

    public void Fire()
    {
        if (_ammoCount > 0 && CanFire())
        {
            _gunRigidbody.velocity = Vector3.zero;
            _gunRigidbody.AddForceAtPosition(_gunSO.recoilPower * -_gun.transform.right , _gun.transform.position);
            _gunRigidbody.angularVelocity = 0f;

            if (_gun.transform.eulerAngles.z > 90f && _gun.transform.eulerAngles.z < 270f)
            {
                _gunRigidbody.AddTorque(_gunSO.rotationtorque);
            }
            else
            {
                _gunRigidbody.AddTorque(-_gunSO.rotationtorque);
            }

            _ammoCount--;
            onFire.Invoke();
            _nextFireTime = Time.time + 1 / _gunSO.fireRate;
        }

        if(GameController.instance.isDead)
            GameController.instance.RestartGame();
    }

    private bool CanFire()
    {
        if (Time.time > _nextFireTime) return true;
        return false;
    }
}
