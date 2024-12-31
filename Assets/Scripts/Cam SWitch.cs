using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSWitch : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isLerping = false;
    public Transform playerFace;
    public float duration;
    public Vector3 startPos;
    public Vector3 endPos;   

    public Quaternion startRot;
    public Quaternion endRot;

    public GameObject model;
    public GameObject camView;

    public bool inFace;

    void Start()
    {
        startPos = new Vector3(0.4f, -0.425f, 0.884f);
        endPos = new Vector3(0.185f, -0.029f, 0.408f);

        startRot = Quaternion.Euler(new Vector3(-90, 0, 0));
        endRot = Quaternion.Euler(new Vector3(0, -90, 90));

        inFace = false;
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
        isLerping = true;

        float elapsedTime = 0f;

        if(inFace) model.SetActive(true);

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
            transform.localRotation = Quaternion.Lerp(startRot, endRot, elapsedTime / duration);

            yield return null;
        }

        
        
        if(!inFace) model.SetActive(false);

        inFace = !inFace;

        
        

        if(inFace){
            camView.GetComponent<RGBShiftEffect>().on = true;
            camView.GetComponent<ScanlinesEffect>().on = true;
        }
        else{
            camView.GetComponent<RGBShiftEffect>().on = false;
            camView.GetComponent<ScanlinesEffect>().on = false;
        }

        

        Vector3 tmpPos = startPos;
        startPos = endPos;
        endPos = tmpPos;

        Quaternion tmpRot = startRot;
        startRot = endRot;
        endRot = tmpRot;

        isLerping = false;


    }






}
