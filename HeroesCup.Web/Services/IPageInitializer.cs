﻿using System.Threading.Tasks;

namespace HeroesCup.Services
{
    public interface IPageInitializer
    {
        Task SeedStarPageAsync();

        Task SeedAboutPageAsync();
    }
}