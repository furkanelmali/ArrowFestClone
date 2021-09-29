using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Touch touch;
    public float SpeedModifier;
    public float XRange = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        SpeedModifier = 0.01f;
    }

    


    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                float xoffset = transform.position.x + touch.deltaPosition.x * SpeedModifier ;

            

                float clampxPose = Mathf.Clamp(xoffset, -XRange, XRange);
                transform.position = new Vector3(clampxPose, transform.position.y, transform.position.z);   

            }

        }
        
    }
}
