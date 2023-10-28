using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DataAccessLayerInjection
    {
        public static void ConfigureDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HHContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("API")));
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservedRoomRepository, ReservedRoomRepository>();
            services.AddScoped<IRoomPicturesRepository, RoomPictureRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
        }
    }
}
