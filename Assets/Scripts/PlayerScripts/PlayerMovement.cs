using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ParticleSystem sprintingDust;
    [SerializeField] private ParticleSystem dashingDust;
    [SerializeField] private float speed;
    [SerializeField] private Transform playerBody;
    [SerializeField] public float rollCost;
    [SerializeField] public float rollDistance;
    [SerializeField] private float sprintMultiplier;
    private Vector3 velocity;
    private Vector3 rollDirection;
    private Vector3 rollLocation;
    private float angle;
    private Transform player;
    private bool sprinting;
    public bool rolling;
    private bool canRoll;
    public bool deductRollStamina;
    private PlayerStatus status;
    public Transform camera;
    
    void Start()
    {
        player = GetComponent<Transform>();
        status = GetComponent<PlayerStatus>();
        sprinting = false;
        rolling = false;
    }

    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - player.position;
        angle = Vector2.SignedAngle(Vector2.up, direction);

        if (rolling)
        {
            sprinting = false;
            if (player.position == rollLocation)
                rolling = false;
            angle = Vector2.SignedAngle(Vector2.up, rollDirection);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canRoll && !rolling)
        {         
            rollDirection = (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f)).normalized;
            dashingDust.Play();
            if (rollDirection.magnitude == 0)
            {
                rollDirection = -(direction.normalized);
            }
            rollLocation = player.position + (rollDirection * rollDistance);
            deductRollStamina = true;
            rolling = true;
        }

        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        
        if (Input.GetKey(KeyCode.LeftShift) && !sprinting && status.currentStamina() > 0f && velocity.magnitude != 0)
        {
            sprinting = true;
        }

        if ((Input.GetKeyUp(KeyCode.LeftShift) || status.currentStamina() <= 0f) && sprinting || velocity.magnitude == 0)
        {
            sprinting = false;
        }

        
        velocity *= Mathf.Sqrt(speed);
        if (sprinting)
            velocity *= sprintMultiplier;
    }

    void FixedUpdate()
    {
        if (sprinting)
            sprintingDust.Play();
        if (rolling)
            dashingDust.Play();

        if (Mathf.Sign(angle) <= 0)
            playerBody.localScale = new Vector3(1f, player.localScale.y, player.localScale.z);
        else
            playerBody.localScale = new Vector3(-1f, player.localScale.y, player.localScale.z);
        
        if (!rolling)
            player.position += (velocity * Time.fixedDeltaTime);
        else
            player.position = Vector3.MoveTowards(player.position, rollLocation, speed * Time.deltaTime);
        camera.position = new Vector3(player.position.x, player.position.y, camera.position.z);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 0 && rolling)
            rolling = false;
    }
    public void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.layer != 0 && rolling)
            rolling = false;
    }

    public bool isMoving()
    {
        return velocity.x != 0 || velocity.y != 0;
    }
    public bool isSprinting()
    {
        return sprinting;
    }
    public bool isDashing()
    {
        return rolling;
    }
    public void updateSpeed(int points)
    {
        speed = Mathf.Sqrt(points);
    }

    public void disableRoll()
    {
        canRoll = false;
    }
    public void enableRoll()
    {
        canRoll=true;
    }
}
