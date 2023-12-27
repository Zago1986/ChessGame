using Board;
using System.Security.Cryptography.X509Certificates;

namespace ChessGame
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (tabuleiro.Peca(i,j) is null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(tabuleiro.Peca(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Peca peca)
        {
            if (peca.Cor == Cor.Branca)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(peca);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
