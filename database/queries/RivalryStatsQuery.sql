
SELECT p1.Name,
	   p2.Name,
	   COUNT(prs.AffectedPlayerId) AS Occurences,
	   SUM(prs.Points) AS Points
  FROM [BolfTracker].[dbo].[PlayerRivalryStatistics] prs
  inner join Player p1 on p1.Id = prs.PlayerId 
  inner join Player p2 on p2.Id = prs.AffectedPlayerId
  where prs.AffectedPlayerId = 28
  and prs.ShotTypeId in (3,4,5)
  --and prs.HoleId >= 10
  group by p1.Name, p2.Name
  order by 3 desc
  
  --select * from shottype
  --select * from PlayerRivalryStatistics
  

