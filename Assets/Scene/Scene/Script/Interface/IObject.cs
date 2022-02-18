using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObject
{
    //La fonction OnTouchPlayer est appelé à chaque fois que le player touche l'objet
    //Chaque objet décide ensuite de ce qu'il fait quand le joueur le touche

    //OnTouchPlayer Demande en paramètre le component Health du player afin de pouvoir le donner à la potion
    //pour que cette dernière puisse soigner le joueur
    void OnTouchPlayer(Health player);
    
}
