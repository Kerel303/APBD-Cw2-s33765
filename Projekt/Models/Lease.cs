namespace Projekt;

public class Lease
{
    private int DefaultTimeToReturn = 14; // W dniach
    public Equipment Equipment { get; }
    DateTime LeaseDate;
    DateTime ExpiryDate;
    
    DateTime ReturnDate;

    private bool NoDueDate = false;// False z założenia

    public User Borrower { get; }
    
    Lease(Equipment equipment, User borrower)
    {
        this.Equipment = equipment;
        this.Equipment.Availibility = false;
        Borrower = borrower;
        LeaseDate = DateTime.Now;
        ExpiryDate = LeaseDate.AddDays(DefaultTimeToReturn);
    }
    
    Lease(Equipment equipment, User borrower, int DaysToReturn)
    {
        this.Equipment = equipment;
        this.Equipment.Availibility = false;
        Borrower = borrower;
        LeaseDate = DateTime.Now;
        if (DaysToReturn == 0)
        {
            NoDueDate = true;
        }
        else
        {
            ExpiryDate = LeaseDate.AddDays(DaysToReturn);
        }
    }


    public void Return()
    {
        ReturnDate = DateTime.Now;
        this.Equipment.Availibility = true;
        if (ReturnDate > ExpiryDate && !NoDueDate)
        {
            // Add Due
            calculateCosts();
        }
        
    }

    int calculateCosts()// opłata = 20 złotych za każdy dzień opóźnienia
    {
        TimeSpan timeSpan = ExpiryDate - ReturnDate;
        int costs = Rules.CostPerDay * timeSpan.Days;
        return costs;
    }
    
}