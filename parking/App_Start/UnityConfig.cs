using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using AutoMapper;
using parking.Models.Domain;
using parking.Models.TOs;
using System.Data.Entity;

namespace parking.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            var autoMapperConfiguration = CreateMapperConfiguration();
            var mapper = autoMapperConfiguration.CreateMapper();

            // Inject AutoMapper - IMapper
            container.RegisterInstance<IMapper>(mapper);

            container.RegisterType<Context, Context>(new PerRequestLifetimeManager());
        }

        private static MapperConfiguration CreateMapperConfiguration()
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ParkingLot, ParkingLotForMap>();
                c.CreateMap<ParkingLotForMap, ParkingLot>();
            });

            return cfg;
        }
    }
}
