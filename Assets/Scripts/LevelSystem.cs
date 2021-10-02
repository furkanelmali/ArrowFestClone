using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public GameObject levelfinisher;
    public GameObject spawnPos;
    public GameObject[] Levels;
    public GameObject LevelUpScene;
    public GameObject MainMenu;
    public GameObject Character;
    public GameObject FailedScene;

    public Movement movement;
    public GamePlay gameplay;

    public bool levelControl;

    
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Movement>();
        gameObject.GetComponent<GamePlay>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

    public void ArrowNumControl(int num)
    {
        Debug.Log("Dead");
        switch (num)
        {
            
            case 1:
                if (gameplay.currentArrow <= 0)
                {
                    LevelUpScene.SetActive(true);

                    movement.touchlock = true;
                    movement.touchcontrol = false;

                    levelControl = true;
                }
               

                break;

            case 0:

                if (gameplay.currentArrow <= 0)
                {
                    
                    FailedScene.SetActive(true);
                    movement.touchlock = true;
                    movement.touchcontrol = false;

                }
               
                break;

        }

        
    }


    public void ReturnHomepage()
    {
        if (levelControl == true) 
        {
            LevelUpScene.SetActive(false);
            MainMenu.SetActive(true);
            Character.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y, spawnPos.transform.position.z);
            movement.touchlock = false;
            levelControl = false;
        }
        else
        {
            Character.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y, spawnPos.transform.position.z);
            movement.touchlock = false;
            FailedScene.SetActive(false);
            MainMenu.SetActive(true);
            


        }
        

    }
}
