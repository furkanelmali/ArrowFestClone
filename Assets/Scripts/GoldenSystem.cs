using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoldenSystem : MonoBehaviour
{
    
    public GameObject Gamelay;
    

    public GamePlay GamePlay;
    

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
            PlayerPrefs.SetInt("GoldSave", GamePlay.Gold);
            PlayerPrefs.SetString("GoldText", GamePlay.GoldText.text);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            //Hitting Man and Getting Golds
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
