    namespace ClassLibrary.Tests;
    using NUnit.Framework;
    using ClassLibrary;

    public class UserStory11Tests
    {
        [TearDown]
        public void TearDown()
        {
            Facade.Reset();
        }
        
        [Test]
        public void PlayerIsWaiting_WhenNotAdded_ReturnsNotWaiting()
        {
            string result = Facade.Instance.PlayerIsWaiting("user");
            
            Assert.That(result, Is.EqualTo("user no está esperando"));
        }
        
        [Test]
        public void PlayerIsWaiting_WhenAdded_ReturnsWaiting()
        {
            Facade.Instance.AddPlayerToWaitingList("user");
            
            string result = Facade.Instance.PlayerIsWaiting("user");
            
            Assert.That(result, Is.EqualTo("user está esperando"));
        }
        

        [Test]
        public void StartBattle_WhenNoOpponentAndNobodyIsWaiting_ReturnsNobodyIsWaiting()
        {
            string result = Facade.Instance.StartBattle("user", null);
            
            Assert.That(result, Is.EqualTo("No hay nadie esperando"));
        }

        [Test]
        public void StartBattle_WhenOpponentButIsNotWaiting_ReturnsNotWaiting()
        {
            string result = Facade.Instance.StartBattle("user", "opponent");
            
            Assert.That(result, Is.EqualTo("opponent no está esperando"));
        }

        [Test]
        public void StartBattle_WhenNoOpponentButOneWaiting_ReturnsBattleWithWaiting()
        {
            Facade.Instance.AddPlayerToWaitingList("opponent");
            
            string result = Facade.Instance.StartBattle("user", null);
            
            Assert.That(result, Is.EqualTo("Comienza user vs opponent"));
        }

        [Test]
        public void StartBattle_WhenOpponentWaiting_ReturnsBattleWithOpponent()
        {
            Facade.Instance.AddPlayerToWaitingList("opponent");
            
            string result = Facade.Instance.StartBattle("user", "opponent");
            
            Assert.That(result, Is.EqualTo("Comienza user vs opponent"));
        }
    }