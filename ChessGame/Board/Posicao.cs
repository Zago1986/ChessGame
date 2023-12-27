﻿using System.Text;

namespace Board
{
    internal class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public void DefinirValores(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Linha);
            sb.Append(", ");
            sb.Append(Coluna);
            return sb.ToString();
        }
    }
}
