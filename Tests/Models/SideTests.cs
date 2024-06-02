using RubiksCube.Models;

namespace Tests.Models
{
    [TestFixture]
    public class SideTests
    {
        [Test]
        public void Constructor_initializeSideAsExpected()
        {
            var side = new Side(ConsoleColor.Green);
            Assert.AreEqual(ConsoleColor.Green, side.TopRow[0].Colour);
        }

        [Test]
        public void RotateClockwise_RotateSideAsExpected()
        {
            var side = new Side(ConsoleColor.Green);
            side.RotateClockwise();
            Assert.AreEqual(ConsoleColor.Green, side.TopRow[0].Colour);
        }

        [Test]
        public void RotateAntiClockwise_RotateSideAsExpected()
        {
            var side = new Side(ConsoleColor.Green);
            side.RotateAntiClockwise();
            Assert.AreEqual(ConsoleColor.Green, side.TopRow[2].Colour);
        }

        [Test]
        public void UpdateFirstColumn_UpdateColumnCorrectly()
        {
            var side = new Side(ConsoleColor.Green);
            var cells = new Cell[] { new Cell(ConsoleColor.Red), new Cell(ConsoleColor.Red), new Cell(ConsoleColor.Red) };
            side.UpdateFirstColumn(cells);
            Assert.AreEqual(ConsoleColor.Red, side.FirstColumn[0].Colour);
        }

        [Test]
        public void UpdateLastColumn_UpdateColumnCorrectly()
        {
            var side = new Side(ConsoleColor.Green);
            var cells = new Cell[] { new Cell(ConsoleColor.Red), new Cell(ConsoleColor.Red), new Cell(ConsoleColor.Red) };
            side.UpdateLastColumn(cells);
            Assert.AreEqual(ConsoleColor.Red, side.LastColumn[0].Colour);
        }
    }
}
