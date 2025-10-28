using UnityEngine;

public class Cat : Animal
{
    protected override void Start() { base.Start(); }

    protected override void MakeSound()
    {
        Debug.Log("Meow");
    }

    protected override void OnAnimalClicked()
    {
        SaveData data = SaveSystem.Load();
        var (name, age, details) = data.GetAnimalData("cat");

        // Call ToggleInfo with the same data you just loaded
        MainGameUIHandler.Instance.ToggleInfo(name, age, details);
    }

}
