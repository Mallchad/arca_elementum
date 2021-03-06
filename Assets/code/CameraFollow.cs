﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    public float smoothing = 0.3f;
    public float lag;
    public float height;
    public float depth;
    public float minBoundaryDistance;
    Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void
    Start()
    {
        Vector3 Pos = new Vector3();
        Pos.x = PlayerTransform.position.x;
        Pos.x = PlayerTransform.position.y + height;
        Pos.x = PlayerTransform.position.y - depth;
        transform.position = Vector3.SmoothDamp(transform.position,
                                                Pos,
                                                ref velocity,
                                                smoothing);
    }

    // Update is called once per frame
    void
    Update()
    {

    }

}
