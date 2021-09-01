using System;
using System.Collections.Generic;
using artistapi.Models;
using artistapi.Repositories;

namespace artistapi.Services
{
  public class ArtistsService
  {
    private readonly ArtistsRepository _repo;

    public ArtistsService(ArtistsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Artist> Get()
    {
      return _repo.Get();
    }

    internal Artist Get(int id)
    {
      Artist artist = _repo.Get(id);
      if (artist == null)
      {
        throw new Exception("Invalid Id");
      }
      return artist;
    }

    internal Artist Create(Artist newArtist)
    {
      Artist artist = _repo.Create(newArtist);
      if (artist == null)
      {
        throw new Exception("Invalid Id");
      }
      return artist;
    }

    internal Artist Edit(Artist updatedArtist)
    {
      // Find the original before edits
      Artist original = Get(updatedArtist.Id);
      // check each value on the incoming object, if it exits then allow it to continue, if it does not set it to the original value
      updatedArtist.Name = updatedArtist.Name != null ? updatedArtist.Name : original.Name;
      updatedArtist.BirthYear = updatedArtist.BirthYear != 0 ? updatedArtist.BirthYear : original.BirthYear;
      updatedArtist.Deceased = updatedArtist.DeceasedWasSet ? updatedArtist.Deceased : original.Deceased;
      return _repo.Update(updatedArtist);
    }

    internal void Delete(int id)
    {
      Artist original = Get(id);
      _repo.Delete(id);
    }
  }
}