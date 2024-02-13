using spark_demo.Application.Models;
using Coravel.Events.Interfaces;

namespace spark_demo.Application.Events;


public class UserCreated : IEvent
{
    public User User { get; set; }

    public UserCreated(User user)
    {
        this.User = user;
    }
}
