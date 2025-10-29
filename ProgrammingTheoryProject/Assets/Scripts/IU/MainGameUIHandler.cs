using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainGameUIHandler : MonoBehaviour
{
    [Header("Animal info")]
    [SerializeField] private GameObject animalInfoPanel;
    public GameObject AnimalInfo => animalInfoPanel; // Encapsulation
    [SerializeField] TextMeshProUGUI animalName;
    [SerializeField] TextMeshProUGUI animalAge;
    [SerializeField] TextMeshProUGUI animalDetails;
    public Button backButton;

    private static MainGameUIHandler _instance;
    public static MainGameUIHandler Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindFirstObjectByType<MainGameUIHandler>(FindObjectsInactive.Include);
            return _instance;
        }
        private set => _instance = value;
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);  // persist across scenes

        if (animalInfoPanel != null)
            animalInfoPanel.SetActive(false);
    }

    void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    void ShowInfoPanel() //Abstraction
    {
        if (animalInfoPanel == null)
        {
            Debug.LogWarning("[UI] Info panel reference lost");
        }

        animalInfoPanel.SetActive(true);
    }

    void HideInfoPanel() //Abstraction
    {
        if (animalInfoPanel == null) return;
        animalInfoPanel.SetActive(false);
    }

    public void HideInfoPanelIfActive()
    {
        if (animalInfoPanel != null && animalInfoPanel.activeSelf)
            HideInfoPanel();
    }

    void UpdateTextFields(string name, int age, string details)
    {
        if (animalName == null || animalAge == null || animalDetails == null)
        {
            Debug.LogWarning("[UI] Text references missing, cannot update fields.");
            return;
        }

        animalName.text = $"{name}";
        animalAge.text = $"{age} years old";
        animalDetails.text = $"{details}";
    }

    public void ToggleInfo(string name, int age, string details)
    {
        // If panel is open and already showing this animal's data, close it
        if (animalInfoPanel != null && animalInfoPanel.activeSelf &&
            animalName.text == name) HideInfoPanel();
        else
        {
            UpdateTextFields(name, age, details);
            ShowInfoPanel();
        }
    }

    public void EnableBackButton()
    {
        var btn = backButton.gameObject;
        if (btn.activeSelf) return;
        else btn.SetActive(true);
    }
}
