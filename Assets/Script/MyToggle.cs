using UnityEngine;
using UnityEngine.Events;

public class MyToggle : MonoBehaviour, ITouchable
{
    // Je veux ouvrir un �v�nement pour les designers pour qu'ils puissent set la couleur du sprite eux m�me
    public UnityEvent _onToggleOn;
    public UnityEvent _onToggleOff;

    //Je cr�� les event Unity Action pour informer le script GateWith3Toggles quand un toggle est touch�
    //   ----> S'il passe a true, alors je rajoute un toggle touch� dans un compteur
    //   ----> S'il passe a false, alors je le retire
    public event UnityAction OnToggleOn;
    public event UnityAction OnToggleOff;
    public bool IsActive { get; private set; }

    void Start()
    {
        //Check qui permet d'obliger les toggle � �tre � faux au lancement
        if (IsActive)
            IsActive = false;
    }

    public void Touch(int power)
    {
        IsActive = !IsActive;

        //J'utilise un op�rateur ternaire � la place d'un if
        //J'appelle uniquement l'evenement correspondant � l'�tat du Toggle
        var e = IsActive ? OnToggleOn : OnToggleOff;
        e?.Invoke();
    }
}
