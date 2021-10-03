using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Touch touch;
    public float SpeedModifier;
    public float XRange = 5f;
    public GameObject Gamelay;
    public GamePlay GamePlay;
    public bool touchcontrol;
    public bool touchlock;
    public LevelSystem levelSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        SpeedModifier = 0.01f;

        Gamelay.GetComponent<GamePlay>();
        gameObject.GetComponent<LevelSystem>(); 
    }

    


    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);


            if (touchlock == false) 
            {
                if (touch.phase == TouchPhase.Moved)
                {

                    float xoffset = transform.position.x + touch.deltaPosition.x * SpeedModifier;
                    float clampxPose = Mathf.Clamp(xoffset, -XRange, XRange);
                    transform.position = new Vector3(clampxPose, transform.position.y, transform.position.z);

                    GamePlay.MainMenu.SetActive(false);
                    touchcontrol = true;

                }
                
            }
            
            

        }


        

       

        



    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {

            levelSystem.ArrowNumControl(1);

        }
        


        
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (GamePlay.currentArrow <= 0)
        {
            
            
            levelSystem.ArrowNumControl(0);
        }
    }
}
