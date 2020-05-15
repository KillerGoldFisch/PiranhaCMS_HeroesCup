﻿using HeroesCup.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace ClubsModule.Models
{
    public class ClubEditModel
    {
        public Club Club { get; set; }

        public Hero Coordinator { get; set; }

        public Guid CoordinatorId { get; set; }

        public IFormFile UploadedLogo { get; set; }
        public string LogoUrl { get; set; }

        public IEnumerable<Hero> Heroes { get; set;}

        public IEnumerable<Guid> HeroesIds { get; set; }

        public IEnumerable<Mission> Missions { get; set; }

        public IEnumerable<Guid> MissionsIds { get; set; }
    }
}
