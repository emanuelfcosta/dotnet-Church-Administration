namespace church_project.Models;

public class Church
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Responsible { get; set; }
    public string Website { get; set; }
    public string Type { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public DateTime Foundationdate { get; set; }
    public string Cnpj { get; set; }
    public string Phone { get; set; }
    
    public virtual ICollection<Member> Members { get; set; }
    
}