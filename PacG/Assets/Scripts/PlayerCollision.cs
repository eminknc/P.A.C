using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("duvar"))
        {
            HandleWallCollision();
        }
        else if (other.gameObject.CompareTag("altin"))
        {
            HandleGoldCollision(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("duvar"))
        {
            HandleWallExit();
        }
    }

    private void HandleWallCollision()
    {
        Transform playerTransform = transform.parent;
        Transform playerChildTransform = playerTransform.GetChild(1);

        playerChildTransform.DOScale(new Vector3(1f, 0.07f, 1f), 0.1f)
            .OnComplete(() => playerChildTransform.DOScale(new Vector3(1, 0.07f, 1), 0.2f));

        playerTransform.GetComponent<PlayerMovement>().swipe_flag = true;
    }

    private void HandleWallExit()
    {
        Transform playerTransform = transform.parent;
        Transform playerChildTransform = playerTransform.GetChild(1);

        playerChildTransform.DOScale(new Vector3(0.6f, 0.07f, 1.6f), 0.1f);
        playerTransform.GetComponent<PlayerMovement>().swipe_flag = false;
    }

    private void HandleGoldCollision(GameObject goldObject)
    {
        Destroy(goldObject);
        // Burada altýn ile etkileþimi iþleyebilirsiniz.
    }
}