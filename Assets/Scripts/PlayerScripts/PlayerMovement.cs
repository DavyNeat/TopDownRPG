using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    private float angle;
    private Transform player;
    [SerializeField] private Transform playerBody;
    private bool sprinting;
    private PlayerStatus status;
    public Transform camera;
    [SerializeField] private float speed;
    void Start()
    {
        player = GetComponent<Transform>();
        status = GetComponent<PlayerStatus>();
        sprinting = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !sprinting && status.currentStamina() > 0f)
        {
            sprinting = true;
        }

        if ((Input.GetKeyUp(KeyCode.LeftShift) || status.currentStamina() <= 0f) && sprinting)
        {
            sprinting = false;
        }

        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        velocity *= Mathf.Sqrt(speed);
        if (sprinting)
            velocity *= 1.5f;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - player.position;
        angle = Vector2.SignedAngle(Vector2.up, direction);
    }

    void FixedUpdate()
    {

        if (Mathf.Sign(angle) <= 0)
            playerBody.localScale = new Vector3(1f, player.localScale.y, player.localScale.z);
        else
            playerBody.localScale = new Vector3(-1f, player.localScale.y, player.localScale.z);
        //player.eulerAngles = new Vector3(0f, 0f, angle);
        player.position += (velocity * Time.deltaTime);
        camera.position = new Vector3(player.position.x, player.position.y, camera.position.z);
    }

    public bool isMoving()
    {
        return velocity.x != 0 || velocity.y != 0;
    }

    public void updateSpeed(int points)
    {
        speed += points;
    }

    public bool isSprinting()
    {
        return sprinting;
    }
}
