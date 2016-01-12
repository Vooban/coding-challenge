Fonctionnalité: Obtenir des suggestions de ville

Scénario: Un seul résultat lorsque le nom exact est entré
    Quand je visite la page de recherche
    Et j'entre Amos dans la boite de recherche
    Alors je devrais voir un résultat dans la grille
        | Nom              | 
        | Amos, QC, Canada | 

Scénario: Un seul résultat lorsqu'un nom partiel est entré
    Étant donné que je suis à la position géographique 43.70011, -79.4163
    Quand je visite la page de recherche    
    Et j'entre London dans la boite de recherche
    Alors je devrais voir les résultats suivants dans la grille
        | Nom                  |
        | London, ON, Canada   |
        | London, OH, USA      |
        | London, KY, USA      |
        | Londontowne, MD, USA |

Scénario: Effacer les résultats lorsqu'aucun nom n'est entré
    Quand je visite la page de recherche
    Et j'entre Amos dans la boite de recherche
    Et j'efface le contenu de la boite de recherche
    Alors je devrais voir les résultats suivants dans la grille
        | Nom                  |