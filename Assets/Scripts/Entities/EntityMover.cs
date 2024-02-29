using UnityEngine;

public class EntityMover : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool isMoving;

    public float moveSpeed = 5f;

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
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isMoving = false;
        }
    }
}