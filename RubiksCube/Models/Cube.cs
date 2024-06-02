using RubiksCube.Enums;

namespace RubiksCube.Models
{
    public class Cube
    {
        private readonly Dictionary<FacingDirection, Side> SidesLookup;

        public Cube()
        {
            SidesLookup = new Dictionary<FacingDirection, Side>();
            ConstructCube();
        }

        public void Restart()
        {
            SidesLookup.Clear();
            ConstructCube();
            DisplaySide(FacingDirection.Front);
        }

        public void DisplaySide(FacingDirection facingDirection)
        {
            SidesLookup[facingDirection].Display();
        }

        public void Execute(Command command)
        {
            switch (command)
            {
                case Command.FrontClockwise:
                    RotateFrontClockwise();
                    break;
                case Command.RightAntiClockwise:
                    RotateRightAntiClockwise();
                    break;
                case Command.UpClockwise:
                    RotateUpClockwise();
                    break;
                case Command.BackAntiClockwise:
                    RotateBackAntiClockwise();
                    break;
                case Command.LeftClockwise:
                    RotateLeftClockwise();
                    break;
                case Command.DownAntiClockwise:
                    RotateDownAntiClockwise();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(command));
            }
        }

        public void Explode()
        {
            Side[] SidesToDisplayInLine = [SidesLookup[FacingDirection.Left], SidesLookup[FacingDirection.Front], SidesLookup[FacingDirection.Right], SidesLookup[FacingDirection.Back]];

            SidesLookup[FacingDirection.Top].Display();
            DisplayMultipleSides(SidesToDisplayInLine);
            SidesLookup[FacingDirection.Bottom].Display();
        }

        /// <summary>
        /// This method was created for testing purpose.
        /// </summary>
        public Side GetSide(FacingDirection facingDirection)
        {
            return SidesLookup[facingDirection];
        }

        private void RotateFrontClockwise()
        {
            var top = SidesLookup[FacingDirection.Top];
            var right = SidesLookup[FacingDirection.Right];
            var bottom = SidesLookup[FacingDirection.Bottom];
            var left = SidesLookup[FacingDirection.Left];

            var leftLastColumn = left.LastColumn.Reverse().ToArray();
            var rightFirstColumn = right.FirstColumn.Reverse().ToArray();

            right.UpdateFirstColumn(top.BottomRow);
            left.UpdateLastColumn(bottom.TopRow);
            bottom.TopRow = rightFirstColumn;
            top.BottomRow = leftLastColumn;

            SidesLookup[FacingDirection.Front].RotateClockwise();
        }

        private void RotateBackAntiClockwise()
        {
            var top = SidesLookup[FacingDirection.Top];
            var right = SidesLookup[FacingDirection.Right];
            var bottom = SidesLookup[FacingDirection.Bottom];
            var left = SidesLookup[FacingDirection.Left];

            var leftFirstColumn = left.FirstColumn.Reverse().ToArray();
            var rightLastColumn = right.LastColumn.Reverse().ToArray();
            var newBottomRow = bottom.BottomRow;

            right.UpdateLastColumn(top.TopRow);
            bottom.BottomRow = rightLastColumn;
            left.UpdateFirstColumn(newBottomRow);
            top.TopRow = leftFirstColumn;

            SidesLookup[FacingDirection.Back].RotateAntiClockwise();
        }

        private void RotateLeftClockwise()
        {
            var top = SidesLookup[FacingDirection.Top];
            var front = SidesLookup[FacingDirection.Front];
            var bottom = SidesLookup[FacingDirection.Bottom];
            var back = SidesLookup[FacingDirection.Back];

            var topFirstColumn = top.FirstColumn;
            var frontFirstColumn = front.FirstColumn;
            var bottomFirstColumn = bottom.FirstColumn.Reverse().ToArray();
            var backLastColumn = back.LastColumn.Reverse().ToArray();

            front.UpdateFirstColumn(topFirstColumn);
            bottom.UpdateFirstColumn(frontFirstColumn);
            back.UpdateLastColumn(bottomFirstColumn);
            top.UpdateFirstColumn(backLastColumn);

            SidesLookup[FacingDirection.Left].RotateClockwise();
        }

        private void RotateRightAntiClockwise()
        {
            var top = SidesLookup[FacingDirection.Top];
            var front = SidesLookup[FacingDirection.Front];
            var bottom = SidesLookup[FacingDirection.Bottom];
            var back = SidesLookup[FacingDirection.Back];

            var topLastColumn = top.LastColumn;
            var frontLastColumn = front.LastColumn;
            var bottomLastColumn = new Cell[] { bottom.BottomRow[2], bottom.CentreRow[2], bottom.TopRow[2] };
            var backFirstColumn = new Cell[] { back.BottomRow[0], back.CentreRow[0], back.TopRow[0] };

            top.UpdateLastColumn(backFirstColumn);
            front.UpdateLastColumn(topLastColumn);
            bottom.UpdateLastColumn(frontLastColumn);
            back.UpdateFirstColumn(bottomLastColumn);

            SidesLookup[FacingDirection.Right].RotateAntiClockwise();
        }

        private void RotateUpClockwise()
        {
            var sequence = new[] { SidesLookup[FacingDirection.Left], SidesLookup[FacingDirection.Back], SidesLookup[FacingDirection.Right], SidesLookup[FacingDirection.Front] };
            var startingRow = sequence.Last().TopRow;

            foreach (var side in sequence)
            {
                (startingRow, side.TopRow) = (side.TopRow, startingRow);
            }

            SidesLookup[FacingDirection.Top].RotateClockwise();
        }

        private void RotateDownAntiClockwise()
        {
            var sequence = new[] { SidesLookup[FacingDirection.Left], SidesLookup[FacingDirection.Back], SidesLookup[FacingDirection.Right], SidesLookup[FacingDirection.Front] };
            var startingRow = sequence.Last().BottomRow;

            foreach (var side in sequence)
            {
                (startingRow, side.BottomRow) = (side.BottomRow, startingRow);
            }

            SidesLookup[FacingDirection.Bottom].RotateAntiClockwise();
        }

        private void ConstructCube()
        {
            SidesLookup.Add(FacingDirection.Front, new Side(ConsoleColor.Green));
            SidesLookup.Add(FacingDirection.Back, new Side(ConsoleColor.Blue));
            SidesLookup.Add(FacingDirection.Left, new Side(ConsoleColor.Cyan));
            SidesLookup.Add(FacingDirection.Right, new Side(ConsoleColor.Red));
            SidesLookup.Add(FacingDirection.Top, new Side(ConsoleColor.White));
            SidesLookup.Add(FacingDirection.Bottom, new Side(ConsoleColor.Yellow));
        }

        private static void DisplayMultipleSides(Side[] sides)
        {
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                foreach (var side in sides)
                {
                    DisplayRow(side.GetRow(rowIndex));
                }
                Console.WriteLine();
            }
        }

        private static void DisplayRow(Cell[] row)
        {
            for (int i = 0; i < row.GetLength(0); i++)
            {
                Console.ForegroundColor = row[i].Colour;
                Console.Write($"{row[i].Symbol} ");
            }
        }
    }
}
