using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public float _speed = 0.1F;
    public GameObject[] _floors;
    public float _startPosition;
    public float _endPosition;

    // Use this for initialization
    void Start () {
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
        Instantiate(_floors[Random.Range(1, 5)], new Vector3(0, 0, _startPosition), Quaternion.identity);
    }
}
