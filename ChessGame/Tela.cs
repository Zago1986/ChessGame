using Board;
using Chess;
using System.Security.Cryptography.X509Certificates;

namespace ChessGame
{
    internal class Tela
    {
        public static void ImprimirPartida(ChessMatch chessMatch)
        {
            ImprimirTabuleiro(chessMatch.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(chessMatch);
            Console.WriteLine("\nTurno: " + chessMatch.Turno
                            + "\nAguardando jogada: " + chessMatch.JogadorAtual
                            );
        }

        public static void ImprimirPecasCapturadas(ChessMatch chessMatch)
        {
            Console.WriteLine("Pecas capturadas");
            Console.Write("Brancas: ");
            ImprimirConjunto(chessMatch.ListPecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(chessMatch.ListPecasCapturadas(Cor.Preta));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }
            Console.WriteLine("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    PrintPiece(tabuleiro.Peca(i, j)); 
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    PrintPiece(tabuleiro.Peca(i, j));
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Peca peca)
        {
            if (peca is null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
            
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string posicao = Console.ReadLine();
            char coluna = posicao[0];
            int linha = int.Parse(posicao[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
