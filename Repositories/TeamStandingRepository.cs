using CallOfDutyLeague.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Repositories
{
    public interface ITeamStandingRepository
    {
        public List<TeamStanding> GetCurrentStandings(short year);
		public Task<List<TeamStanding>> GetGroupStandingsAsync();
    }
    public class TeamStandingRepository : ITeamStandingRepository
    {
        public List<TeamStanding> GetCurrentStandings(short year)
        {
            using (var con = new SqlConnection(Constants.ConnectionString))
            {
                var parameters = new { year = year };
                return con.Query<TeamStanding>($@"SELECT
						seasonTeam.SeasonTeamID,
						team.TeamName,
						(
							SELECT COUNT(series.SeriesID)
							FROM tblSeries series (NOLOCK)
							WHERE (series.AwayTeamID = seasonTeam.SeasonTeamID OR series.HomeTeamID = seasonTeam.seasonTeamID) AND
								(SELECT COUNT(seriesMap.SeriesMapID) FROM tblSeriesMap seriesMap (NOLOCK) WHERE seriesMap.SeriesID = series.SeriesID AND seriesMap.WinningTeamID = seasonTeam.seasonTeamID) > (series.BestOfGameNumber / 2)
						) AS Wins,
						(
							SELECT COUNT(series.SeriesID)
							FROM tblSeries series (NOLOCK)
							WHERE (series.AwayTeamID = seasonTeam.SeasonTeamID OR series.HomeTeamID = seasonTeam.seasonTeamID) AND
								(SELECT COUNT(seriesMap.SeriesMapID) FROM tblSeriesMap seriesMap (NOLOCK) WHERE seriesMap.SeriesID = series.SeriesID AND seriesMap.WinningTeamID != seasonTeam.seasonTeamID) > (series.BestOfGameNumber / 2)
						) AS Losses,
						(SELECT COUNT(seriesMap.SeriesMapID)
							FROM tblSeriesMap seriesMap (NOLOCK) WHERE seasonTeam.SeasonTeamID = seriesMap.WinningTeamID
						) AS MapWins,
						(SELECT COUNT(seriesMap.SeriesMapID)
							FROM tblSeriesMap seriesMap (NOLOCK)
							LEFT JOIN tblSeries series (NOLOCK) ON seriesMap.SeriesID = series.SeriesID
							WHERE (series.HomeTeamID = seasonTeam.SeasonTeamID OR series.AwayTeamID = seasonTeam.SeasonTeamID) AND seriesMap.WinningTeamID != seasonTeam.seasonTeamID
						) AS MapLosses
					FROM tblSeasonTeam seasonTeam (NOLOCK)
					JOIN tblSeason season (NOLOCK) ON seasonTeam.SeasonID = season.SeasonID
					JOIN tblTeam team (NOLOCK) ON seasonTeam.TeamID = team.TeamID
					WHERE season.Year = @year
					ORDER BY Wins desc, Losses Asc, MapWins desc, MapLosses asc, team.TeamName", parameters).ToList();
            }
        }
		public async Task<List<TeamStanding>> GetGroupStandingsAsync()
		{
			using (var con = new SqlConnection(Constants.ConnectionString))
			{
				var parameters = new { today = DateTime.Today };
				return (await con.QueryAsync<TeamStanding>($@"SELECT
					stageGroupTeam.StageGroupID,
					seasonTeam.SeasonTeamID,
					team.TeamName,
					(
						SELECT COUNT(series.SeriesID)
						FROM tblSeries series (NOLOCK)
						JOIN tblEvent event (NOLOCK) ON event.EventID = series.EventID AND event.StageID = stage.StageID
						WHERE (series.AwayTeamID = seasonTeam.SeasonTeamID OR series.HomeTeamID = seasonTeam.seasonTeamID) AND
							(SELECT COUNT(seriesMap.SeriesMapID) FROM tblSeriesMap seriesMap (NOLOCK) WHERE seriesMap.SeriesID = series.SeriesID AND seriesMap.WinningTeamID = seasonTeam.seasonTeamID) > (series.BestOfGameNumber / 2)
					) AS Wins,
					(
						SELECT COUNT(series.SeriesID)
						FROM tblSeries series (NOLOCK)
						JOIN tblEvent event (NOLOCK) ON event.EventID = series.EventID AND event.StageID = stage.StageID
						WHERE (series.AwayTeamID = seasonTeam.SeasonTeamID OR series.HomeTeamID = seasonTeam.seasonTeamID) AND
							(SELECT COUNT(seriesMap.SeriesMapID) FROM tblSeriesMap seriesMap (NOLOCK) WHERE seriesMap.SeriesID = series.SeriesID AND seriesMap.WinningTeamID != seasonTeam.seasonTeamID) > (series.BestOfGameNumber / 2)
					) AS Losses,
					(SELECT COUNT(seriesMap.SeriesMapID)
						FROM tblSeriesMap seriesMap (NOLOCK)
						JOIN tblSeries series (NOLOCK) ON seriesMap.SeriesID = series.SeriesID
						JOIN tblEvent event (NOLOCK) ON event.EventID = series.EventID AND event.StageID = stage.StageID
						WHERE seasonTeam.SeasonTeamID = seriesMap.WinningTeamID
					) AS MapWins,
					(SELECT COUNT(seriesMap.SeriesMapID)
						FROM tblSeriesMap seriesMap (NOLOCK)
						JOIN tblSeries series (NOLOCK) ON seriesMap.SeriesID = series.SeriesID
						JOIN tblEvent event (NOLOCK) ON event.EventID = series.EventID AND event.StageID = stage.StageID
						WHERE (series.HomeTeamID = seasonTeam.SeasonTeamID OR series.AwayTeamID = seasonTeam.SeasonTeamID) AND seriesMap.WinningTeamID != seasonTeam.seasonTeamID
					) AS MapLosses
				FROM tblStageGroupTeam stageGroupTeam (NOLOCK)
				JOIN tblStageGroup stageGroup (NOLOCK) ON stageGroup.StageGroupID = stageGroupTeam.StageGroupID
				JOIN tblStage stage (NOLOCK) ON stage.StageID = stageGroup.StageID
				JOIN tblSeasonTeam seasonTeam (NOLOCK) ON seasonTeam.SeasonTeamID = stageGroupTeam.SeasonTeamID
				JOIN tblSeason season (NOLOCK) ON seasonTeam.SeasonID = season.SeasonID
				JOIN tblTeam team (NOLOCK) ON seasonTeam.TeamID = team.TeamID
				WHERE stage.StartDate <= @today AND stage.EndDate >= @today
				ORDER BY Wins desc, Losses Asc, MapWins desc, MapLosses asc, team.TeamName", parameters)).ToList();
			}
		}
	}
}
