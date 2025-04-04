using UnityEngine;

public class CustomInvisibleWall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     BoxCollider wallCollider = gameObject.AddComponent<BoxCollider>();

        wallCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
