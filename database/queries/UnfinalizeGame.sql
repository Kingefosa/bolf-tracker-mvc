
select * from Game where Id	= 1067
select * from GameStatistics where GameId = 1067
select * from PlayerGameStatistics where GameId = 1067

/*
begin tran
delete from Game where Id = 1067
delete from GameStatistics where GameId = 970
delete from PlayerGameStatistics where GameId = 970
*/
