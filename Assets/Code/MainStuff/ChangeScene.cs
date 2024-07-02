using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Scenes scene;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        scene = gameManager.levelSelected;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int sceneInt = (int)scene;
            SceneManager.LoadScene(sceneInt);
        }
    }
}
