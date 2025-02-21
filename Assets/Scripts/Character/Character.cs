using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    //public CapsuleCollider cc;
    private readonly float moveSpeed = 5.0f;

    public void Move(Vector3 velocity)
    {
        rb.MovePosition(rb.position + velocity * moveSpeed);
    }
}
