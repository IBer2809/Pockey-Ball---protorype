using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private float _cameraSpeed;
    public bool IsOffseting = false;
    public Vector3 Offset;


    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, _ball.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _cameraSpeed * Time.fixedDeltaTime);

        
    }
}
