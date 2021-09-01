using System;
using System.Collections.Generic;
using artistapi.Models;
using artistapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace artistapi.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ArtistsController : ControllerBase
  {
    private readonly ArtistsService _artistsService;

    public ArtistsController(ArtistsService artistsService)
    {
      _artistsService = artistsService;
    }

    // GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Artist>> Get()
    {
      try
      {
        IEnumerable<Artist> artists = _artistsService.Get();
        return Ok(artists);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // GetById
    [HttpGet("{id}")]
    public ActionResult<Artist> Get(int id)
    {
      try
      {
        Artist artist = _artistsService.Get(id);
        return Ok(artist);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Create
    [HttpPost]
    public ActionResult<Artist> Create([FromBody] Artist newArtist)
    {
      try
      {
        Artist artist = _artistsService.Create(newArtist);
        return Ok(artist);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Update
    [HttpPut("{id}")]
    public ActionResult<Artist> Edit([FromBody] Artist updatedArtist, int id)
    {
      try
      {
        updatedArtist.Id = id;
        Artist artist = _artistsService.Edit(updatedArtist);
        return Ok(artist);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Destroy
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _artistsService.Delete(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}