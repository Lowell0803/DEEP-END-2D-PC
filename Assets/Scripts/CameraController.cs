using UnityEngine;

public class CameraController : MonoBehaviour
{
    // room camera
    [SerializeField] private float speed = 10f;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    // camera follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance = 6f;
    [SerializeField] private float cameraSpeed = 2f;
    private float lookAhead;

    // simple follow:
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    private void Update()
    {
        // room camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        // camera follow player
        //transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);

        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
