using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (other.gameObject.tag == "Arrow")
        {

            GamePlay.Gold++;
            //Hitting Man and Getting Golds
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
