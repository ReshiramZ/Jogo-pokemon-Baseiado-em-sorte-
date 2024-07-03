using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Minimalista.PokemonBase
{
    internal class Pokemon
    {
        public string Nome { get; set; }
        public Tipos TipoDoPokemon { get; set; }
        public Status StatusDoPokemon { get; set; }
        public int DerrotaMax { get; set; }
        public bool EstaSeMovendo { get; set; }

        public Pokemon(string nome, Tipos tipo, int derrotaMax, bool estaSeMovendo)
        {
            Nome = nome;
            TipoDoPokemon = tipo;
            StatusDoPokemon = Status.Nenhum;
            DerrotaMax = derrotaMax;
            EstaSeMovendo = estaSeMovendo;
        }

    }
}
