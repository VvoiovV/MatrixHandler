namespace Matrix2D
{
    public class Matrix2D: IEquatable<Matrix2D>
    { 
        int a, b, c, d;
        public Matrix2D(int a, int b, int c, int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public Matrix2D(): this(1, 0, 0, 1) 
        {

        }

        public static Matrix2D Id { get; } = new Matrix2D(1,0,0,1);

        public static Matrix2D Zero { get; } = new Matrix2D(0,0,0,0);

        public override string ToString()
        {
            return $"[[{a}, {b}], [{c}, {d}]]";
        }

        public bool Equals(Matrix2D? other)
        {
            if (other == null) 
                return false;

            if (a == other.a && b == other.b && c == other.c && d == other.d) 
                return true;
            else 
                return false;      
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix2D matrix)
                return Equals(matrix);
            
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(a, b, c, d);
        }

        public static bool operator == (Matrix2D a, Matrix2D b)
        {
            return a.Equals(b);
        }
        public static bool operator != (Matrix2D a, Matrix2D b)
        {
            return !(a == b);
        }

        public static Matrix2D operator + (Matrix2D a, Matrix2D b)
        {
            return new Matrix2D(a.a + b.a, a.b + b.b, a.c + b.c, a.d + b.d);
        }
        public static Matrix2D operator - (Matrix2D a, Matrix2D b)
        {
            return new Matrix2D(a.a - b.a, a.b - b.b, a.c - b.c, a.d - b.d);
        }
        public static Matrix2D operator * (Matrix2D a, Matrix2D b)
        {
            return new Matrix2D(
                a.a * b.a + a.b * b.c,
                a.a * b.b + a.b * b.d,
                a.c * b.a + a.d * b.c,
                a.c * b.b + a.d * b.d
                );
        }

        public static Matrix2D operator *(Matrix2D matrix, int k)
        {
            return new Matrix2D(matrix.a * k, matrix.b * k, matrix.c * k, matrix.d * k);
        }

        public static Matrix2D operator *(int k, Matrix2D matrix)
        {
            return matrix * k;
        }

        public static Matrix2D operator -(Matrix2D matrix)
        {
            return -1 * matrix;
        }

        public static Matrix2D Transpose(Matrix2D matrix)
        {
            return new Matrix2D(matrix.a, matrix.c, matrix.b, matrix.d);
        }

        public int Det() 
        {
            return a* d -b * c;
        }

        public static explicit operator int[,](Matrix2D matrix)
        {
            return new int[,] { { matrix.a, matrix.b }, { matrix.c, matrix.d } };
        }

        public static Matrix2D Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new FormatException("teks nie może być pusty lub nullem");

            string[] wiersze = text.Trim('[', ']').Split( "], [" );

            if (wiersze.Length != 2)
                throw new FormatException(" ZŁY format >:( ");

            string[] row1 = wiersze[0].Split(',');
            string[] row2 = wiersze[1].Split(',');

            if (row1.Length != 2 || row2.Length != 2)
                throw new FormatException(" ZŁY format >:( ");

                int a = int.Parse(row1[0].Trim());
                int b = int.Parse(row1[1].Trim());
                int c = int.Parse(row2[0].Trim());
                int d = int.Parse(row2[1].Trim());

            return new Matrix2D(a, b, c, d);
        }






    }
}
