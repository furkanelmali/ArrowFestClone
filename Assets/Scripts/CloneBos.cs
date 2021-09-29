using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneBos : MonoBehaviour
{
    public GameObject Gamelay;
    public TextMesh Number;

    public GamePlay GamePlay;
    // Start is called before the first frame update
    void Start()
    {
        Gamelay.GetComponent<GamePlay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {

            GamePlay.CloneBox = Number;
            GamePlay.Tags = this.gameObject.tag;

            GamePlay.triggerControl = true;

        }
    }
}
