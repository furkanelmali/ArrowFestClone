using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoldenSystem : MonoBehaviour
{
    
    public GameObject Gamelay;
    

    public GamePlay GamePlay;
    public int ArrowNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        Gamelay.GetComponent<GamePlay>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow" || other.gameObject.tag == "ArrowClone")
        {
            
            GamePlay.Gold = GamePlay.Gold + GamePlay.IncomeLevelint;           
            GamePlay.GoldText.text = GamePlay.Gold.ToString();
            GamePlay.arrowCleanercheck = true;
            GamePlay.ArrowCleaner();

            Debug.Log(GamePlay.ArrowBox.transform.childCount);
            PlayerPrefs.SetInt("GoldSave", GamePlay.Gold);
            PlayerPrefs.SetString("GoldText", GamePlay.GoldText.text);
            if(other.gameObject.tag == "ArrowClone")
            {
                Destroy(other.gameObject);
            }

            
            Destroy(this.gameObject);
            //Hitting Man and Getting Golds
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
