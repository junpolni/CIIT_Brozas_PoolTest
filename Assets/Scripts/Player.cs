using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float stopThreshold = 2f;
    private Transform targetTransform;
    private bool foundTarget = false;
    private Color gizmosColour = Color.yellow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (foundTarget)
        {
            Vector3 currentPosition = this.transform.position;
            float distance = Vector3.Distance(currentPosition, targetTransform.position);
            if (distance <= stopThreshold)
            {
                gizmosColour = Color.red;
                Debug.Log("Enemy within domain");

            }
            else
            {
                foundTarget = false;
                gizmosColour = Color.yellow;
                Debug.Log("Enemy outside the domain");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColour;
        Gizmos.DrawWireSphere(this.transform.position, stopThreshold);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetTransform = other.transform;
            foundTarget = true;

        }
    }
}
