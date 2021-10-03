using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public GameObject levelfinisher;
    public GameObject spawnPos;
    public GameObject[] Levels;
    public GameObject LevelUpScene;
    public GameObject MainMenu;
    public GameObject Character;
    public GameObject FailedScene;
    public GameObject EndLevel;
    public GameObject DemoOver;
    


    public Movement movement;
    public GamePlay gameplay;


    public int levelint;
    public Text levet;
    public bool levelControl;

    

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<Movement>();
        gameObject.GetComponent<GamePlay>();

        levelint = PlayerPrefs.GetInt("LevelSave");
        PlayerPrefs.SetString("LevelText", levet.text);
        levelup();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ArrowNumControl(int num)
    {
        
        switch (num)
        {
            
            case 1:
                if (gameplay.currentArrow <= 1)
                {
                   

                    LevelUpScene.SetActive(true);
                    levelint++;
                    levelup();
                    PlayerPrefs.SetInt("LevelSave", levelint);
                    PlayerPrefs.SetString("LevelText", levet.text);
                    movement.touchcontrol = false;
                    levelControl = true;
                    
                }

                break;

            case 0:

                if (gameplay.currentArrow <= 1)
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
            gameplay.EndLevelCleaner();

            

            if (gameplay.currentArrow < gameplay.startingArrowNum)
            {
                gameplay.currentArrow = gameplay.startingArrowNum;
                gameplay.CloneNumber = gameplay.currentArrow - 1;

                gameplay.triggerControl = true;
                gameplay.CreateArrows(gameplay.CloneNumber);
                gameplay.triggerControl = false;
            }



        }
        else
        {
            Character.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y, spawnPos.transform.position.z);
            movement.touchlock = false;
            FailedScene.SetActive(false);
            MainMenu.SetActive(true);
            gameplay.EndLevelCleaner();

            if (gameplay.currentArrow < gameplay.startingArrowNum)
            {
                gameplay.currentArrow = gameplay.startingArrowNum;
                gameplay.CloneNumber = gameplay.currentArrow - 1;
               
                gameplay.triggerControl = true;
                gameplay.CreateArrows(gameplay.CloneNumber);
                gameplay.triggerControl = false;
            }

        }
    }

    public void levelup()
    {
       

       
        if (levelint == 1)
        {
            Levels[0].SetActive(false);
            Levels[1].SetActive(true);
        }

        else if (levelint == 2)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(true);
        }

        else if (levelint == 3)
        {
            Levels[2].SetActive(false);
            Levels[3].SetActive(true);
        }

        else if (levelint == 4)
        {
            Levels[3].SetActive(false);
            Levels[4].SetActive(true);
        }

        else if(levelint == 5)
        {
            DemoOver.SetActive(true);
            movement.touchlock = true;
            movement.touchcontrol = false;
            MainMenu.SetActive(false);
            FailedScene.SetActive(false);
            LevelUpScene.SetActive(false);
        }
        int levelnum = levelint + 1;
        levet.text = "Level " + levelnum.ToString();

        

        
    }


}
