using UnityEngine;
using UnityEngine.SceneManagement;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // ENCAPSULATION: Available to read, but only the manager can assign itself

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        CreateSaveFile();

    }

    //Method for hard coded save file
    void CreateSaveFile()
    {
        SaveData data = new SaveData();

        data.catName = "Mochi";
        data.catAge = 3;
        data.catDetails = "Loves naps and knocking things off shelves.";

        data.dogName = "Choco";
        data.dogAge = 5;
        data.dogDetails = "Always hungry.";

        data.chickenName = "Birdie";
        data.chickenAge = 7;
        data.chickenDetails = "Dreams of flying.";

        SaveSystem.Save(data);

        Debug.Log("Animal data saved!");
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    //Abstraciton
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}