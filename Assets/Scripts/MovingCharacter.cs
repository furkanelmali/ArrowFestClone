using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour
{

    public float movementSpeed;
    public GameObject Gamelay;
    public GamePlay GamePlay;
    
    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        Gamelay.GetComponent<GamePlay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.touchcontrol)
        {
            float zMovement = transform.localPosition.z + movementSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, zMovement);
        }
      
    }

   
}
