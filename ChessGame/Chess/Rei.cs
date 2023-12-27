using Board;

namespace Chess
{
    internal class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0,0);

            //norte
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && IsAble(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            //nordeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && IsAble(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            //leste
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && IsAble(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            //sudeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && IsAble(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            //sul
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && IsAble(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            //sudoeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && IsAble(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            //oeste
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && IsAble(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            //Noroeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && IsAble(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            return movimentosPossiveis;
        }
    }
}
