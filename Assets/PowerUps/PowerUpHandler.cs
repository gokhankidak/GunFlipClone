using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> _objects;
    [SerializeField] Camera _camera;
    [SerializeField] int[] _dimensionmSize = new int[2] { 4, 5 };
    [SerializeField] int _objectPoolSize = 5;
    [SerializeField] int _frequencyPercent = 2;

    float _verticalObjectDeployLimit = 10f;
    float _deploymentHeight = 0;
    Vector3 _screenBounds;


    void Start()
    {
        int _length = _objects.Count;
        InstantiatePoolObject(_length);

        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _verticalObjectDeployLimit = _screenBounds.y;

        DeployObjects();
        _deploymentHeight += _verticalObjectDeployLimit;
    }


    void Update()
    {
        if (_camera.transform.position.y > _deploymentHeight)
        {
            DeployObjects();
            _deploymentHeight += _verticalObjectDeployLimit;

            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].transform.position.y < (_camera.transform.position.y - _verticalObjectDeployLimit))
                    _objects[i].SetActive(false);
            }
        }
    }

    private void InstantiatePoolObject(int _length)
    {
        for (int i = 0; i < _length; i++)
        {
            for (int j = 0; j < _objectPoolSize; j++)
            {
                _objects.Add(Instantiate(_objects[i], new Vector3(-10, 0, 0), Quaternion.identity));
                _objects[i + j].SetActive(false);
            }
        }
    }
    void DeployObjects()
    {
        int _random;
        for (int i = 1; i < _dimensionmSize[0] + 1; i++)
        {
            for (int j = 1; j < _dimensionmSize[1] + 1; j++)
            {
                _random = Random.Range(0, 100);
                if (_random % (100 / _frequencyPercent) == 0 && !_objects[_random % _objects.Count].activeSelf)
                {
                    _objects[_random % _objects.Count].SetActive(true);
                    _objects[_random % _objects.Count].transform.position =
                        new Vector2(_screenBounds.x * 2 * (i - .5f) / _dimensionmSize[0] - _screenBounds.x,
                        _camera.transform.position.y + _verticalObjectDeployLimit + (_verticalObjectDeployLimit / (_dimensionmSize[1])) * (j - 1));
                }
            }
        }
    }
}
