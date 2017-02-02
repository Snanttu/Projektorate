﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float m_fBounceDuration;
    public Vector3 m_vStartPos;
    public Vector3 m_vEndPos;

    public ParticleSystem explosion;

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
        m_gcTransform.position = m_vStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        float fRatio = (Time.time - m_fEventTime) / m_fBounceDuration;
        m_gcTransform.position += (Vector3.back * _speed) * Time.deltaTime;

        Vector3 vPos = Vector3.Lerp(m_vStartPos, m_vEndPos, fRatio);
        //Easing.EaseInOut(fRatio, EasingType.Sine, EasingType.Sine);
        vPos.z = m_gcTransform.position.z;
        m_gcTransform.position = vPos;

        if (fRatio >= 1.0f)
        {
            FlipDirection();
            m_fEventTime = Time.time;
        }
        if (m_gcTransform.position.z <= _floorManagerScript._endPosition)
        {
            Destroy(gameObject);
        }
    }

    public void FlipDirection()
    {
        Vector3 vTemp = m_vStartPos;
        m_vStartPos = m_vEndPos;
        m_vEndPos = vTemp;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(explosion, m_gcTransform.position, Quaternion.identity);
        }
    }
}
