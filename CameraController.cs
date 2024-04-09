using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float camPositionSpeed = 11f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newCamposition= new Vector3(offset.x, offset.y, playerTransform.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, newCamposition, camPositionSpeed * Time.deltaTime);
    }
}
