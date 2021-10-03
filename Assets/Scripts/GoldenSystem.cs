using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoldenSystem : MonoBehaviour
{
    
    
    

    public GamePlay GamePlay;
    public int ArrowNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        GamePlay.GetComponent<GamePlay>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "people")
        {
            
            GamePlay.Gold = GamePlay.Gold + GamePlay.IncomeLevelint;           
            GamePlay.GoldText.text = GamePlay.Gold.ToString();
            GamePlay.arrowCleanercheck = true;
            GamePlay.ArrowCleaner();

            Debug.Log(GamePlay.ArrowBox.transform.childCount);
            PlayerPrefs.SetInt("GoldSave", GamePlay.Gold);
            PlayerPrefs.SetString("GoldText", GamePlay.GoldText.text);
            Destroy(other.gameObject);
            if (this.gameObject.tag == "ArrowClone")
            {
                Destroy(this.gameObject);
            }
            
           
            
            


            //Hitting Man and Getting Golds
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
