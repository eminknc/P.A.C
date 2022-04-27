using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman_movment : MonoBehaviour
{
    Transform hedef;
    public float _moveSpeed;
    public bool move_flag = false;
    Vector3 old_scale;
    void Start()
    {
        old_scale = transform.GetChild(1).localScale;
        StartCoroutine(wait());
    }

    void Update()
    {

        if (move_flag)
        {
            transform.position = Vector3.MoveTowards(transform.position, hedef.position, Time.deltaTime * _moveSpeed);
        }
    }

    public void ray_kontrol()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        RaycastHit hit;
        
        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
            {
                if (Vector3.Distance(hit.transform.position, transform.position) < 1.2f) ray_kontrol();
                else
                {
                   
                    hedef = hit.transform;
                    transform.LookAt(hedef);
                    move_flag = true;
                }

            }
        }
        else if (rand == 1)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))
            {
                if (Vector3.Distance(hit.transform.position, transform.position) < 1.2) ray_kontrol();
                else
                {
                    
                    hedef = hit.transform;
                    transform.LookAt(hedef);
                    move_flag = true;
                }

            }
        }
        else if (rand == 2)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (Vector3.Distance(hit.transform.position, transform.position) < 1.2) ray_kontrol();
                else
                {
                    
                    hedef = hit.transform;
                    transform.LookAt(hedef);
                    move_flag = true;
                }

            }
        }
        else if (rand == 3)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity))
            {
                if (Vector3.Distance(hit.transform.position, transform.position) < 1.2) ray_kontrol();
                else
                {
                   

                    hedef = hit.transform;
                    transform.LookAt(hedef);
                    move_flag = true;
                }

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == hedef)
        {
            transform.GetChild(1).DOScale(old_scale, 0.1f).OnComplete(() => transform.GetChild(1).DOScale(old_scale, 0.2f));
            move_flag = false;
            StartCoroutine(wait());
        }
        else if (collision.gameObject.tag == "dusman"|| collision.gameObject.tag == "Player") {
            ray_kontrol();


        }
    }
    IEnumerator wait() {
        yield return new WaitForSeconds(1f);
        transform.GetChild(1).DOScale(new Vector3(old_scale.x*0.6f, 0.07f, old_scale.z * 1.6f), 0.1f);
        ray_kontrol();
    }
}
