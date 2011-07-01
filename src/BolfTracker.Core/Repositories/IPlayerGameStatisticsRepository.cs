﻿using System.Collections.Generic;

using BolfTracker.Models;

namespace BolfTracker.Repositories
{
    public interface IPlayerGameStatisticsRepository : IRepository<PlayerGameStatistics>
    {
        IEnumerable<PlayerGameStatistics> GetByPlayer(int playerId);

        IEnumerable<PlayerGameStatistics> GetByPlayerMonthAndYear(int playerId, int month, int year);
    }
}