using UnityEngine;

public class MoveWIthPlayer : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredposition = player.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredposition, smooth);
        transform.position = smoothed;

        transform.LookAt(player);
    }


}
