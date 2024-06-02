namespace RubiksCube.Models
{
    public class Side
    {
        public Cell[] TopRow { get; set; }
        public Cell[] CentreRow { get; set; }
        public Cell[] BottomRow { get; set; }
        public Cell[] FirstColumn => new[] { TopRow[0], CentreRow[0], BottomRow[0] };
        public Cell[] LastColumn => new[] { TopRow[2], CentreRow[2], BottomRow[2] };

        public Side(ConsoleColor sideColour)
        {
            TopRow = new[] { new Cell(sideColour), new Cell(sideColour), new Cell(sideColour) };
            CentreRow = new[] { new Cell(sideColour), new Cell(sideColour), new Cell(sideColour) };
            BottomRow = new[] { new Cell(sideColour), new Cell(sideColour), new Cell(sideColour) };
        }

        public void Display()
        {
            DisplayRow(TopRow);
            DisplayRow(CentreRow);
            DisplayRow(BottomRow);
            Console.ResetColor();
        }

        public void UpdateFirstColumn(Cell[] cells)
        {
            TopRow[0] = cells[0];
            CentreRow[0] = cells[1];
            BottomRow[0] = cells[2];
        }

        public void UpdateLastColumn(Cell[] cells)
        {
            TopRow[2] = cells[0];
            CentreRow[2] = cells[1];
            BottomRow[2] = cells[2];
        }

        public void RotateClockwise()
        {
            var newTopRow = new[] { BottomRow[0], CentreRow[0], TopRow[0] };
            var newCentreRow = new[] { BottomRow[1], CentreRow[1], TopRow[1] };
            var newBottomRow = new[] { BottomRow[2], CentreRow[2], TopRow[2] };

            TopRow = newTopRow;
            CentreRow = newCentreRow;
            BottomRow = newBottomRow;
        }

        public void RotateAntiClockwise()
        {
            var newTopRow = new[] { TopRow[2], CentreRow[2], BottomRow[2] };
            var newCentreRow = new[] { TopRow[1], CentreRow[1], BottomRow[1] };
            var newBottomRow = new[] { TopRow[0], CentreRow[0], BottomRow[0] };

            TopRow = newTopRow;
            CentreRow = newCentreRow;
            BottomRow = newBottomRow;
        }

        private static void DisplayRow(Cell[] row)
        {
            Console.Write("      ");
            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = row[i].Colour;
                Console.Write($"{row[i].Symbol} ");
            }
            Console.WriteLine();
        }

        public Cell[] GetRow(int rowIndex)
        {
            return rowIndex switch
            {
                0 => TopRow,
                1 => CentreRow,
                2 => BottomRow,
                _ => throw new ArgumentOutOfRangeException(nameof(rowIndex))
            };
        }
    }
}