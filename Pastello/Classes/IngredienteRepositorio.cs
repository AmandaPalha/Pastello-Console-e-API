using System;
using System.Collections.Generic;
using Pastello.Interfaces;

namespace Pastello
{
    public class IngredienteRepositorio : IRepositorio<Ingrediente>
    {
        private List<Ingrediente> listaIngrediente = new List<Ingrediente>();

        public void Atualiza(int id, Ingrediente entidade)
        {
            listaIngrediente[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaIngrediente[id].Exlcuir();
        }

        public void Insere(Ingrediente entidade)
        {
            listaIngrediente.Add(entidade);
        }

        public List<Ingrediente> Lista()
        {
            return listaIngrediente;
        }

        public int ProximoId()
        {
            return listaIngrediente.Count;
        }

        public Ingrediente RetornaPorId(int id)
        {
            return listaIngrediente[id];
        }
    }
}

