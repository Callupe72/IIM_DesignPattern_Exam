using UnityEngine;

public class GateWith3Toggles : MonoBehaviour
{
    [SerializeField] MyToggle[] toggleNeeded;
    int currentToggleOn = 0;

    void Start()
    {
        //Je m'inscris sur tous les toggles appartenant à ToggleNeeded
        foreach (MyToggle toggle in toggleNeeded)
        {
            toggle.OnToggleOn += Increment;
            toggle.OnToggleOff += Decrement;
        }
    }

    void OnDestroy()
    {
        //Je me désinscris sur tous les toggles appartenant à ToggleNeeded
        foreach (MyToggle toggle in toggleNeeded)
        {
            toggle.OnToggleOn -= Increment;
            toggle.OnToggleOff -= Decrement;
        }
    }

    void Increment()
    {
        currentToggleOn++;
        if (currentToggleOn == toggleNeeded.Length)
            OpenDoor();
    }
    void Decrement()
    {
        currentToggleOn--;
    }
    void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
