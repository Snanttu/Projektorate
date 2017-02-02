﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBounceBetweenPoints : MonoBehaviour
{

    public float m_fBounceDuration;
    public Vector3 m_vStartPos;
    public Vector3 m_vEndPos;

    private Transform m_gcTransform;
    private float m_fEventTime;

    // Use this for initialization
    void Start()
    {
        m_gcTransform = GetComponent<Transform>();
        m_fEventTime = Time.time;
        m_gcTransform.position = m_vStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        float fRatio = (Time.time - m_fEventTime) / m_fBounceDuration;

        Vector3 vPos = Vector3.Lerp(m_vStartPos, m_vEndPos, fRatio); // Easing.EaseInOut(fRatio, EasingType.Sine, EasingType.Sine));
        vPos.z = m_gcTransform.position.z;
        m_gcTransform.position = vPos;

        if (fRatio >= 1.0f)
        {
            FlipDirection();
            m_fEventTime = Time.time;
        }
    }

    public void FlipDirection()
    {
        Vector3 vTemp = m_vStartPos;
        m_vStartPos = m_vEndPos;
        m_vEndPos = vTemp;
    }
}
