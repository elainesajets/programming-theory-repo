using UnityEngine;

public class Dog : Animal
{
    protected override void Start() { base.Start(); }

    protected override void MakeSound()
    {
        Debug.Log("Woof");
    }

    protected override void OnAnimalClicked()
    {
        SaveData data = SaveSystem.Load();
        var (name, age, details) = data.GetAnimalData("dog");
        var ui = MainGameUIHandler.Instance;

        if (ui == null)
        {
            Debug.LogError("UI handler Instance is null");
            return;
        }

        ui.ToggleInfo(name, age, details);
    }

}
