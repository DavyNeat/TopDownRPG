using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    private Transform player;
    public Transform camera;
    public float speed = 5.0f;
    void Start()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        velocity *= speed;
    }

    void FixedUpdate()
    {
        player.position += (velocity * Time.deltaTime);
        camera.position = new Vector3(player.position.x, player.position.y, camera.position.z);
    }
}
