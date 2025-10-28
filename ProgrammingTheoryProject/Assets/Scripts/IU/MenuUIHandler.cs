using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void OnStartClick()
    {
        string playerName = nameInput.text;
        SaveSystem.SaveName(playerName);
        SceneManager.LoadScene("MainGame");

    }

    public void OnExitClick()
    {
        GameManager.Instance.Exit(); // Abstraction
    }
}
