using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NoClip : MonoBehaviour
{
    public GameObject loc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider Bean)
    {
        Bean.gameObject.transform.position = loc.transform.position;
    }
}
