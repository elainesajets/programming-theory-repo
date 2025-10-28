using UnityEngine;
using TMPro;

public class MainGameUIHandler : MonoBehaviour
{
    [Header("Animal info")]
    [SerializeField] private GameObject animalInfoPanel;
    public GameObject AnimalInfo => animalInfoPanel;
    [SerializeField] private TextMeshProUGUI animalName;
    [SerializeField] private TextMeshProUGUI animalAge;
    [SerializeField] private TextMeshProUGUI animalDetails;
    [SerializeField] public bool isInfoPanelActive = false;

    public static MainGameUIHandler Instance { get; private set; } // ENCAPSULATION: Available to read, but only the manager can assign itself

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

    private void Start() => animalInfoPanel?.SetActive(false);


    void Update()
    {
        // Only check for clicks if the panel is active
        if (animalInfoPanel != null && animalInfoPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            // Ignore clicks over UI
            if (UnityEngine.EventSystems.EventSystem.current != null &&
                UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
            {
                // If the hit object has no Animal component, hide the panel
                if (hit.collider.GetComponentInParent<Animal>() == null)
                    HideInfoPanel();
            }
            else
            {
                // Clicked empty space
                HideInfoPanel();
            }
        }
    }

    public void HideInfoPanel()
    {
        if (animalInfoPanel != null && animalInfoPanel.activeSelf)
        {
            animalInfoPanel.SetActive(false);
            isInfoPanelActive = false;
        }
    }

    public void UpdateTextFields(string name, int age, string details)
    {
        animalName.text = $"{name}";
        animalAge.text = $"{age} years old";
        animalDetails.text = $"{details}";
    }

    public void ToggleInfo(string name, int age, string details)
    {
        // If panel is open and already showing this animal's data, close it
        if (animalInfoPanel != null && animalInfoPanel.activeSelf &&
            animalName.text == name)
        {
            animalInfoPanel.SetActive(false);
            isInfoPanelActive = false;
        }
        else
        {
            UpdateTextFields(name, age, details);
            animalInfoPanel.SetActive(true);
            isInfoPanelActive = true;
        }
    }

    // This version keeps existing behavior if called without animal data
    public void ToggleInfo()
    {
        if (animalInfoPanel != null && animalInfoPanel.activeSelf)
        {
            animalInfoPanel.SetActive(false);
            isInfoPanelActive = false;
        }
        else
        {
            animalInfoPanel.SetActive(true);
            isInfoPanelActive = true;

        }
    }
}
