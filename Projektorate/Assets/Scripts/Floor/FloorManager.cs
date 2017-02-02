using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public float _speedStart;
    public float _speed;
    public float _speedIncrease;
    public float _speedMax;
    public GameObject[] _floors;
    public GameObject _enemy;
    public GameObject _coin;
    public float _startPosition;
    public float _endPosition;
    public float _coinFrequency;
    private float _coinSpawn;
    private Vector3 _ray;

    // Use this for initialization
    void Start () {
        _speed = _speedStart;
        _coinSpawn = _coinFrequency;

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
        _coinSpawn -= 1;
        float _random = Random.Range(0, 10);
        Instantiate(_floors[Random.Range(1, 5)], new Vector3(0, 0, _startPosition), Quaternion.identity);
        if (_random == 5) {
            Instantiate(_enemy, new Vector3(0, 0, _startPosition), Quaternion.identity);
        }
        if (_coinSpawn == 0)
        {
            CreateCoin();
        }
        if (_speed < _speedMax) {
            _speed += _speedIncrease;
        }
    }

    public void CreateCoin()
    {
        bool[] _rays = CheckHoles();
        bool good = false;

        while (good == false)
        {
            int random = Random.Range(0, 4);
            if (_rays[random] == true)
            {
                GameObject g = Instantiate(_coin, new Vector3(random - 2, -1.5f, _startPosition - 5), Quaternion.identity);
                g.transform.Rotate(0, 0, 90);
                _coinSpawn = _coinFrequency;
                good = true;
                break;
            }
        }
    }

    public bool[] CheckHoles()
    {
        bool[] _rays;
        _rays = new bool[5];

        for (int i = 0; i < 5; i++)
        {
            if (Physics.Raycast(new Vector3(-2 + i, 10, _startPosition - 5), Vector3.down, 20))
            {
                Debug.DrawRay(new Vector3(-2 + i, 10, _startPosition - 5), Vector3.down * 20, Color.red);
                _rays[i] = true;
            }
            else
            {
                Debug.DrawRay(new Vector3(-2 + i, 10, _startPosition - 5), Vector3.down * 20, Color.green);
                _rays[i] = false;
            }
        }

        return _rays;
    }
}
