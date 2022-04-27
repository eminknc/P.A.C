using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman_on_script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "duvar")
        {
            transform.parent.GetComponent<dusman_movment>().move_flag = false;
            transform.parent.GetComponent<dusman_movment>().ray_kontrol();
        }
    }
}
