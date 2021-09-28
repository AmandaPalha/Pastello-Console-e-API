using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pastello.Web
{
    public class IngredienteModel
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public Qualidade Qualidade { get; set; }
		public double CustoKg { get; set; }
		public double PesoPorcao { get; set; }
		public double CustoPorcao { get; set; }
		public bool Excluido { get; set; }

		public IngredienteModel() { }

		public IngredienteModel(Ingrediente ingrediente)
        {
			Id = ingrediente.retornaId();
			Nome = ingrediente.retornaNome();
			Qualidade = ingrediente.retornaQualidade();
			CustoKg = ingrediente.retornaCustoKg();
			PesoPorcao = ingrediente.retornaCustoPorcao();
			CustoPorcao = ingrediente.retornaCustoPorcao();
        }


		public Ingrediente ToIngrediente()
        {
			return new Ingrediente(Id, Nome, Qualidade, CustoKg, PesoPorcao, CustoPorcao);
        }

	}
}
