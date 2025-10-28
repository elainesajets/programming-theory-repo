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

        // Call ToggleInfo with the same data you just loaded
        MainGameUIHandler.Instance.ToggleInfo(name, age, details);
    }

}
