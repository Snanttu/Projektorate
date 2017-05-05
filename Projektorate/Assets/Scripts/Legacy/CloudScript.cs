using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

    public GameObject[] _clouds;
    public float _speed;

    private Transform _transform1;
    private Transform _transform2;

    // Use this for initialization
    void Start () {
        _transform1 = _clouds[0].GetComponent<Transform>();
        _transform2 = _clouds[1].GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        _transform1.transform.Rotate(Vector3.forward * Time.deltaTime * _speed);
        _transform2.transform.Rotate(Vector3.back * Time.deltaTime * _speed);
    }
}
