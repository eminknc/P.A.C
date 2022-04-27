using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movment : MonoBehaviour
{
    Rigidbody rb;
    Vector2 ilk_pos;
    Vector2 ikinci_pos;
    Vector2 currentPos;
    public float hiz;
    public bool move_flag = true;
    public bool swipe_flag = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Swipe();
    }

    private void Swipe()
    {
        if (swipe_flag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ilk_pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            }

            if (Input.GetMouseButtonUp(0))
            {
                ikinci_pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                currentPos = new Vector2(
                    ikinci_pos.x - ilk_pos.x,
                    ikinci_pos.y - ilk_pos.y
                );
                currentPos.Normalize();
            }
        }
        if (currentPos.y > 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            if (move_flag) rb.velocity = Vector3.forward * hiz;
        }
        else if (currentPos.y < 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            if (move_flag) rb.velocity = Vector3.back * hiz;
        }
        else if (currentPos.x > 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            if (move_flag) rb.velocity = Vector3.right * hiz;
        }
        else if (currentPos.x < 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
            if (move_flag) rb.velocity = Vector3.left * hiz;
        }
    }

}
