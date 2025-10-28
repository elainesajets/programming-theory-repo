using UnityEngine;

public class Cat : Animal
{
    protected override void Start() { base.Start(); }

    protected override void MakeSound()
    {
        Debug.Log("Meow");
    }
}
