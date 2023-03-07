using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    [SerializeField] private float FallowSpeed = 2.0f;
    [SerializeField] private float yOffset = 1f;
    [SerializeField] Transform Target;
  
    void Update()
    {
        Vector3 newPos = new Vector3(Target.position.x, Target.position.y + yOffset , -10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FallowSpeed * Time.deltaTime);
    }
}
