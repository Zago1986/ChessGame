using Board;

namespace Chess
{
    internal class ChessMatch
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Finished { get; set; }


        public ChessMatch()
        {
            Tabuleiro = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Finished = false;
            InsertPieces();
        }

        public void MovePiece(Posicao source, Posicao destiny)
        {
            Peca piece = Tabuleiro.RetirarPeca(source);
            piece.IncrementarQtdMovimentos();
            Peca capturedPiece = Tabuleiro.RetirarPeca(destiny);
            Tabuleiro.ColocarPeca(piece, destiny);
        }

        private void InsertPieces()
        {
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 1).ArrayPosition());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 2).ArrayPosition());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 3).ArrayPosition());
        }
    }
}
