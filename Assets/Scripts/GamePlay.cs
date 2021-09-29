using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject ArrowBox;

    public TextMesh CloneBox;
    public string Tags;

    public int currentArrow;
    public int cloneBoxİnt;
    public int CloneNumber;
    public int DestroyNumber;

    public int Gold;

    public bool triggerControl;
       
  
    // Start is called before the first frame update
    void Start()
    {
        currentArrow = 1;

        
    

    }

    // Update is called once per frame
    void Update()
    {
        int.TryParse(CloneBox.text, out cloneBoxİnt);
        if (triggerControl)
        {
            Calculations();
            
            CreateArrows(CloneNumber);  
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

        
     
    } //Calculations For Cloning-Destroying


    public void CreateArrows(int Arrows) 
    {
        if (triggerControl)
        {
            for (int i = 0; i < Arrows; i++)
            {
                float clone = i * 0.1f;

                GameObject ArrowClone = Instantiate(Arrow, new Vector3(Arrow.transform.position.x + clone,
                                                                       Arrow.transform.position.y + clone,
                                                                       Arrow.transform.position.z + clone), Arrow.transform.rotation);
                ArrowClone.transform.parent = ArrowBox.transform;
                ArrowClone.name = "ArrowClone" + i;
                ArrowClone.gameObject.tag = "ArrowClone";


                triggerControl = false;
            }

        }
       
    
    } //Creating Arrows

    public void DestroyingArrows()
    {


    }//Destroying Arrows

   

   
}
