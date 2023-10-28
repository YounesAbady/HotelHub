using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class BusinessLayerInjection
    {
        public static void ConfigureBL(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Branch));
            services.AddScoped<IBranch, Branch>();
            services.AddScoped<IRoomType, RoomType>();
            services.AddScoped<IRoom, Room>();
            services.AddScoped<IReservation, Reservation>();
            services.AddScoped<IRoomPictureServices, RoomPictureServices>();
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IReportServices, ReportServices>();
        }
    }
}
