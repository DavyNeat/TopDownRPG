using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform playerBody;
    [SerializeField] private float rollTime;
    [SerializeField] public float rollCost;
    private Vector3 velocity;
    private Vector3 rollDirection;
    private float rollDirectionSign;
    private float rollTimeCountDown;
    private float angle;
    private Transform player;
    private bool sprinting;
    private bool rolling;
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
        rollTimeCountDown = rollTime;
        angle = -1f;
    }

    void Update()
    {
        if (rolling)
        {
            sprinting = false;
            velocity = Mathf.Sqrt(speed) * rollDirection * 2;
            angle = rollDirectionSign;
            rollTimeCountDown -= Time.fixedDeltaTime;
            if (rollTimeCountDown <= 0)
            {
                rolling = false;
                rollTimeCountDown = rollTime;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canRoll && !rolling)
        {            
            rollDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
            rollDirectionSign = -Input.GetAxisRaw("Horizontal");
            
            if(rollDirection.magnitude == 0)
            {
                rollDirection = new Vector3(1f, 0f, 0f);
                rollDirectionSign = -1f;
            }
            deductRollStamina = true;
            rolling = true;
        }

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
        player.position += (velocity * Time.fixedDeltaTime);
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

    public void disableRoll()
    {
        canRoll = false;
    }
    public void enableRoll()
    {
        canRoll=true;
    }
}
