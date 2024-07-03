using Pokemon_Minimalista.PokemonBase;

Pokemon Charmander = new Pokemon("Charmander", Tipos.Fogo, 21, true);
Pokemon Chimchar = new Pokemon("Chimchar", Tipos.Fogo, 21, true);

Pokemon Jigglypuff = new Pokemon("Jigglypuff", Tipos.Normal, 21, true);
Pokemon Clefairy = new Pokemon("Clefairy", Tipos.Normal, 21, true);

Pokemon Pikachu = new Pokemon("Pikachu", Tipos.Eletrico, 21, true);
Pokemon Electabuzz = new Pokemon("Electabuzz", Tipos.Eletrico, 21, true);

Pokemon Ekans = new Pokemon("Ekans", Tipos.Veneno, 21, true);
Pokemon Bulbasaur = new Pokemon("Bulbasaur", Tipos.Veneno, 21, true);

Random Dado = new Random();
Random DadoStatus = new Random();

List<Pokemon> PokemonParty = new List<Pokemon>();
List<Pokemon> PartyRival = new List<Pokemon>();

PartyRival.Add(Chimchar);
PartyRival.Add(Clefairy);
PartyRival.Add(Electabuzz);
PartyRival.Add(Bulbasaur);

int PokemonAleatorio = Dado.Next(0, PartyRival.Count);
int PokemonSelecionado = PokemonAleatorio;

EscolherInicial();

void EscolherInicial()
{
    Console.WriteLine("Escolha seu inicial...\n\n" +
        "1 - Chamander\n" +
        "2 - Jigglypuff\n" +
        "3 - Pikachu\n" +
        "4 - Ekans\n");

    string Input = Convert.ToString(Console.ReadLine()); // Cena para escolher pokémon inicial

    switch (Input)
    {
        case "1":
            Console.Clear();
            PokemonParty.Add(Charmander);
            Console.WriteLine($"Você adicionou {PokemonParty[0].Nome} para a sua equipe!");
            break;

        case "2":
            Console.Clear();
            PokemonParty.Add(Jigglypuff);
            Console.WriteLine($"Você adicionou {PokemonParty[0].Nome} para a sua equipe!");
            break;

        case "3":
            Console.Clear();
            PokemonParty.Add(Pikachu);
            Console.WriteLine($"Você adicionou {PokemonParty[0].Nome} para a sua equipe!");
            break;

        case "4":
            Console.Clear();
            PokemonParty.Add(Ekans);
            Console.WriteLine($"Você adicionou {PokemonParty[0].Nome} para a sua equipe!");
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opção inválida, digite novamente!");
            EscolherInicial();
            break;
    }

    Turno(PokemonParty[0], PartyRival[PokemonSelecionado]);
}
void Turno(Pokemon Aliado, Pokemon Rival) // Cena de turno
{
    if (Dado.Next(1, Aliado.DerrotaMax) == 1 && Rival.EstaSeMovendo == true)   // se o pokémon rival estiver se mexendo...
    {
        Console.Clear();
        Console.WriteLine($"{Aliado.Nome} desmaiou!");  // Cena de derrota aliado
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    else if (Dado.Next(1, Rival.DerrotaMax) == 1 && Aliado.EstaSeMovendo == true)  // se o pokémon aliado estiver se movendo...
    {
        Console.Clear();
        Console.WriteLine($"{Rival.Nome} desmaiou!");
        Console.WriteLine("Pressione qualquer tecla para continuar..."); // Cena de derrota rival
        Console.ReadKey();
    }
    else
    {
        Console.Clear();
        Console.WriteLine($"{Aliado.Nome} e {Rival.Nome} estão em pé!"); // se nenhum dos dois for derrotado...
        VerificarCondicaoStatus(Aliado, Rival);
        VerificarCondicaoStatus(Rival, Aliado);
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();

        Turno(PokemonParty[0], PartyRival[PokemonSelecionado]);
    }

}

void VerificarCondicaoStatus(Pokemon Alvo, Pokemon Aplicador) // Aplica a condição ao alvo 
{
    if (DadoStatus.Next(1, 11) == 1 && Aplicador.TipoDoPokemon == Tipos.Fogo && Alvo.TipoDoPokemon != Tipos.Fogo && Alvo.StatusDoPokemon == Status.Nenhum && Aplicador.StatusDoPokemon != Status.Adormecido)
    {
        Console.WriteLine($"{Alvo.Nome} foi queimado!");
        Alvo.StatusDoPokemon = Status.Queimado;
    }
    else if (DadoStatus.Next(1, 11) == 1 && Aplicador.TipoDoPokemon == Tipos.Veneno && Alvo.TipoDoPokemon != Tipos.Veneno && Alvo.StatusDoPokemon == Status.Nenhum && Aplicador.StatusDoPokemon != Status.Adormecido)
    {
        Console.WriteLine($"{Alvo.Nome} foi envenenado!");
        Alvo.StatusDoPokemon = Status.Envenenado;
    }
    else if (DadoStatus.Next(1, 11) == 1 && Aplicador.TipoDoPokemon == Tipos.Eletrico && Alvo.TipoDoPokemon != Tipos.Eletrico && Alvo.StatusDoPokemon == Status.Nenhum && Aplicador.StatusDoPokemon != Status.Adormecido)
    {
        Console.WriteLine($"{Alvo.Nome} foi paralizado!");
        Alvo.StatusDoPokemon = Status.Paralizado;
    }
    else if (DadoStatus.Next(1, 16) == 1 && Aplicador.TipoDoPokemon == Tipos.Normal && Alvo.StatusDoPokemon == Status.Nenhum && Aplicador.StatusDoPokemon != Status.Adormecido)
    {
        Console.WriteLine($"{Alvo.Nome} está com sono!");
        Alvo.StatusDoPokemon = Status.Adormecido;
    }

    switch (Alvo.StatusDoPokemon) // para que serve as condições?
    {
        case Status.Queimado:

            Console.WriteLine($"A queimadura de {Alvo.Nome} está o deixando mais fraco!");

            Aplicador.DerrotaMax += 3; // aumenta a 'vida' do aplicador
            break;

        case Status.Envenenado:
            Console.WriteLine($"O veneno de {Alvo.Nome} está piorando!"); // Diminui a 'vida' do alvo
            Alvo.DerrotaMax = Math.Max(1, Alvo.DerrotaMax - 2);
            break;

        case Status.Paralizado:
            Alvo.EstaSeMovendo = true;
            if (DadoStatus.Next(1, 4) == 1)
            {
                Console.WriteLine($"{Alvo.Nome} está parado é incapaz de derrotar {Aplicador.Nome} nesse turno!"); // Alvo não pode se mover nesse turno
                Alvo.EstaSeMovendo = false;
            }
            break;

        case Status.Adormecido:
            Console.WriteLine($"{Alvo.Nome} está dormindo!");
            Alvo.EstaSeMovendo = false;
            if (DadoStatus.Next(1, 4) == 1)
            {
                Console.WriteLine($"{Alvo.Nome} Acordou!");
                Alvo.EstaSeMovendo = true;
                Alvo.StatusDoPokemon = Status.Nenhum;
            }
            break;
    }
}