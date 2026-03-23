namespace Projekt;

public class Lease
{
    private int DefaultTimeToReturn = 14; // W dniach
    public Equipment Equipment { get; }
    public DateTime LeaseDate;
    public DateTime ExpiryDate;
    
    public DateTime? ReturnDate { get; set; }

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
        if (ReturnDate == null)
            return 0;
        TimeSpan timeSpan = ExpiryDate - ReturnDate.Value;
        int costs = Rules.CostPerDay * timeSpan.Days;
        return costs;
    }
    
}