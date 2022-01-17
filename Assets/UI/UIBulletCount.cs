using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIBulletCount : MonoBehaviour
{
    [SerializeField] TMP_Text _bulletCountText;
    [SerializeField] GunController _gun;

    void Start()
    {
        _bulletCountText.text = _gun.ammoCount + " X";
    }

    public void RefreshText()
    {
        _bulletCountText.text = _gun.ammoCount+" X";
    }

}
