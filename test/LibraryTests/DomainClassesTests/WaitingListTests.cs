using ClassLibrary;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace ClassLibrary.Tests
{
    public class WaitingListTests
    {
        private WaitingList waitingList;

        [SetUp]
        public void Setup()
        {
            waitingList = new WaitingList();
        }

        [Test]
        public void AddPlayer_ValidDisplayName_ReturnsTrueAndAddsPlayer()
        {
            // Act
            bool result = waitingList.AddPlayer("Player1");

            // Assert
            Assert.That(result, Is.True);
            Assert.That(waitingList.Count, Is.EqualTo(1));
            Assert.That(waitingList.FindPlayerByDisplayName("Player1"), Is.Not.Null);
        }

        [Test]
        public void AddPlayer_NullOrEmptyDisplayName_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.That(() => waitingList.AddPlayer(null), Throws.ArgumentException);
            Assert.That(() => waitingList.AddPlayer(""), Throws.ArgumentException);
        }

        [Test]
        public void AddPlayer_DisplayNameAlreadyExists_ReturnsFalse()
        {
            // Arrange
            waitingList.AddPlayer("Player1");

            // Act
            bool result = waitingList.AddPlayer("Player1");

            // Assert
            Assert.That(result, Is.False);
            Assert.That(waitingList.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemovePlayer_ValidDisplayName_ReturnsTrueAndRemovesPlayer()
        {
            // Arrange
            waitingList.AddPlayer("Player1");

            // Act
            bool result = waitingList.RemovePlayer("Player1");

            // Assert
            Assert.That(result, Is.True);
            Assert.That(waitingList.Count, Is.EqualTo(0));
            Assert.That(waitingList.FindPlayerByDisplayName("Player1"), Is.Null);
        }

        [Test]
        public void RemovePlayer_NullOrEmptyDisplayName_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.That(() => waitingList.RemovePlayer(null), Throws.ArgumentException);
            Assert.That(() => waitingList.RemovePlayer(""), Throws.ArgumentException);
        }

        [Test]
        public void RemovePlayer_DisplayNameDoesNotExist_ReturnsFalse()
        {
            // Act
            bool result = waitingList.RemovePlayer("NonExistentPlayer");

            // Assert
            Assert.That(result, Is.False);
            Assert.That(waitingList.Count, Is.EqualTo(0));
        }

        [Test]
        public void FindPlayerByDisplayName_ValidDisplayName_ReturnsPlayer()
        {
            // Arrange
            waitingList.AddPlayer("Player1");

            // Act
            Player foundPlayer = waitingList.FindPlayerByDisplayName("Player1");

            // Assert
            Assert.That(foundPlayer, Is.Not.Null);
            Assert.That(foundPlayer.DisplayName, Is.EqualTo("Player1"));
        }

        [Test]
        public void FindPlayerByDisplayName_NullOrEmptyDisplayName_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.That(() => waitingList.FindPlayerByDisplayName(null), Throws.ArgumentException);
            Assert.That(() => waitingList.FindPlayerByDisplayName(""), Throws.ArgumentException);
        }

        [Test]
        public void FindPlayerByDisplayName_DisplayNameDoesNotExist_ReturnsNull()
        {
            // Act
            Player foundPlayer = waitingList.FindPlayerByDisplayName("NonExistentPlayer");

            // Assert
            Assert.That(foundPlayer, Is.Null);
        }

        [Test]
        public void GetAllWaiting_NoPlayers_ReturnsEmptyCollection()
        {
            // Act
            ReadOnlyCollection<Player> players = waitingList.GetAllWaiting();

            // Assert
            Assert.That(players, Is.Empty);
        }

        [Test]
        public void GetAllWaiting_PlayersExist_ReturnsAllPlayers()
        {
            // Arrange
            waitingList.AddPlayer("Player1");
            waitingList.AddPlayer("Player2");

            // Act
            ReadOnlyCollection<Player> players = waitingList.GetAllWaiting();

            // Assert
            Assert.That(players.Count, Is.EqualTo(2));
            Assert.That(players[0].DisplayName, Is.EqualTo("Player1"));
            Assert.That(players[1].DisplayName, Is.EqualTo("Player2"));
        }

        [Test]
        public void GetAnyoneWaiting_NoPlayers_ReturnsNull()
        {
            // Act
            Player player = waitingList.GetAnyoneWaiting();

            // Assert
            Assert.That(player, Is.Null);
        }

        [Test]
        public void GetAnyoneWaiting_PlayersExist_ReturnsFirstPlayer()
        {
            // Arrange
            waitingList.AddPlayer("Player1");
            waitingList.AddPlayer("Player2");

            // Act
            Player player = waitingList.GetAnyoneWaiting();

            // Assert
            Assert.That(player, Is.Not.Null);
            Assert.That(player.DisplayName, Is.EqualTo("Player1"));
        }

        [Test]
        public void Count_PropertyReflectsNumberOfPlayers()
        {
            // Arrange
            waitingList.AddPlayer("Player1");
            waitingList.AddPlayer("Player2");

            // Act
            int count = waitingList.Count;

            // Assert
            Assert.That(count, Is.EqualTo(2));
        }
    }
}