using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 initialPos;
    private Vector2 finalPos;
    private Vector2 swipeDirection;

    public float speed;
    public bool canMove = true;
    public bool canSwipe = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleSwipe();
    }

    private void HandleSwipe()
    {
        if (canSwipe)
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                finalPos = Input.mousePosition;
                swipeDirection = (finalPos - initialPos).normalized;
                MovePlayer(swipeDirection);
            }
        }
    }

    private void MovePlayer(Vector2 direction)
    {
        if (!canMove)
            return;

        float x = direction.x;
        float y = direction.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
            {
                Move(Vector3.right);
            }
            else
            {
                Move(Vector3.left);
            }
        }
        else
        {
            if (y > 0)
            {
                Move(Vector3.forward);
            }
            else
            {
                Move(Vector3.back);
            }
        }
    }

    private void Move(Vector3 direction)
    {
        transform.LookAt(transform.position + direction);
        rb.velocity = direction * speed;
    }
}