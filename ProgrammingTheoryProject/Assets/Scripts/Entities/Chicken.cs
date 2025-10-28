using UnityEngine;

public class Chicken : Animal
{
    protected override void Start() { base.Start(); }

    protected override void MakeSound()
    {
        Debug.Log("Chirp");
    }
}
