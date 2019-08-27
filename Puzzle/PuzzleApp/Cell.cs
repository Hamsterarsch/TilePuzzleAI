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

        public override int GetHashCode()
        {
            return correctPosition.GetHashCode();

        }

        public static bool operator ==(Cell Lhs, Cell Rhs)
        {
            if (object.ReferenceEquals(Lhs, null))
            {
                return object.ReferenceEquals(Rhs, null);
            }

            if (object.ReferenceEquals(Rhs, null))
            {
                return object.ReferenceEquals(Lhs, null);
            }

            return Lhs.correctPosition == Rhs.correctPosition;

        }

        public static bool operator !=(Cell Lhs, Cell Rhs)
        {
            return !(Lhs == Rhs);

        }


    }


}