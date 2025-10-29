using UnityEngine;

public class Chicken : Animal
{
    protected override void Start() { base.Start(); }

    protected override void MakeSound()
    {
        Debug.Log("Chirp");
    }

    protected override void OnAnimalClicked()
    {
        SaveData data = SaveSystem.Load();
        var (name, age, details) = data.GetAnimalData("chicken");
        var ui = MainGameUIHandler.Instance;

        if (ui == null)
        {
            Debug.LogError("UI handler Instance is null");
            return;
        }

        ui.ToggleInfo(name, age, details);
    }
}
