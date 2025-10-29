using UnityEngine;
using TMPro;

public class MainGameUIHandler : MonoBehaviour
{
    [Header("Animal info")]
    [SerializeField] private GameObject animalInfoPanel;
    public GameObject AnimalInfo => animalInfoPanel; // Encapsulation
    [SerializeField] private TextMeshProUGUI animalName;
    [SerializeField] private TextMeshProUGUI animalAge;
    [SerializeField] private TextMeshProUGUI animalDetails;
    [SerializeField] public bool isInfoPanelActive = false;

    public static MainGameUIHandler Instance { get; private set; } // Encapsulation

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (animalInfoPanel != null) animalInfoPanel.SetActive(false);
    }

    void Update()
    {
        if (animalInfoPanel != null && animalInfoPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            // Ignore clicks over UI
            if (UnityEngine.EventSystems.EventSystem.current != null &&
                UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Animal")) return;
                else HideInfoPanel();
            }
            else HideInfoPanel();
        }
    }

    void ShowInfoPanel() //Abstraction
    {
        animalInfoPanel.SetActive(true);
        isInfoPanelActive = true;

    }

    void HideInfoPanel() //Abstraction
    {
        animalInfoPanel.SetActive(false);
        isInfoPanelActive = false;
    }

    void UpdateTextFields(string name, int age, string details)
    {
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

    // Method overloading. This version keeps existing behavior if called without animal data
    public void ToggleInfo()
    {
        if (animalInfoPanel != null && animalInfoPanel.activeSelf) HideInfoPanel();
        else ShowInfoPanel();
    }
}
