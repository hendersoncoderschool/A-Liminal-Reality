using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSWitch : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isLerping = false;
    public Transform playerFace;
    public float duration;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            MoveCamera();
        }
    }



    void MoveCamera()
    {
        if (!isLerping)

        {
            StartCoroutine(LerpCamera());
        }
    }

    private IEnumerator LerpCamera()
    {
        return null;
    }


}
