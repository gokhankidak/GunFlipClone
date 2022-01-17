using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            GameObject.Find("GunManager").GetComponent<GunController>().RefreshAmmo();
            gameObject.SetActive(false);
        }
    }
}
