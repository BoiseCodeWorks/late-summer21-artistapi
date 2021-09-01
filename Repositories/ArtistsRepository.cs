using System.Collections.Generic;
using System.Data;
using System.Linq;
using artistapi.Models;
using Dapper;

namespace artistapi.Repositories
{
  public class ArtistsRepository
  {
    private readonly IDbConnection _db;

    public ArtistsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Artist> Get()
    {
      string sql = "SELECT * FROM artists";
      return _db.Query<Artist>(sql).ToList();
    }

    internal Artist Get(int id)
    {
      // the '@' is used by dapper to pull in variables off of a provided object
      string sql = "SELECT * FROM artists WHERE id = @id";
      //   Query first or default retruns a single objecr or NULL if not found
      return _db.QueryFirstOrDefault<Artist>(sql, new { id });
    }

    internal Artist Create(Artist newArtist)
    {
      string sql = @"
      INSERT INTO artists
      (name, birthYear, deceased)
      VALUES
      (@Name, @BirthYear, @Deceased);
      SELECT LAST_INSERT_ID();";
      newArtist.Id = _db.ExecuteScalar<int>(sql, newArtist);
      return newArtist;
    }

    internal Artist Update(Artist updatedArtist)
    {
      string sql = @"
        UPDATE artists
        SET
            name = @Name,
            birthYear = @BirthYear,
            deceased = @Deceased
        WHERE id = @Id;
      ";
      _db.Execute(sql, updatedArtist);
      return updatedArtist;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM artists WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}