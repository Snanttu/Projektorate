using UnityEngine;
using System.Collections;

public class FloorPart : MonoBehaviour {

    private GameObject _floorManager;
    private FloorManager _floorManagerScript;

    private Transform _transform;
    private float _endPos;
    private float _speedFloor;

    // Use this for initialization
    void Start () {
        _floorManager = GameObject.Find("FloorManager");
        _floorManagerScript = _floorManager.GetComponent<FloorManager>();
        _transform = gameObject.GetComponent<Transform>();
        _speedFloor = _floorManagerScript._speed;
        _endPos = _floorManagerScript._endPosition;
    }
	
	// Update is called once per frame
	void Update () {
        _transform.position += (Vector3.back * _speedFloor) * Time.deltaTime;
        _speedFloor = _floorManagerScript._speed;

        if (_transform.position.z <= _endPos) {
            Destroy(gameObject);
            _floorManagerScript.CreateFloor();
        }        
    }

}
