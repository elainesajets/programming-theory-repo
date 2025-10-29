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
        MainGameUIHandler.Instance.ToggleInfo(name, age, details);
    }

}
