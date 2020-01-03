﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    /// <summary>
    /// this enum stores the characters to be used in the game
    /// </summary>
    public enum Characters
    {
        // for the tank renders
        tankHead = 'X',
        tankWheels = 'O',
        tankWheels1 = '0',
        tankmiddle = '-',

        // for the platform renders
        platforms = 'O',
        holes = '#',

        // for the background renders
        stars = '*',
        empty = ' '

    }
}
