using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceSceneDetector : MonoBehaviour
{

    public string nextLevel;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
