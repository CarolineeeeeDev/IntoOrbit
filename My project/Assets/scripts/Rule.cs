using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rule: MonoBehaviour
{

    [SerializeField] private Button startButton;
    private void Awake()
    {
        startButton.Select();
        //lambda
        startButton.onClick.AddListener(() => {
            //click
            Loader.Load(Loader.Scene.GameScene);
        });

    

        Time.timeScale = 1f;
    }
}

