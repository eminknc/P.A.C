using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_fallow : MonoBehaviour
{
    public Transform hedef;
    public float fallow_speed = 5;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(hedef.position.x, transform.position.y, hedef.position.z), Time.deltaTime * fallow_speed);  
    }
}
