using ClubsModule;
using HeroesCup.Modules.ClubsModule.Blocks;
using Piranha;
using Piranha.Extend;
using Piranha.Manager;
using Piranha.Security;
using System.Collections.Generic;

namespace HeroesCup.Modules.ClubsModule
{
    /// <summary>
    /// The identity module.
    /// </summary>
    public class Module : IModule
    {
        private readonly List<PermissionItem> _permissions = new List<PermissionItem>
        {
            new PermissionItem { Name = Permissions.Heroes, Title = "List Heroes", Category = "Heroes", IsInternal = true },
            new PermissionItem { Name = Permissions.HeroesAdd, Title = "Add Heroes", Category = "Heroes", IsInternal = true },
            new PermissionItem { Name = Permissions.HeroesDelete, Title = "Delete Heroes", Category = "Heroes", IsInternal = true },
            new PermissionItem { Name = Permissions.HeroesEdit, Title = "Edit Heroes", Category = "Heroes", IsInternal = true },
            new PermissionItem { Name = Permissions.HeroesSave, Title = "Save Heroes", Category = "Heroes", IsInternal = true },
        };

        /// <summary>
        /// Gets the Author
        /// </summary>
        public string Author => "Andrey Dautev";

        /// <summary>
        /// Gets the Name
        /// </summary>
        public string Name => "ClubsModule";

        /// <summary>
        /// Gets the Version
        /// </summary>
        public string Version => Utils.GetAssemblyVersion(GetType().Assembly);

        /// <summary>
        /// Gets the description
        /// </summary>
        public string Description => "Clubs Module";

        /// <summary>
        /// Gets the package url.
        /// </summary>
        public string PackageUrl => "https://www.nuget.org/packages/ClubsModule";

        /// <summary>
        /// Gets the icon url.
        /// </summary>
        public string IconUrl => "";

        /// <summary>
        /// Initializes the module.
        /// </summary>
        public void Init()
        {
            foreach (var permission in _permissions)
            {
                App.Permissions["Manager"].Add(permission);
            }

            Menu.Items.Insert(2, new MenuItem
            {
                InternalId = "ClubsModule",
                Name = "Clubs",
                Css = "fas fa-fish"
            });
            Menu.Items["ClubsModule"].Items.Add(new MenuItem
            {
                InternalId = "Clubs",
                Name = "List",
                Route = "~/manager/clubs",
                Css = "fas fa-brain",
                // Policy = "MyCustomPolicy"
            });

            Menu.Items["ClubsModule"].Items.Add(new MenuItem
            {
                InternalId = "Heroes",
                Name = "Heroes",
                Route = "~/manager/heroes",
                Policy = Permissions.Heroes,
                Css = "fas fa-users"
            });

            App.Blocks.Register<Clubs>();
        }
    }
}