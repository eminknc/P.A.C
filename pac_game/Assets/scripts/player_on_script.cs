using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_on_script : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "duvar")
        {
            transform.parent.GetChild(1).DOScale(new Vector3(1f, 0.07f, 1f), 0.1f).OnComplete(() => transform.parent.GetChild(1).DOScale(new Vector3(1, 0.07f, 1), 0.2f));
            transform.parent.GetComponent<player_movment>().swipe_flag = true;

        }
        else if (other.gameObject.tag == "altin") {

            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "duvar")
        {
            transform.parent.GetChild(1).DOScale(new Vector3(0.6f, 0.07f, 1.6f), 0.1f);
            transform.parent.GetComponent<player_movment>().swipe_flag = false;
        }
    }

}
