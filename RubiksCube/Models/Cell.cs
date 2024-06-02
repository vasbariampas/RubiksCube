namespace RubiksCube.Models
{
    public class Cell(ConsoleColor colour)
    {
        public string Symbol { get; set; } = "■";
        public ConsoleColor Colour { get; set; } = colour;
    }
}
