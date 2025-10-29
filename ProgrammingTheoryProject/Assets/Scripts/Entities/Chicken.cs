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
        MainGameUIHandler.Instance.ToggleInfo(name, age, details);
    }
}
