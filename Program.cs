namespace PuzzleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleGame game = new PuzzleGame();

            Console.WriteLine("Заходи - не бойся, выходи - не плачь :))))");

            while (!game.CheckingForWin())
            {
                game.PrintBoard();
                game.Move();

                Console.Clear();
            }

            Console.WriteLine("Игра пройдена.");
        }
    }
}