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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(chessMatch);
                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ArrayPosition();
                        chessMatch.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = chessMatch.Tabuleiro.Peca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(chessMatch.Tabuleiro, posicoesPossiveis);
                        Console.WriteLine("\nTurno: " + chessMatch.Turno
                           + "\nAguardando jogada: " + chessMatch.JogadorAtual
                           );
                        Console.Write("\nDestino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ArrayPosition();
                        chessMatch.ValidarPosicaoDestino(origem, destino);

                        chessMatch.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (TabuleiroException e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}