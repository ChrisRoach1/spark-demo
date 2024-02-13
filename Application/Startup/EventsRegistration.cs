using spark_demo.Application.Events.Listeners;
using spark_demo.Application.Events;
using Coravel.Events.Interfaces;
using Coravel;

namespace spark_demo.Application.Startup;

public static class EventsRegistration
{
    public static IServiceProvider SetupEvents(this IServiceProvider services)
    {
        IEventRegistration registration = services.ConfigureEvents();

        // add events and listeners here
        registration
            .Register<UserCreated>()
            .Subscribe<EmailNewUser>();

        return services;
    }
}
