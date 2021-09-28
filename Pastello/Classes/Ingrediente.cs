using System;

namespace Pastello
{
	public class Ingrediente : EntidadeBase
	{
		private string Nome { get; set; }
		
		private Qualidade Qualidade { get; set; }
		
		private double CustoKg { get; set; }

		private double PesoPorcao { get; set; }

		private double CustoPorcao { get; set; }

		private bool Excluido { get; set; }

		public Ingrediente(int id, string nome, Qualidade qualidade, double custokg, double pesoporcao, double custoporcao)
		{
			this.Id = id;
			this.Qualidade = qualidade;
			this.Nome = nome;
			this.CustoKg = custokg;
			this.PesoPorcao = pesoporcao;
			this.CustoPorcao = custoporcao;
			this.Excluido = false;
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "Nome: " + this.Nome + Environment.NewLine;
			retorno += "Qualidade: " + this.Qualidade + Environment.NewLine;
			retorno += "Custo do Quilo: " + this.CustoKg + Environment.NewLine;
			retorno += "Peso da Porção: " + this.PesoPorcao + Environment.NewLine;
			retorno += "Custo da Porção: " + this.CustoPorcao + Environment.NewLine;
			retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

		public string retornaNome()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}

		public bool retornaExcluido()
		{
			return this.Excluido;
		}

		public Qualidade retornaQualidade()
        {
			return Qualidade;
        }

		public double retornaCustoKg()
        {
			return CustoKg;
        }

		public double retornaPesoPorcao()
		{
			return PesoPorcao;
		}

		public double retornaCustoPorcao()
		{
			return CustoPorcao;
		}

		public void Exlcuir()
		{
			this.Excluido = true;
		}
	}
}

