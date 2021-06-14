using UnityEngine;

public class MoveWIthPlayer : MonoBehaviour
{
    private Transform player;
    [SerializeField]private float smooth = 0.125f;
    [SerializeField]private Vector3 offset;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 desiredposition = player.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredposition, smooth);
        transform.position = smoothed;

        transform.LookAt(player);
    }


}
