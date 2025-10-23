using UnityEngine;

public class MenuIUHandler : MonoBehaviour
{
    public void OnExitClick()
    {
        GameManager.Instance.Exit(); // ABSTRACTION
    }
}
