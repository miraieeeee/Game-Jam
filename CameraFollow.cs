using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Range(0, 50)]
    public float Speed;
    public Transform Camera, Player;
    public Vector3 Range;

    void Start()
    {
        Range.x = -6;
        Range.y = -2.5f;
        Range.z = 1;
    }

    void Update()
    {
        Camera.position = Vector3.Lerp(Camera.position, Player.position - Range, Speed);
    }
}
