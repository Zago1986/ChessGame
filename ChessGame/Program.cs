using System;
using Tabuleiro;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Posicao p = new Posicao(3, 4);
            Console.WriteLine("Posicao: " + p);
        }
    }
}