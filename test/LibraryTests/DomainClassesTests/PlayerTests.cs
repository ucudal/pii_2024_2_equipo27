using NUnit.Framework;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;
        private Pokemon _pokemon;


        [SetUp]
        public void Setup()
        {
            Move[] moves = new Move[]
            {
                new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
                new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
                new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
                new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
            };

            player = new Player("Juan");
            _pokemon = new Pokemon(moves);
        }


        [Test]
        public void AddPokemon_ShouldAddPokemonToAvailablePokemons()
        {
            // Act
            player.AddPokemon(_pokemon);

            // Assert
            Assert.That(player.AvailablePokemons[0].Name, Is.EqualTo(_pokemon.Name));
        }


        [Test]
        public void AddPokemon_ShouldSetActivePokemon_WhenFirstPokemonAdded()
        {
            // Act
            player.AddPokemon(_pokemon);

            // Assert
            Assert.That(player.ActivePokemon.Name, Is.EqualTo(_pokemon.Name));
        }


        [Test]
        public void UseItem_ShouldRemoveItemFromInventory_WhenItemExists()
        {
            // Arrange
            Player player = new Player("TestPlayer");
            Item item = new ItemRevive();

            // Act
            player.UseItem("Revivir");

            // Assert
            Assert.That(() => player.UseItem("Revivir"), Throws.InstanceOf<ApplicationException>());
        }

        [SetUp]
        public void SetUp()
        {
            Facade.Reset();
        }

        private string attacker = "player1";
        private string defender = "player2";
        private string[] attackerPokemons = new string[] { "Blaziken", "Tinkaton", "Salamence", };
        private string[] defenderPokemons = new string[] { "Tinkaton", "Zangoose", "Rayquaza", };
        private string move = "Patada Ígnea";
        private string move2 = "Carantoña";

        [Test]
         public void PlayerAttack_Works_Correctly()
         {
             // Arrange
            
             Facade.Instance.GameList.AddGame(new Player(attacker), new Player(defender));
             Facade.Instance.AddPlayerToWaitingList(attacker);
             Facade.Instance.AddPlayerToWaitingList(defender);
             Facade.Instance.StartBattle(attacker, defender);
             Facade.Instance.ChoosePokemons(attacker, attackerPokemons);
             Facade.Instance.ChoosePokemons(defender, defenderPokemons);
             Facade.Instance.ChooseMoveToAttack(attacker, move);
             Facade.Instance.ChooseMoveToAttack(defender, move2);
        
             // Obtener el defensor y su Pokémon activo antes del ataque
             Player defenderPlayer = Facade.Instance.GameList.FindPlayerByDisplayName(defender);
             
             int healthPointsBefore = defenderPlayer.ActivePokemon.HealthPoints;
        
             string battleProgres = player.DetermineBattleProgress(defenderPlayer);
             // Act
             string result = Facade.Instance.PlayerAttack(attacker);
             
             // Obtener los puntos de salud después del ataque
             int healthPointsAfter = defenderPlayer.ActivePokemon.HealthPoints;
        
             // Assert
             Assert.That(result, Is.EqualTo(
                 $" Jugador {attacker} usa al Pokémon {attackerPokemons[0]} que ataca con {move} a {defenderPokemons[0]} de {defender}, HP pasa de {healthPointsBefore} a {healthPointsAfter}, {battleProgres}"));
         }
    }
}