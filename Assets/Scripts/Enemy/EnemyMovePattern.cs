using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovePattern : MonoBehaviour
{
  
    public GameObject player;
    public Transform playerPos;


    public float moveSpeed;
    public bool leftAvail, rightAvail, forwardAvail, backwardAvail;
    public bool moveLeft, moveRight, moveForward, moveBackward;
    public bool playerSpotted;

    public int directionTimerMax;
    public int directionTimerMin;
    public int directionTimer;

    int direction;
    bool moving;
    [SerializeField] bool prioritizeForward; 
    


    [SerializeField] float castDist;
    [SerializeField] float playerSearchDist;
    [SerializeField] float playerProxBuffer; 
    // Start is called before the first frame update
    void Start()
    {
        directionTimer = Random.Range(directionTimerMin, directionTimerMax);
        player = GameObject.Find("pController");

    }

    // Update is called once per frame
    void Update()
    {
        // always look at player
        playerPos = player.transform;
        transform.LookAt(playerPos);

        checkAvailDirections();
        applyMovement();

        if (directionTimer >= 0)
        {
            directionTimer--;
        } if (directionTimer <= 0)
        {
            directionTimer = Random.Range(directionTimerMin, directionTimerMax);
            assignDirection();
        }

    }


    void assignDirection()
    {
        if (!prioritizeForward) 
        { 
            direction = Random.Range(1, 5);
            //assigning directions
            if (direction == 1) { moveLeft = true; } else { moveLeft = false; }
            if (direction == 2) { moveRight = true; } else { moveRight = false; }
            if (direction == 3) { moveForward = true; } else { moveForward = false; }
            if (direction == 4) { moveBackward = true; } else { moveBackward = false; }
        }
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

    void applyMovement()
    {
        Vector3 movePos = transform.position;

        if (Vector3.Distance(movePos, playerPos.position) < playerSearchDist)
        {
            // Swap the position of the cylinder.
            prioritizeForward = true;
            movePos = Vector3.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
            moving = true;
        }
        else if (!prioritizeForward)
        {
            if (moveLeft && leftAvail)
            {
                movePos.x -= moveSpeed * Time.deltaTime;
                moving = true;
            }
            if (moveRight && rightAvail)
            {
                movePos.x += moveSpeed * Time.deltaTime;
                moving = true;
            }
            if (moveForward && forwardAvail)
            {
                movePos.z += moveSpeed * Time.deltaTime;
                moving = true;
            }
            if (moveBackward && backwardAvail)
            {
                movePos.x -= moveSpeed * Time.deltaTime;
                moving = true;
            }

        }
        else { moving = false; }

        transform.position = movePos;
    }

}
