namespace Maiguard.API.Configuration
{
    public static class ApplicationConfigurator
    {
        public static void ConfigureApp(WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}