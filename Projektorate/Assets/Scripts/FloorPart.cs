using UnityEngine;
using System.Collections;

public class FloorPart : MonoBehaviour {

    public FloorManager _floorManager;

    private Transform _transform;
    private float _endPos;
    private float _speed;

    // Use this for initialization
    void Start () {
        _transform = gameObject.GetComponent<Transform>();
        _speed = _floorManager._speed;
        _endPos = _floorManager._endPosition;
    }
	
	// Update is called once per frame
	void Update () {
        _transform.position += (Vector3.back * _speed) * Time.deltaTime;

        if (_transform.position.z <= _endPos) {
            Destroy(gameObject);
            _floorManager.CreateFloor();
        }        
    }

}
