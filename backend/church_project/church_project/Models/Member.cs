namespace church_project.Models;

public class Member
{
    public int Id { get; set; }
    public string Role { get; set; }
    public string Status { get; set; }
    public DateTime BaptismDate { get; set; }
    public string Admission { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime Birthdate { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string Occupation { get; set; }
  
    public int? ChurchId { get; set; }
    public virtual Church? Church { get; set; }


    
}