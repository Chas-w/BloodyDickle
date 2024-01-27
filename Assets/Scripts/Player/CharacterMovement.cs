using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Referenced these tutorials: https://www.youtube.com/watch?v=_QajrabyTJc&t=171s, https://gamedevbeginner.com/raycasts-in-unity-made-easy/#raycast
    [Header("Mouse Settings")]
    public Transform pBody;
    public Animator bounceAnim;
    public float bounceSpeed; 
    public float mouseSens = 100f;

    [Header("Keyboard Settings")]
    public CharacterController controller; 
    public float moveSpeedMax = 15f;
    public float walkRate;

    [Header("Physics")]
    public LayerMask groundLayer;
    public float grav;
    public float castDist;
    public bool grounded;

    [Header("Other Settings")]
    public HealthDamageManager enemyHDM;
    public HealthDamageManager playerHDM; 
    Vector3 currentVelo; 
    

    float moveSpeed;

    void Start()
    {
        Cursor.visible = false; // Hides the cursor
        Cursor.lockState = CursorLockMode.Confined; //confines cursor to the scene
        bounceAnim.speed = 0; 

        playerHDM = GetComponent<HealthDamageManager>();    
    }
    // Update is called once per frame
    void Update()
    {
        //using old input system 

        //Mouse Look 
        float mouseX = Input.GetAxis("Mouse X") * mouseSens /* Speed at which mouse moves */ * Time.deltaTime /* Framerate independence */;
        pBody.Rotate(Vector3.up * mouseX);

        //WASD Move
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xAxis + transform.forward * zAxis; //transform.direction uses local directions rather than global 

        //Glidy Movement
        if (move != Vector3.zero) //checking if the player is moving 
        {
            if (moveSpeed < moveSpeedMax)
            {
                moveSpeed += walkRate;
                if (bounceAnim.speed < 1) { bounceAnim.speed += bounceSpeed; }
            }
        }
        else if (move == Vector3.zero)
        {
            if (moveSpeed >= 0)
            {
                moveSpeed -= walkRate;
                if (bounceAnim.speed >= 0) { bounceAnim.speed -= bounceSpeed; }
            }
        }
        controller.Move(move * moveSpeed * Time.deltaTime); //move function applies movement

        //Gravity
        RaycastHit hit; 
        if (Physics.Raycast(transform.position /*start position for ray*/ ,-transform.up /*cast direction */ ,out hit, castDist /* ray cast distance */))
        {
            grounded = true;
        } else { grounded = false; }
        

        if (!grounded)
        {
            currentVelo.y += grav * Time.deltaTime;
            controller.Move(currentVelo * Time.deltaTime); //mulitplied by time.deltatime again bc of physics of free fall (needs to be multiplied by time^2}
        } else if (grounded)
        {
            currentVelo.y = 0; //resets velocity so gravity is not constant
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Attack 
            if (Input.GetMouseButton(0))
            {
                playerHDM.DealDamage(enemyHDM.gameObject);
            }
        }
    }

}
