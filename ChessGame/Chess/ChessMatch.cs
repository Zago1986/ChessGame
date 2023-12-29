using Board;
using System.Collections.Generic;

namespace Chess
{
    internal class ChessMatch
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> PecasCapturadas;

        public ChessMatch()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Finished = false;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            InsertPieces();
        }

        public void MovePiece(Posicao source, Posicao destiny)
        {
            Peca piece = Tabuleiro.RetirarPeca(source);
            piece.IncrementarQtdMovimentos();
            Peca capturedPiece = Tabuleiro.RetirarPeca(destiny);
            Tabuleiro.ColocarPeca(piece, destiny);
            if (capturedPiece != null)
            {
                PecasCapturadas.Add(capturedPiece);
            }
        }

        public void RealizaJogada(Posicao source, Posicao destiny)
        {
            MovePiece(source, destiny);
            Turno++;
            ChangePlayer();
        }

        public void ValidarPosicaoOrigem(Posicao posicao)
        {
            if (Tabuleiro.Peca(posicao) is null)
            {
                throw new TabuleiroException("There is no piece here!");
            }
            if (JogadorAtual != Tabuleiro.Peca(posicao).Cor)
            {
                throw new TabuleiroException("This one does not belong to you!");
            }
            if (!Tabuleiro.Peca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("This one is blocked!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Movement not valid");
            }
        }

        private void ChangePlayer()
        {
            if (JogadorAtual is Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ArrayPosition());
            Pecas.Add(peca);
        }

        public HashSet<Peca> ListPecasCapturadas(Cor cor)
        {
            HashSet<Peca> listPecas = new HashSet<Peca>();
            foreach (Peca peca in PecasCapturadas)
            {
                if (peca.Cor == cor)
                {
                    listPecas.Add(peca);
                }
            }
            return listPecas;
        }

        public HashSet<Peca> ListPecasJogo(Cor cor)
        {
            HashSet<Peca> listPecas = new HashSet<Peca>();
            foreach (Peca peca in Pecas)
            {
                if (peca.Cor.Equals(cor))
                {
                    listPecas.Add(peca);
                }
            }
            listPecas.ExceptWith(ListPecasCapturadas(cor));
            return listPecas;
        }

        private void InsertPieces()
        {
            Tabuleiro.ColocarPeca(new Rei(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 1).ArrayPosition());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 2).ArrayPosition());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('b', 1).ArrayPosition());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('b', 2).ArrayPosition());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 1).ArrayPosition());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 2).ArrayPosition());

            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 3).ArrayPosition());
            Tabuleiro.ColocarPeca(new Rei(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 6).ArrayPosition());
        }
    }
}
