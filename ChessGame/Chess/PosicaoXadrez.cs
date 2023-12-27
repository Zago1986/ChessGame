using System.Text;
using Board;

namespace Chess
{
    internal class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ArrayPosition()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Coluna);
            sb.Append(Linha);
            return sb.ToString();
        }
    }
}
