using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _target.transform.position.y, transform.position.z);
    }
}
