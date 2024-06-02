using RubiksCube.Enums;
using RubiksCube.Models;

namespace RubiksCube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cube = new Cube();
            cube.DisplaySide(FacingDirection.Front);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Select a command (number): ");
                Console.WriteLine("1. Front face clockwise 90°        4. Back face anti-clockwise 90°");
                Console.WriteLine("2. Right face anti-clockwise 90°   5. Left face clockwise 90°");
                Console.WriteLine("3. Up face clockwise 90°           6. Down face anti-clockwise 90°");
                Console.WriteLine("Or enter 'r' to restart or 'e' to explode.");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (Enum.TryParse<Command>(input, true, out Command selectedCommand) &&
                    Enum.IsDefined(typeof(Command), selectedCommand))
                {
                    cube.Execute(selectedCommand);
                    cube.DisplaySide(FacingDirection.Front);
                }
                else if (input.Equals("r", StringComparison.CurrentCultureIgnoreCase))
                {
                    cube.Restart();
                }
                else if (input.Equals("e", StringComparison.CurrentCultureIgnoreCase))
                {
                    cube.Explode();
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
                Console.WriteLine();
            }
        }
    }
}
