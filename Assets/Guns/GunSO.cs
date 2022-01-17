using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MyGunStats", menuName = "ScriptableObjects/GunStats")]

public class GunSO : ScriptableObject
{   
    [SerializeField] private GameObject _gun;
    [Range(2, 30)] [SerializeField] private int _ammoCount;
    [SerializeField] private float _recoilPower;
    [Range(1, 10)] [SerializeField] private float _fireRate;
    [SerializeField] private float _rotationtorque;

    public GameObject gun { get => _gun; }
    public int ammoCount { get => _ammoCount; }
    public float recoilPower { get => _recoilPower; }
    public float fireRate { get => _fireRate;}
    public float rotationtorque { get => _rotationtorque;}
}
