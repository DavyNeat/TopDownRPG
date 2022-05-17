using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrack : MonoBehaviour
{
    private Transform pivot;
    private float angle;

    private void Start()
    {
        pivot = GetComponent<Transform>();
    }
    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - pivot.position;
        angle = Vector2.SignedAngle(Vector2.up, direction);
    }

    private void FixedUpdate()
    {
        pivot.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
