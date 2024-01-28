using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovePattern : MonoBehaviour
{
  
    public GameObject player;
    public Transform playerPos;


    public float moveSpeed;
    public bool leftAvail, rightAvail, forwardAvail, backwardAvail;
    public bool moveLeft, moveRight, moveForward, moveBackward;
    public bool runAway;

    public int directionTimerMax;
    public int directionTimerMin;
    public int directionTimer;

    int direction;
    bool moving;
    bool grounded; 
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
       // if (!prioritizeForward) 
       // {  moveLeft = false;
            moveRight = false;
            moveLeft = false;
            moveBackward = false;
            moveForward = false;

            direction = Random.Range(1, 5);
            //assigning directions
            if (direction == 1 && leftAvail) { moveLeft = true; } 
            if (direction == 2 && rightAvail) { moveRight = true; }
            if (direction == 3 && forwardAvail) { moveForward = true; } 
            if (direction == 4 && backwardAvail) { moveBackward = true; } 
            else { direction = Random.Range(1, 5); }
        //}
    }

    void checkAvailDirections()
    {
        leftAvail = true; rightAvail = true; forwardAvail = true; backwardAvail = true; 
        
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position /*start position for ray*/ , transform.right /*cast direction */ , out hit, castDist /* ray cast distance */))
        {
            if (hit.transform.tag == "Wall") { rightAvail = false; }
            
        }
        if (Physics.Raycast(transform.position /*start position for ray*/ , -transform.right /*cast direction */ , out hit, castDist /* ray cast distance */))
        {
            if (hit.transform.tag == "Wall") { leftAvail = false; }
        }
        if (Physics.Raycast(transform.position /*start position for ray*/ , transform.forward /*cast direction */ , out hit, castDist /* ray cast distance */))
        {
            if (hit.transform.tag == "Wall") { forwardAvail = false; }
        }
        if (Physics.Raycast(transform.position /*start position for ray*/ , -transform.forward /*cast direction */ , out hit, castDist /* ray cast distance */))
        {
            if (hit.transform.tag == "Wall") { backwardAvail = false; }
        }

    }

    void applyMovement()
    {
        Vector3 movePos = transform.position;
        transform.LookAt(playerPos);
        /*
        if (runAway)
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
        } */
        /*if (!runAway)
        {
            if (Vector3.Distance(movePos, playerPos.position) < playerSearchDist && Vector3.Distance(movePos, playerPos.position) > playerProxBuffer)
            {
                // Swap the position of the cylinder.
                prioritizeForward = true;
                movePos = Vector3.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
                moving = true;
            }
            else if (Vector3.Distance(movePos, playerPos.position) > playerSearchDist) { prioritizeForward = false; }
        */

            //if (!prioritizeForward)
            //{
                if (moveLeft)
                {
                    movePos.x -= moveSpeed * Time.deltaTime;
                    moving = true;
                }
                if (moveRight)
                {
                    movePos.x += moveSpeed * Time.deltaTime;
                    moving = true;
                }
                if (moveForward)
                {
                    movePos.z += moveSpeed * Time.deltaTime;
                    moving = true;
                }
                if (moveBackward)
                {
                    movePos.x -= moveSpeed * Time.deltaTime;
                    moving = true;
                }
            //}
       /* } */

        //Gravity

        else { moving = false; }

        transform.position = movePos;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Vector3 movePos = transform.position;
            transform.position = movePos;
        }
    }

}
