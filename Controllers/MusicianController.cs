using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kol2.Controllers
{
    [Route("[controller]")]
    public class MusicianController : ControllerBase
    {
        private readonly IRepoService _service;

        public IRepoService Get_service()
        {
            return _service;
        }
/*
        [HttpDelete("{IdMusician}")]

        public async Task<IActionResult> Delete(int IdMusician) {
          if (await _service.GetMusicianById(IdMusician).FirstOrDefaultAsync() is null)
                return NotFound("Nie znaleziono klienta o podanym id");
        }
        */
    }
    
}