namespace PuzzleApp
{
    public class Cell
    {
        public CellIndices correctPosition;


        public Cell(CellIndices correctPosition)
        {
            this.correctPosition = correctPosition;

        }

        public override int GetHashCode()
        {
            return correctPosition.GetHashCode();

        }

        public static bool operator ==(Cell Lhs, Cell Rhs)
        {
            return Lhs.correctPosition == Rhs.correctPosition;

        }

        public static bool operator !=(Cell Lhs, Cell Rhs)
        {
            return !(Lhs == Rhs);

        }


    }


}