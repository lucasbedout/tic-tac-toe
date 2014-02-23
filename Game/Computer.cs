using System;

namespace Game
{
    public class Computer
    {
        private int _score { get; set; }
        private bool _winOnNextRound { get; set; }

        public Computer()
        {
            _score = 0;
            _winOnNextRound = false;
        }

        public void Play(Table tab, int round)
        {
            var random = new Random();
            int x, y;
            bool played = false;

            // Premier tour, on joue au milieu ou au hasard autour du milieu
            if (round == 0 )
            {
                if (tab.GameTab[1, 1] == 0)
                {
                    tab.GameTab[1, 1] = 2;
                    played = true;
                }
                else if (tab.GameTab[1, 1] == 1)
                {
                    do
                    {
                        x = random.Next(0, 3);
                        y = random.Next(0, 3);
                    } while (x == 1 || y == 1);

                    tab.GameTab[x, y] = 2;
                    played = true;
                }
            }

            if (!played)
            {
                // Sinon on commence par vérifier s'il y a une menace ou non et si on peut gagner
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (tab.GameTab[i, j] != 0 && !played)
                            {
                                // Case au milieu en haut ou en bas
                                if (j == 1 && (i == 0 || i == 2))
                                {
                                    if (tab.GameTab[i, j - 1] == tab.GameTab[i, j] && tab.GameTab[i, j + 1] == 0)
                                    {
                                        tab.GameTab[i, j + 1] = 2;
                                        played = true;
                                    }
                                    else if (tab.GameTab[i, j + 1] == tab.GameTab[i, j] && tab.GameTab[i, j - 1] == 0)
                                    {
                                        tab.GameTab[i, j - 1] = 2;
                                        played = true;
                                    }
                                }
                            
                                    // Case au milieu à gauche ou à droite
                                else if (i == 1 && (j == 0 || j == 2))
                                {
                                    if (tab.GameTab[i - 1, j] == tab.GameTab[i, j] && tab.GameTab[i + 1, j] == 0)
                                    {
                                        tab.GameTab[i + 1, j] = 2;
                                        played = true;
                                    }
                                    else if (tab.GameTab[i + 1, j] == tab.GameTab[i, j] && tab.GameTab[i - 1, j] == 0)
                                    {
                                        tab.GameTab[i - 1, j] = 2;
                                        played = true;
                                    }
                                }

                                // Case au milieu du jeu
                                else if (i == 1 && j == 1)
                                {
                                    // On check les lignes horizontales
                                    if (tab.GameTab[i - 1, j] == tab.GameTab[i, j] && tab.GameTab[i + 1, j] == 0)
                                    {
                                        tab.GameTab[i + 1, j] = 2;
                                        played = true;
                                    }
                                    else if (tab.GameTab[i + 1, j] == tab.GameTab[i, j] && tab.GameTab[i - 1, j] == 0)
                                    {
                                        tab.GameTab[i - 1, j] = 2;
                                        played = true;
                                    }
                                    else if (tab.GameTab[i, j - 1] == tab.GameTab[i, j] && tab.GameTab[i, j + 1] == 0)
                                    {
                                        tab.GameTab[i, j - 1] = 2;
                                        played = true;
                                    }
                                    else if (tab.GameTab[i, j + 1] == tab.GameTab[i, j] && tab.GameTab[i, j - 1] == 0)
                                    {
                                        tab.GameTab[i, j - 1] = 2;
                                        played = true;
                                    }
                                    else
                                    {
                                        // On check les diagonales
                                        if (tab.GameTab[i - 1, j + 1] == tab.GameTab[i, j] && tab.GameTab[i + 1, j - 1] == 0)
                                        {
                                            tab.GameTab[i + 1, j - 1] = 2;
                                            played = true;
                                        }
                                        else if (tab.GameTab[i + 1, j + 1] == tab.GameTab[i, j] && tab.GameTab[i - 1, j - 1] == 0)
                                        {
                                            tab.GameTab[i - 1, j - 1] = 2;
                                            played = true;
                                        }
                                        else if (tab.GameTab[i + 1, j - 1] == tab.GameTab[i, j] && tab.GameTab[i - 1, j + 1] == 0)
                                        {
                                            tab.GameTab[i - 1, j + 1] = 2;
                                            played = true;
                                        }
                                        else if (tab.GameTab[i - 1, j - 1] == tab.GameTab[i, j] && tab.GameTab[i + 1, j + 1] == 0)
                                        {
                                            tab.GameTab[i + 1, j + 1] = 2;
                                            played = true;
                                        }
                                    }
                                }
                            }
                            else if (tab.GameTab[i, j] == 0 && !played)
                            {
                                if (j == 1 && (i == 0 || i == 2))
                                {
                                    if (tab.GameTab[i, j - 1] == 1 && tab.GameTab[i, j + 1] == 1)
                                    {
                                        tab.GameTab[i, j] = 2;
                                        played = true;
                                    }
                                    else if (tab.GameTab[i, j - 1] == 2 && tab.GameTab[i, j + 1] == 2)
                                    {
                                        tab.GameTab[i, j] = 2;
                                        played = true;
                                    }

                                }
                                else if (i == 1 && (j == 0 || j == 2))
                                {
                                    if (tab.GameTab[i - 1, j] == 1 && tab.GameTab[i + 1, j] == 1)
                                    {
                                        tab.GameTab[i, j] = 2;
                                        played = true;
                                    }
                                    else if (tab.GameTab[i- 1, j] == 2 && tab.GameTab[i + 1, j] == 2)
                                    {
                                        tab.GameTab[i, j] = 2;
                                        played = true;
                                    }
                                }
                            }
                        }
                    }

