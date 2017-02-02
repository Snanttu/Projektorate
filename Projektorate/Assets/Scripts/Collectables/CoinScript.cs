using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{    
    public Vector3 m_vEndPos;
    public ParticleSystem coinEffect;

    private Transform m_gcTransform;
    private float m_fEventTime;

    private GameObject _floorManager;
    private FloorManager _floorManagerScript;
    private float _speed;

    // Use this for initialization
    void Start()
    {
        _floorManager = GameObject.Find("FloorManager");
        _floorManagerScript = _floorManager.GetComponent<FloorManager>();
        _speed = _floorManagerScript._speed;
        m_gcTransform = GetComponent<Transform>();
        m_fEventTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        m_gcTransform.position += (Vector3.back * _speed) * Time.deltaTime;        
        
        if (m_gcTransform.position.z <= _floorManagerScript._endPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(coinEffect, m_gcTransform.position, Quaternion.identity);
        }
    }
}
