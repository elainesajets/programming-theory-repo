// Abstraction + Inheritance
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    //Encapsulation
    [SerializeField] private string _name;
    // [SerializeField] protected AudioSource audioSource;
    // [SerializeField] protected AudioClip soundClip;

    protected string Name => _name;

    protected Animal(string name) { _name = name; }

    //Polymorphism
    protected abstract void MakeSound();
    protected virtual void Interact() { MakeSound(); }

    protected void Move()
    {

    }
}
