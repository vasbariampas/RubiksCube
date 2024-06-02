using RubiksCube.Enums;
using RubiksCube.Models;

namespace Tests.Models
{
    [TestFixture]
    public class CubeTests
    {
        private Cube cube;

        [SetUp]
        public void Setup()
        {
            cube = new Cube();
        }

        [Test]
        public void Constructor_InitializeSideAsExpected()
        {
            Assert.IsNotNull(cube);
            Assert.IsTrue(cube.GetSide(FacingDirection.Front).TopRow.Any());
        }

        [Test]
        public void Restart_ResetCubeAsExpected()
        {
            cube.Execute(Command.UpClockwise);

            cube.Restart();

            var frontSide = cube.GetSide(FacingDirection.Front);
            foreach (var cell in frontSide.TopRow)
            {
                Assert.AreEqual(ConsoleColor.Green, cell.Colour);
            }
        }

        [TestCase(Command.FrontClockwise, FacingDirection.Right, ConsoleColor.Red, 1)]
        [TestCase(Command.RightAntiClockwise, FacingDirection.Bottom, ConsoleColor.Green, 2)]
        [TestCase(Command.UpClockwise, FacingDirection.Front, ConsoleColor.Red, 1)]
        [TestCase(Command.BackAntiClockwise, FacingDirection.Top, ConsoleColor.Cyan, 1)]
        [TestCase(Command.LeftClockwise, FacingDirection.Back, ConsoleColor.Blue, 0)]
        [TestCase(Command.DownAntiClockwise, FacingDirection.Front, ConsoleColor.Red, 1)]
        public void Execute_CellsAreUpdatedBasedOnGivenCommandAsExpected(Command command, FacingDirection sideToGet, ConsoleColor colourToAssert, int cellIndex)
        {
            cube.Execute(command);

            var side = cube.GetSide(sideToGet);

            if (command == Command.DownAntiClockwise)
            {
                Assert.AreEqual(colourToAssert, side.BottomRow[cellIndex].Colour);
            }
            else
            {
                Assert.AreEqual(colourToAssert, side.TopRow[cellIndex].Colour);
            }
        }
    }
}
