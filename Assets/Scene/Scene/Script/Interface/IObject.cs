using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObject
{
    //La fonction OnTouchPlayer est appel� � chaque fois que le player touche l'objet
    //Chaque objet d�cide ensuite de ce qu'il fait quand le joueur le touche

    //OnTouchPlayer Demande en param�tre le component Health du player afin de pouvoir le donner � la potion
    //pour que cette derni�re puisse soigner le joueur
    void OnTouchPlayer(Health player);
    
}
