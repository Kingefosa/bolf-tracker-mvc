﻿using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BolfTracker.Infrastructure.EntityFramework.IntegrationTests
{
    [TestClass]
    public class PlayerHoleStatisticsRepositoryTests
    {
        private PlayerRepository _playerRepository;
        private HoleRepository _holeRepository;
        private PlayerHoleStatisticsRepository _playerHoleStatisticsRepository;
        private TransactionScope _transaction;

        [TestInitialize]
        public void Initialize()
        {
            _playerRepository = new PlayerRepository();
            _holeRepository = new HoleRepository();
            _playerHoleStatisticsRepository = new PlayerHoleStatisticsRepository();
            _transaction = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _transaction.Dispose();
        }

        [TestMethod]
        public void Should_be_able_to_add_player_hole_statistics()
        {
            var player = ObjectMother.CreatePlayer();
            _playerRepository.Add(player);

            var hole = ObjectMother.CreateHole(Int32.MaxValue);
            _holeRepository.Add(hole);

            var playerHoleStatistics = ObjectMother.CreatePlayerHoleStatistics(player, hole);
            _playerHoleStatisticsRepository.Add(playerHoleStatistics);

            Assert.AreNotEqual(0, playerHoleStatistics.Id);
        }
    }
}
