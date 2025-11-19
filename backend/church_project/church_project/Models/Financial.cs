namespace church_project.Models;

public class Financial
{
    public int Id { get; set; }
  
    public string Type { get; set; }
  
    public decimal Amount { get; set; }
  
    public DateTime TheDate { get; set; }
  
    public string PaymentMethod { get; set; }
  
    public string Description { get; set; }
    
}