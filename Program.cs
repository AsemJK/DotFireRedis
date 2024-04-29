using StackExchange.Redis;

namespace DotFireRedis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            WriteData();
            ReadData();
            app.Run();

        }

        public static void ReadData()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:8540");
            var db = redis.GetDatabase();
            var value = db.StringGet("name");
            Console.WriteLine(value);
        }
        public static void WriteData()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:8540");
            var db = redis.GetDatabase();
            db.StringSet("name", "DotFire");
        }
    }
}
