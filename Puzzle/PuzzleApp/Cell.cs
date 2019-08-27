namespace PuzzleApp
{
    public class Cell
    {
        public CellIndices correctPosition;


        public Cell(CellIndices correctPosition)
        {
            this.correctPosition = correctPosition;

        }

        public Cell(Cell other)
        {
            this.correctPosition = other.correctPosition;

        }



        public static bool operator ==(Cell Lhs, Cell Rhs)
        {
            if (ReferenceEquals(Lhs, null))
            {
                return ReferenceEquals(Rhs, null);
            }

            if (ReferenceEquals(Rhs, null))
            {
                return ReferenceEquals(Lhs, null);
            }

            return Lhs.correctPosition == Rhs.correctPosition;

        }

        public static bool operator !=(Cell Lhs, Cell Rhs)
        {
            return !(Lhs == Rhs);

        }



        public override int GetHashCode()
        {
            return correctPosition.GetHashCode();

        }


    }


}