using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    

    private void Start()
    {
    
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 10);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * 10);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 5, 0, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, -5, 0, Space.Self);
        }
    }
    
}
