﻿using System.Collections.Generic;

namespace Reversi.Extensions
{
    public class CircularList<T> : List<T>
    {
        public T Next(int i)
        {
            i++;
            if (i == this.Count)
            {
                i = 0;
            }
            return this[i];
        }
    }
}