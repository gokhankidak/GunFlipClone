using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [SerializeField] GunController _gunController;
    [SerializeField] GameObject _bullet;
    [SerializeField] int _bulletCount = 5;
    private Queue<GameObject> bullets = new Queue<GameObject>();


    void Start()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            GameObject bullet = Instantiate(_bullet);
            bullets.Enqueue(bullet);
            bullet.SetActive(false);
        }
    }

    public void FireBullet()
    {
        GameObject bullet = bullets.Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = _gunController.gun.transform.GetChild(0).position;
        bullet.transform.eulerAngles = _gunController.gun.transform.eulerAngles - new Vector3(0,0,90);
        StartCoroutine(SetPassive(bullet));
        bullets.Enqueue(bullet);
    }

    IEnumerator SetPassive(GameObject gameObject)
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
