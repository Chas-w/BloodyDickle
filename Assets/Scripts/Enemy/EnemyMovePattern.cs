using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovePattern : MonoBehaviour
{
    public GameObject player;
    public Transform playerPos;
    public Animator animator;

    public bool towardsPlayer; 

    public float moveSpeed;
    public bool leftAvail, rightAvail, forwardAvail, backwardAvail;
    public bool moveLeft, moveRight, moveForward, moveBackward;
    public bool playerSpotted;

    public int directionTimerMax;
    public int directionTimerMin;
    public int directionTimer;

    int direction;
    bool moving;
    public bool canMove; 


    [SerializeField] float castDist;
    // Start is called before the first frame update
    void Start()
    {
        directionTimer = Random.Range(directionTimerMin, directionTimerMax);
        player = GameObject.Find("pController");
        

    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 1f;  
        // always look at player
        playerPos = player.transform;
        Vector3 adjusted = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z);
        transform.LookAt(adjusted);

        if (canMove)
        {
            if (towardsPlayer)
            {
                checkAvailDirections();
                attractMove();
            }

            if (!towardsPlayer)
            {
                checkAvailDirections();
                applyMovement();

                if (directionTimer >= 0)
                {
                    directionTimer--;
                }
                if (directionTimer <= 0)
                {
                    directionTimer = Random.Range(directionTimerMin, directionTimerMax);
                    assignDirection();
                }
            }

            if (!moving)
            {
                animator.SetTrigger("idleTrigger");
            }
        }
        if (!canMove)
        {
            transform.position += Vector3.zero; 
        }
   
    }


    void assignDirection()
    {
        transform.LookAt(playerPos);
        direction = Random.Range(1, 5);
        //assigning directions
        if (direction == 1) { moveLeft = true; } else { moveLeft = false; }
        if (direction == 2) { moveRight = true; } else { moveRight = false; }
        if (direction == 3) { moveForward = true; } else { moveForward = false; }
        if (direction == 4) { moveBackward = true; } else { moveBackward = false; }


    }

    void checkAvailDirections()
    {
        leftAvail = true; rightAvail = true; forwardAvail = true; backwardAvail = true;

        RaycastHit hit;

        if (Physics.Raycast(transform.position /*start position for ray*/ , transform.right /*cast direction */ , out hit, castDist /* ray cast distance */))
        {
            rightAvail = false;
        }
        if (Physics.Raycast(transform.position /*start position for ray*/ , -transform.right /*cast direction */ , out hit, castDist /* ray cast distance */))
        {
            leftAvail = false;
        }
        if (Physics.Raycast(transform.position /*start position for ray*/ , transform.forward /*cast direction */ , out hit, castDist /* ray cast distance */))
        {
            forwardAvail = false;
        }
        if (Physics.Raycast(transform.position /*start position for ray*/ , -transform.forward /*cast direction */ , out hit, castDist /* ray cast distance */))
        {
            backwardAvail = false;
        }


    }

    void attractMove()
    {
        Vector3 movePos = transform.position;

        if (playerPos.position.x > movePos.x && rightAvail)
        {
            movePos.x += moveSpeed * Time.deltaTime;
            moving = true;
        }
        
        if (playerPos.position.x  < movePos.x  && leftAvail)
        {
            movePos.x -= moveSpeed * Time.deltaTime;
            moving = true;
        }
        if (playerPos.position.z > movePos.z && forwardAvail)
        {
            movePos.z += moveSpeed * Time.deltaTime;
            moving = true;
        }
        if (playerPos.position.z < movePos.z && backwardAvail)
        {
            movePos.z -= moveSpeed * Time.deltaTime;
            moving = true;
        }
        else { moving = false; }
        transform.position = movePos;
    }

    void applyMovement()
    {
        Vector3 movePos = transform.position;

        if (moveLeft && leftAvail)
        {
            movePos.x -= moveSpeed * Time.deltaTime;
            animator.SetTrigger("leftTrigger");
            moving = true;
        } 
        if (moveRight && rightAvail)
        {
            movePos.x += moveSpeed * Time.deltaTime;
            animator.SetTrigger("rightTrigger");
            moving = true;
        } 
        if (moveForward && forwardAvail)
        {
            movePos.z += moveSpeed * Time.deltaTime;
            animator.SetTrigger("forwardTrigger");
            moving = true;
        } 
        if (moveBackward && backwardAvail)
        {
            movePos.z -= moveSpeed * Time.deltaTime;
            animator.SetTrigger("awayTrigger");
            moving = true;
        }
        else { moving = false; }

        transform.position = movePos;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "attract")
        {
            towardsPlayer = true;
            animator.SetTrigger("forwardTrigger");
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "unSpawn")
        {
            Destroy(gameObject, 2);
        }
        if (other.gameObject.tag == "attract")
        {
            towardsPlayer = false;
            animator.SetTrigger("awayTrigger");
        }
    }

}
