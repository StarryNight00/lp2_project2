using System;

namespace lp2_project2
{
    /// <summary>
    /// this class allows us to render on the console by using an array of 
    /// chars re-used code from teachers solution from 
    /// https://github.com/VideojogosLusofona/lp2_2019_aulas.git 
    /// (Aula11, Exercise 3).
    /// </summary>
    class DoubleBuffer2D<T>
    {
        /// <summary>
        /// getting the current array being printed and preparing the next
        /// </summary>
        private T[,] current;
        private T[,] next;

        /// <summary>
        /// getting the size of the maps
        /// </summary>
        public int XDim => next.GetLength(0);
        public int YDim => next.GetLength(1);

        /// <summary>
        /// constructor to get both arrays and set their values
        /// </summary>
        /// <param name="x">x dimension of array</param>
        /// <param name="y">y dimension of array</param>
        /// <returns></returns>
        public T this[int x, int y]
        {
            get => current[x, y];
            set => next[x, y] = value;
        }

        /// <summary>
        /// clears the array to render new and save memory
        /// </summary>
        public void Clear()
        {
            Array.Clear(next, 0, XDim * YDim);
        }

        public DoubleBuffer2D(int x, int y)
        {
            current = new T[x, y];
            next = new T[x, y];
            Clear();
        }

        /// <summary>
        /// swaps between arrays to print the new one and discard last one
        /// </summary>
        public void Swap()
        {
            T[,] aux = current;
            current = next;
            next = aux;
            Clear();
        }
    }
}
