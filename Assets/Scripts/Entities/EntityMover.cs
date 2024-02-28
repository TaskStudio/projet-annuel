using UnityEngine;

public class EntityMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask groundLayer;
    private Vector3 targetPosition;
    private bool isMoving;
    
    public float raycastLength = 5f;
    public float collisionAvoidanceTurn = 0.5f;
    
    private float groundCheckDistance;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        groundCheckDistance = collider.bounds.extents.y;
    }

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
        directionToTarget.y = 0;
        
        RaycastHit hit;
        Vector3 currentPosition = transform.position + Vector3.up * groundCheckDistance;
        if (Physics.SphereCast(currentPosition, groundCheckDistance, directionToTarget, out hit, raycastLength, ~groundLayer))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0;
            directionToTarget = Vector3.RotateTowards(directionToTarget, hitNormal, collisionAvoidanceTurn, 0.0f);
        }

        // Déplacement de l'unité dans la direction ajustée
        transform.position += directionToTarget * moveSpeed * Time.deltaTime;

        // Raycast vers le bas pour déterminer la position y en fonction du sol
        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, groundCheckDistance + 0.2f, groundLayer))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + groundCheckDistance, transform.position.z);
        }
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isMoving = false;
        }
        
        if (directionToTarget != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, moveSpeed * Time.deltaTime);
        }
    }
}