                    // Si l'adversaire est mauvais, on se retrouve en position de gagner dés le deuxième tour
                    if (_winOnNextRound)
                    {
                        if (tab.GameTab[0, 1] == 2 || tab.GameTab[1, 0] == 2)
                        {
                            tab.GameTab[0, 0] = 2;
                            played = true;
                        }
                        else if (tab.GameTab[1, 2] == 2 || tab.GameTab[2, 1] == 2)
                        {
                            tab.GameTab[2, 2] = 2;
                            played = true;
                        }
                        _winOnNextRound = false;
                    }

                    if (!played)
                    {
                        // Si on a pas joué avant on joue pour nous
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (!played && (tab.GameTab[i, j] == 2 || tab.GameTab[i, j] == 0))
                                {
                                    if (j == 1 && (i == 0 || i == 2))
                                    {
                                        if (tab.GameTab[i, j - 1] == 0 && tab.GameTab[i, j + 1] == 0)
                                        {
                                            // On a une case potentielle à jouer, sur une ligne vierge
                                            // On vérifie qu'on ne tend pas une perche à l'adversaire (case opposée entre un vide et un x)
                                            switch (i)
                                            {
                                                case 0:
                                                    if (tab.GameTab[i + 2, j + 1] == 0 && tab.GameTab[i + 2, j - 1] == 0)
                                                    {
                                                        // Si les deux et la case courante valent 0 on joue
                                                        if (tab.GameTab[i, j] == 0)
                                                        {
                                                            tab.GameTab[i, j] = 2;
                                                            played = true;
                                                            _winOnNextRound = true;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    if (tab.GameTab[i - 2, j + 1] == 0 && tab.GameTab[i - 2, j - 1] == 0)
                                                    {
                                                        // Si les deux et la case courante valent 0 on joue
                                                        if (tab.GameTab[i, j] == 0)
                                                        {
                                                            tab.GameTab[i, j] = 2;
                                                            played = true;
                                                            _winOnNextRound = true;
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                    else if (i == 1 && (j == 0 || j == 2))
                                    {
                                        if (tab.GameTab[i - 1, j] == 0 && tab.GameTab[i + 1, j] == 0)
                                        {
                                            // Même chose que précédemment, dans l'autre sens
                                            switch (j)
                                            {
                                                case 0:
                                                    if (tab.GameTab[i + 1, j + 2] == 0 && tab.GameTab[i - 1, j + 2] == 0)
                                                    {
                                                        // Si les deux et la case courante valent 0 on joue
                                                        if (tab.GameTab[i, j] == 0)
                                                        {
                                                            tab.GameTab[i, j] = 2;
                                                            played = true;
                                                            _winOnNextRound = true;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    if (tab.GameTab[i - 1, j - 2] == 0 && tab.GameTab[i + 1, j - 2] == 0)
                                                    {
                                                        // Si les deux et la case courante valent 0 on joue
                                                        if (tab.GameTab[i, j] == 0)
                                                        {
                                                            tab.GameTab[i, j] = 2;
                                                            played = true;
                                                            _winOnNextRound = true;
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (!played)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    // Pas de place vide, on ne peut pas anticiper donc on joue comme on peut
                                    // On joue le bout d'une ligne à en face d'un pion adverse si possible
                                    if (!played)
                                    {
                                        switch (i)
                                        {
                                            case 0:
                                                if (j == 0)
                                                {
                                                    if (tab.GameTab[i, j + 2] == 0)
                                                    {
                                                        tab.GameTab[i, j + 2] = 2;
                                                        played = true;
                                                    }
                                                    else if (tab.GameTab[i + 2, j] == 0)
                                                    {
                                                        tab.GameTab[i + 2, j] = 2;
                                                        played = true;
                                                    }
                                                }
                                                else if (j == 2)
                                                {
                                                    if (tab.GameTab[i, j - 2] == 0)
                                                    {
                                                        tab.GameTab[i, j - 2] = 2;
                                                        played = true;
                                                    }
                                                    else if (tab.GameTab[i + 2, j] == 0)
                                                    {
                                                        tab.GameTab[i + 2, j] = 2;
                                                        played = true;
                                                    }
                                                }
                                                break;
                                            case 2:
                                                if (j == 0)
                                                {
                                                    if (tab.GameTab[i, j + 2] == 0)
                                                    {
                                                        tab.GameTab[i, j + 2] = 2;
                                                        played = true;
                                                    }
                                                    else if (tab.GameTab[i - 2, j] == 0)
                                                    {
                                                        tab.GameTab[i - 2, j] = 2;
                                                        played = true;
                                                    }
                                                }
                                                else if (j == 2)
                                                {
                                                    if (tab.GameTab[i, j - 2] == 0)
                                                    {
                                                        tab.GameTab[i, j - 2] = 2;
                                                        played = true;
                                                    }
                                                    else if (tab.GameTab[i - 2, j] == 0)
                                                    {
                                                        tab.GameTab[i - 2, j] = 2;
                                                        played = true;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }

                        if (!played)
                        {
                            // Si plus aucune solution
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    // On joue dans la case qu'il reste 
                                    if (tab.GameTab[i, j] == 0)
                                    {
                                        tab.GameTab[i, j] = 2;
                                        played = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

