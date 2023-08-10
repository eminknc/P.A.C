using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Transform target;
    private bool canMove = false;
    private Vector3 oldScale;

    private void Start()
    {
        oldScale = transform.GetChild(1).localScale;
        StartCoroutine(InitialMovement());
    }

    private void Update()
    {
        if (canMove)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
    }

    public void StartMoving(Transform newTarget)
    {
        target = newTarget;
        transform.LookAt(target);
        canMove = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == target)
        {
            ResetScaleAnimation();
            canMove = false;
            StartCoroutine(WaitAndMove());
        }
        else if (collision.gameObject.CompareTag("dusman") || collision.gameObject.CompareTag("Player"))
        {
            ray_kontrol();
        }
    }

    private void ResetScaleAnimation()
    {
        transform.GetChild(1).DOScale(oldScale, 0.1f).OnComplete(() => transform.GetChild(1).DOScale(oldScale, 0.2f));
    }

    private IEnumerator InitialMovement()
    {
        yield return new WaitForSeconds(1f);
        ScaleAnimation();
        ray_kontrol();
    }

    private IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(1f);
        ScaleAnimation();
        ray_kontrol();
    }

    private void ScaleAnimation()
    {
        transform.GetChild(1).DOScale(new Vector3(oldScale.x * 0.6f, 0.07f, oldScale.z * 1.6f), 0.1f);
    }

    private void ray_kontrol()
    {
        transform.GetChild(0).gameObject.SetActive(false);

        int rand = Random.Range(0, 4);
        Vector3 direction = Vector3.zero;

        switch (rand)
        {
            case 0:
                direction = Vector3.right;
                break;
            case 1:
                direction = Vector3.left;
                break;
            case 2:
                direction = Vector3.forward;
                break;
            case 3:
                direction = Vector3.back;
                break;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out RaycastHit hit, Mathf.Infinity))
        {
            if (Vector3.Distance(hit.transform.position, transform.position) >= 1.2f)
            {
                target = hit.transform;
                transform.LookAt(target);
                canMove = true;
            }
            else
            {
                ray_kontrol();
            }
        }
    }
}