
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace Notification
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "notification-5207e-firebase-adminsdk-fbsvc-76062e5381.json");
            var credential = GoogleCredential.FromFile(path);
            var firebaseApp = FirebaseApp.Create(new AppOptions
            {
                Credential = credential
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
