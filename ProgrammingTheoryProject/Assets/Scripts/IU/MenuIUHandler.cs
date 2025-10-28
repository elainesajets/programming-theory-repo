using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuIUHandler : MonoBehaviour
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
