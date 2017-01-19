using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public float _speedStart;
    public float _speed;
    public float _speedIncrease;
    public float _speedMax;
    public GameObject[] _floors;
    public GameObject _enemy;
    public float _startPosition;
    public float _endPosition;

    // Use this for initialization
    void Start () {
        _speed = _speedStart;

        for (int i = 0; i < 10; i++) {
            if (i < 4) {
                Instantiate(_floors[0], new Vector3(0, 0, i * 5.0f), Quaternion.identity);
            }
            else {
                Instantiate(_floors[Random.Range(1, 5)], new Vector3(0, 0, i * 5.0f), Quaternion.identity);
            }          
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateFloor()
    {
        float _random = Random.Range(0, 10);
        Instantiate(_floors[Random.Range(1, 5)], new Vector3(0, 0, _startPosition), Quaternion.identity);
        if (_random == 5) {
            Instantiate(_enemy, new Vector3(0, 0, _startPosition), Quaternion.identity);
        }
        if (_speed < _speedMax) {
            _speed += _speedIncrease;
        }
    }
}
