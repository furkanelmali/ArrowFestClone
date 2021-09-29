using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour
{

    public float movementSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float zMovement = transform.localPosition.z + movementSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, zMovement);
    }

   
}
