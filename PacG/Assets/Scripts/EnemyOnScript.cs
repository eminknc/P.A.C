using UnityEngine;

public class EnemyOnScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("duvar"))
        {
            DusmanMovment dusmanMovment = transform.parent.GetComponent<DusmanMovment>();
            if (dusmanMovment != null)
            {
                dusmanMovment.StopMovement();
                dusmanMovment.RayKontrol();
            }
        }
    }
}