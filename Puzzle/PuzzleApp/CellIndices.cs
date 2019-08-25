

namespace PuzzleApp
{
    public struct CellIndices 
    {
        public int column;
        public int row;


        public static bool operator ==(CellIndices Lhs, CellIndices Rhs)
        {
            return EqualsImpl(ref Lhs, ref Rhs);

        }

        public static bool operator !=(CellIndices Lhs, CellIndices Rhs)
        {
            return !EqualsImpl(ref Lhs, ref Rhs);

        }

        private static bool EqualsImpl(ref CellIndices Lhs, ref CellIndices Rhs)
        {
            return Lhs.column == Rhs.column && Lhs.row == Rhs.row;

        }



        public CellIndices(int column, int row)
        {
            this.column = column;
            this.row = row;

        }

        public bool Equals(CellIndices other)
        {
            return EqualsImpl(ref this, ref other);

        }

        public override bool Equals(object obj)
        {
            return obj is CellIndices other && Equals(other);

        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (column * 397) ^ row;
            }

        }


    }
    

}