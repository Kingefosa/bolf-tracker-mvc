﻿using System;
using System.Collections.Generic;
using System.Linq;

using BolfTracker.Infrastructure;
using BolfTracker.Models;
using BolfTracker.Repositories;

namespace BolfTracker.Services
{
    public class HoleService : IHoleService
    {
        private readonly IHoleRepository _holeRepository;
        private readonly IHoleStatisticsRepository _holeStatisticsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HoleService(IHoleRepository holeRepository, IHoleStatisticsRepository holeStatisticsRepository, IUnitOfWork unitOfWork)
        {
            _holeRepository = holeRepository;
            _holeStatisticsRepository = holeStatisticsRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Hole> GetHoles()
        {
            return _holeRepository.All().ToList();
        }

        public IEnumerable<HoleStatistics> GetHoleStatistics(int month, int year)
        {
            Check.Argument.IsNotZeroOrNegative(month, "month");
            Check.Argument.IsNotZeroOrNegative(year, "year");

            return _holeStatisticsRepository.GetByMonthAndYear(month, year);
        }

        public Hole CreateHole(int holeNumber, int par)
        {
            Check.Argument.IsNotZeroOrNegative(holeNumber, "holeNumber");
            Check.Argument.IsNotZeroOrNegative(par, "par");

            var hole = new Hole() { Id = holeNumber, Par = par };

            _holeRepository.Add(hole);
            _unitOfWork.Commit();

            return hole;
        }

        public void CalculateHoleStatistics(int month, int year)
        {
            Check.Argument.IsNotZeroOrNegative(month, "month");
            Check.Argument.IsNotZeroOrNegative(year, "year");

            DeleteHoleStatistics(month, year);

            var holes = _holeRepository.GetActiveByMonthAndYear(month, year);

            foreach (var hole in holes)
            {
                var holeStatistics = new HoleStatistics() { Hole = hole, Month = month, Year = year };

                holeStatistics.ShotsMade = hole.Shots.Count(s => s.ShotMade);
                holeStatistics.Attempts = hole.Shots.Sum(s => s.Attempts);
                holeStatistics.ShootingPercentage = Decimal.Round((decimal)holeStatistics.ShotsMade / (decimal)holeStatistics.Attempts, 3, MidpointRounding.AwayFromZero);
                holeStatistics.PointsScored = hole.Shots.Sum(s => s.Points);
                holeStatistics.Pushes = hole.Shots.Count(s => s.ShotType.Id == 3);
                holeStatistics.Steals = hole.Shots.Count(s => s.ShotType.Id == 4);
                holeStatistics.SugarFreeSteals = hole.Shots.Count(s => s.ShotType.Id == 5);

                _holeStatisticsRepository.Add(holeStatistics);
            }

            _unitOfWork.Commit();
        }

        private void DeleteHoleStatistics(int month, int year)
        {
            _holeStatisticsRepository.DeleteByMonthAndYear(month, year);
        }
    }
}