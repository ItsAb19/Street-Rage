using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed;
    public float xOffset;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, transform.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
