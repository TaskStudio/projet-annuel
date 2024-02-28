using UnityEngine;

public class EntityMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving;
    
    public float raycastLength = 5f;
    public float collisionAvoidanceTurn = 0.5f;

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;
        Vector3 newPosition = transform.position + directionToTarget * moveSpeed * Time.deltaTime;

        RaycastHit hit;
        // Vérifie s'il y a un obstacle dans la direction du mouvement
        if (Physics.Raycast(transform.position, directionToTarget, out hit, raycastLength))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0; 
            directionToTarget = Vector3.RotateTowards(directionToTarget, hitNormal, collisionAvoidanceTurn, 0.0f);
        }
        
        transform.position += directionToTarget * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(directionToTarget);
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isMoving = false;
        }
    }
}
