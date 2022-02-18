using UnityEngine;
using UnityEngine.Events;

public class MyToggle : MonoBehaviour, ITouchable
{
    // Je veux ouvrir un évènement pour les designers pour qu'ils puissent set la couleur du sprite eux même
    public UnityEvent _onToggleOn;
    public UnityEvent _onToggleOff;

    //Je créé les event Unity Action pour informer le script GateWith3Toggles quand un toggle est touché
    //   ----> S'il passe a true, alors je rajoute un toggle touché dans un compteur
    //   ----> S'il passe a false, alors je le retire
    public event UnityAction OnToggleOn;
    public event UnityAction OnToggleOff;
    public bool IsActive { get; private set; }

    void Start()
    {
        //Check qui permet d'obliger les toggle à être à faux au lancement
        if (IsActive)
            IsActive = false;
    }

    public void Touch(int power)
    {
        IsActive = !IsActive;

        //J'utilise un opérateur ternaire à la place d'un if
        //J'appelle uniquement l'evenement correspondant à l'état du Toggle
        var e = IsActive ? OnToggleOn : OnToggleOff;
        e?.Invoke();
    }
}
