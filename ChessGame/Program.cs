using Board;
using Chess;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez position = new PosicaoXadrez('a', 1);
            Console.WriteLine(position);
            Console.WriteLine(position.ArrayPosition());
        }
    }
}