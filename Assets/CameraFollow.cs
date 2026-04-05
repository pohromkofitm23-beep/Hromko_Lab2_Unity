using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float offset = 2f; 

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y + offset, transform.position.z);
            transform.position = newPos;
        }
    }
}