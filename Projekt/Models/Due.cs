namespace Projekt.Models;

public class Due
{
    public User user { get; }
    public double amount { get; }
    Due(User user, double ammount)
    {
        this.user = user;
        this.amount = ammount;
    }
}