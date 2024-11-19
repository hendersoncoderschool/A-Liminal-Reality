using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float vertical;
    public float MaxRotate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right, -vertical * speed *  Time.deltaTime);

        //transform.rotation.y = Mathf.clamp(-MaxRotate, PositiveMaxRotate);
    }
}
