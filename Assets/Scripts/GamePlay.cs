using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GamePlay : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject ArrowBox;
    public GameObject MainMenu;

    public TextMesh CloneBox;
    public string Tags;

    public Text ArrowLevel, IncomeLevel, ArrowPrize, IncomePrize;
   

    public int ArrowPrizeint = 250;
    public int IncomePrizeint = 250;
    public int ArrowLevelint;
    public int IncomeLevelint;

    public int currentArrow, cloneBoxİnt, CloneNumber, DestroyNumber, startingArrowNum;
    

    public int Gold;
    public Text GoldText;

    public bool triggerControl, destroyControl;

    public int CloneTag = 1;
       
  
    // Start is called before the first frame update
    void Start()
    {

        
        SaveSystem();

        currentArrow = startingArrowNum;

        if (startingArrowNum > 1)
        {
            CloneNumber = startingArrowNum - 1;
            triggerControl = true;
            CreateArrows(CloneNumber);
            triggerControl = false;
        }



        IncomeLevelint = 1;
            
        

        



    }

    // Update is called once per frame
    void Update()
    {

        


        int.TryParse(CloneBox.text, out cloneBoxİnt);
        
        if (triggerControl)
        {
            Calculations();

            if (Tags.Equals("Sum") || Tags.Equals("Multiplie"))
            {
                CreateArrows(CloneNumber);
            }

            else if (Tags.Equals("Divide") || Tags.Equals("Extract"))
            {
                destroyControl = true;
                DestroyingArrows(DestroyNumber);
                destroyControl = false;
                
            }
            triggerControl = false;
        }
        else
        {

        }

  
        
    }

    public void Calculations()
    {
        switch (Tags)
        {
            case "Sum":
                CloneNumber = cloneBoxİnt;
                currentArrow = CloneNumber + currentArrow;
 
                break;

            case "Multiplie":
                CloneNumber = cloneBoxİnt * currentArrow - currentArrow;
                Debug.Log("cloneboxİnt"+cloneBoxİnt);
                Debug.Log("currentArrow" + currentArrow);
                currentArrow = CloneNumber + currentArrow;
                break;

            case "Extract":
                DestroyNumber = cloneBoxİnt;
                currentArrow = currentArrow - cloneBoxİnt;
                
                break;

            case "Divide":
                DestroyNumber = currentArrow / cloneBoxİnt;
                currentArrow = currentArrow - DestroyNumber;
                break;


        }

        if(currentArrow < 0)
        {
            currentArrow = 0;
        }

        



    } //Calculations For Cloning-Destroying


    public void CreateArrows(int Arrows) 
    {
        Debug.Log(Arrows);
        if (triggerControl)
        {
            for (int i = 0; i < Arrows; i++)

            {
                
                float radius = 1;

                //float clone = i * 0.1f;

                float yaricap = 0.5f;

                float theta = i * 2 * Mathf.PI / Arrows;

                float x = Mathf.Sin(theta)*radius;
                float y = Mathf.Cos(theta)*radius;

                
                var spawnDir = new Vector3(x, y, 0);
                var spawnPos = Arrow.transform.position + spawnDir * yaricap;



                GameObject ArrowClone = Instantiate(Arrow, new Vector3(spawnPos.x, spawnPos.y,Arrow.transform.position.z), Arrow.transform.rotation);
                ArrowClone.transform.parent = ArrowBox.transform;
                ArrowClone.name = "ArrowClone" + i;
                ArrowClone.gameObject.tag = "ArrowClone" ;
                


                
            }

        }
       
    
    } //Creating Arrows

    public void DestroyingArrows(int Destroynum)
    {
        

        if (destroyControl) 
        {
            int sides = 1;


            for (int i = ArrowBox.transform.childCount - 1; i >= 1; i--) 
            {
                
                Destroy(ArrowBox.transform.GetChild(i).gameObject);
                if (sides == Destroynum)
                {
                    break;
                }
                sides++;
            }

           
        }
        
        
    }//Destroying Arrows

    public void ArrowLevelİncreasing()
    {
        if (Gold >= ArrowPrizeint)
        {

            Gold = Gold - ArrowPrizeint;
            GoldText.text = Gold.ToString();

            startingArrowNum++;
            ArrowLevelint++;
            ArrowLevel.text = "Level " + ArrowLevelint.ToString();
            ArrowPrizeint = ArrowPrizeint * ArrowLevelint;
            ArrowPrize.text = ArrowPrizeint.ToString();
            
            
            CloneNumber = 1;
            triggerControl = true;
            CreateArrows(CloneNumber);
            triggerControl = false;

            PlayerPrefs.SetInt("GoldSave", Gold);
            PlayerPrefs.SetString("GoldText", GoldText.text);
            PlayerPrefs.SetInt("StartingArrowNum", startingArrowNum);
            


            PlayerPrefs.SetInt("Arrowlevelİnt", ArrowLevelint);
            PlayerPrefs.SetString("Arrowlevel", ArrowLevel.text);
            PlayerPrefs.SetInt("ArrowPrizeİnt", ArrowPrizeint);
            PlayerPrefs.SetString("ArrowPrize", ArrowPrize.text);
        }
    }

    public void İncomeLevelİncreasing()
    {
        if (Gold >= IncomePrizeint)
        {
           
            IncomeLevelint++;
            IncomeLevel.text = "Level " + IncomeLevelint.ToString();
            IncomePrizeint = IncomePrizeint * IncomeLevelint;
            IncomePrize.text = IncomePrizeint.ToString();

            PlayerPrefs.SetInt("İncomeLevelint", IncomeLevelint);
            PlayerPrefs.SetInt("İncomePrizeint", IncomePrizeint);
            PlayerPrefs.SetString("İncomeLevel", IncomeLevel.text);
            PlayerPrefs.SetString("İncomePrize", IncomePrize.text);



        }
    }

    public void SaveSystem()
    {
        Gold = PlayerPrefs.GetInt("GoldSave");
        GoldText.text = PlayerPrefs.GetString("GoldText");
        startingArrowNum = PlayerPrefs.GetInt("StartingArrowNum");
        ArrowLevelint = PlayerPrefs.GetInt("Arrowlevelİnt");
        ArrowLevel.text = PlayerPrefs.GetString("Arrowlevel");
        ArrowPrizeint = PlayerPrefs.GetInt("ArrowPrizeİnt");
        ArrowPrize.text = PlayerPrefs.GetString("ArrowPrize");
        IncomeLevelint = PlayerPrefs.GetInt("İncomeLevelint");
        IncomePrizeint = PlayerPrefs.GetInt("İncomePrizeint");
        IncomePrize.text = PlayerPrefs.GetString("İncomePrize");
        IncomeLevel.text = PlayerPrefs.GetString("İncomeLevel");
        

    }

    public void resetButton()
    {

        PlayerPrefs.DeleteAll();
    }




}
