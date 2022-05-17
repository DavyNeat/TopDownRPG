using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    private float angle;
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - player.position;
        angle = Vector2.SignedAngle(Vector2.up, direction);
    }

    void FixedUpdate()
    {

        if (Mathf.Sign(angle) >= 0)
            player.localScale = new Vector3(1f, player.localScale.y, player.localScale.z);
        else
            player.localScale = new Vector3(-1f, player.localScale.y, player.localScale.z);
        //player.eulerAngles = new Vector3(0f, 0f, angle);
        player.position += (velocity * Time.deltaTime);
        camera.position = new Vector3(player.position.x, player.position.y, camera.position.z);
    }
}
