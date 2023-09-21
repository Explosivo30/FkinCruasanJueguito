using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

}
