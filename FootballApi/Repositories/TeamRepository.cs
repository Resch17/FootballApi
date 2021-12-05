using FootballApi.Interfaces;
using FootballApi.Models;
using FootballApi.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballApi.Repositories
{
    public class TeamRepository : BaseRepository, ITeamRepository
    {
        public TeamRepository(IConfiguration configuration) : base(configuration) { }

        public void DeleteAllTeams()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Team";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void InsertTeam(Team team)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SET IDENTITY_INSERT Team ON;
                        INSERT INTO Team ([Id], [Location], [Abbreviation], [DisplayName], [Name], [Logo])
                        VALUES (@Id, @Location, @Abbreviation, @DisplayName, @Name, @Logo);
                        SET IDENTITY_INSERT Team OFF;";

                    DbUtils.AddParameter(cmd, "@Id", team.Id);
                    DbUtils.AddParameter(cmd, "@Location", team.Location);
                    DbUtils.AddParameter(cmd, "@Abbreviation", team.Abbreviation);
                    DbUtils.AddParameter(cmd, "@DisplayName", team.DisplayName);
                    DbUtils.AddParameter(cmd, "@Name", team.Name);
                    DbUtils.AddParameter(cmd, "@Logo", team.Logo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
