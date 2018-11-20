using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public abstract class Matrix<T>
    {
        protected int size;
        protected T[,] array;

        public const int defaultSize = 4;

        public abstract int Size { get; set; }
        public abstract T[,] Array { get; set; }

        public Matrix()
        {
            Size = 4;
            Array = new T[defaultSize, defaultSize];
        }

        public Matrix(int size)
        {
            Size = size;
            Array = new T[size, size];
        }

        public Matrix(T[,] matrix)
        {
            Size = matrix.Length;

            Array = new T[Size, Size];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    Array[i, j] = matrix[i, j];
                }
            }
        }
    }

    public class SymmetricMatrix<T> : Matrix<T>
    {
        public override int Size
        {
            get => size;
            set
            {
                if (array == null)
                    throw new InvalidOperationException();
                size = array.Length;
            }

        }
        public override T[,] Array
        {
            get
            {
                if (array == null)
                    throw new InvalidOperationException();

                return array;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                for (int i = 0; i < value.Length; i++)
                {
                    for (int j = i; j < value.Length; j++)
                    {
                        if (i == j) continue;

                        if (Object.Equals(value[i, j], value[j, i]))
                            continue;

                        throw new Exception("Matrix is unsymmetric.");
                    }
                }

            }
        }

        SymmetricMatrix() : base() { }
        SymmetricMatrix(int size) : base(size) { }
        SymmetricMatrix(T[,] matrix) : base(matrix) { }


    }

    public class DiagonalMatrix<T> : Matrix<T>
    {
        public override int Size
        {
            get => size;
            set
            {
                if (array == null)
                    throw new InvalidOperationException();
                size = array.Length;
            }

        }
        public override T[,] Array
        {
            get
            {
                if (array == null)
                    throw new InvalidOperationException();

                return array;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                for (int i = 0; i < value.Length; i++)
                {
                    for (int j = i; j < value.Length; j++)
                    {
                        if (i == j)
                            continue;

                        if (object.Equals(value[i, j], default(T)) && object.Equals(value[j, i], default(T)))
                            continue;

                        throw new Exception("Matrix is undiagonal.");
                    }
                }

            }
        }

        public DiagonalMatrix() : base() { }
        public DiagonalMatrix(int size) : base(size) { }
        public DiagonalMatrix(T[,] matrix) : base(matrix) { }
    }

    public class SquareMatrix<T> : Matrix<T>
    {
        public override int Size
        {
            get
            {
                if (Array == null)
                    throw new ArgumentNullException();
                return size;
            }
            set
            {

            }
        }
        public override T[,] Array { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
