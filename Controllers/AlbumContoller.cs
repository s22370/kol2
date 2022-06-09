using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using kol2.DTOs;
using kol2.Entities.Models;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace kol2.Controllers
{
    [Route("[controller]")]
      [ApiController]
    public class AlbumContoller : ControllerBase
    {
         private readonly IRepoService _service;

        public IRepoService Get_service()
        {
            return _service;
        }

        [HttpGet("{IdAlbum}")]

        public async Task<IActionResult> Get(int IdAlbum) {
            return Ok(
                await _service.GetAlbumById(IdAlbum).Select(e=>new AlbumGet{
                    IdAlbum=e.IdAlbum,
                    AlbumName=e.AlbumName,
                    publishDate=e.publishDate,
                    Track=e.Track.Select(e=>new DTOs.Track
                    {
                        IdTrack=e.IdTrack,
                        TrackName=e.TrackName,
                        Duration=e.Duration
                    } ).ToList()
                }).ToListAsync()
            );
        }
    }
}