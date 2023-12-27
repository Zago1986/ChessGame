using Board;
using Chess;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.Finished)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(chessMatch.Tabuleiro);

                    Console.Write("\nOrigem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ArrayPosition();

                    bool[,] posicoesPossiveis = chessMatch.Tabuleiro.Peca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(chessMatch.Tabuleiro, posicoesPossiveis);
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ArrayPosition();

                    chessMatch.MovePiece(origem, destino);
                }

            }
            catch (TabuleiroException e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}