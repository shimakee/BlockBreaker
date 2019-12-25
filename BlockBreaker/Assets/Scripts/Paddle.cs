using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    
    [SerializeField] float CameraUnitWidth= 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        float xPosition = Mathf.Clamp(Input.mousePosition.x / Screen.width * CameraUnitWidth, minX, maxX);
        
            Vector2 vector = new Vector2(xPosition, 0);

        transform.position = vector;
    }
    

}
