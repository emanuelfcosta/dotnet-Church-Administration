using church_project.Models;
using Microsoft.EntityFrameworkCore;

namespace church_project.Repositories;

public class SisChurchContext : DbContext
{
    public DbSet<Church> Churches { get; set; }
    public DbSet<Member> Members { get; set; }
    
    public DbSet<Study> Studies { get; set; }
    
    public DbSet<Occasion> Occasions { get; set; }
    
    public DbSet<Pray> Prayers { get; set; }
    
    public DbSet<Financial> Financials { get; set; }





    public SisChurchContext(DbContextOptions<SisChurchContext> options)
        : base(options)
    {
      
    }
  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();


    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Church>(entity =>
        {
            entity.HasKey(church => church.Id);


            entity.Property(church => church.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();


            entity.Property(church => church.Name)
                .HasColumnName("name");
          
            entity.Property(church => church.Responsible)
                .HasColumnName("responsible");
          
            entity.Property(church => church.Website)
                .HasColumnName("website");
          
            entity.Property(church => church.Type)
                .HasColumnName("type");
          
            entity.Property(church => church.Address)
                .HasColumnName("address");
          
            entity.Property(church => church.City)
                .HasColumnName("city");
          
            entity.Property(church => church.State)
                .HasColumnName("state");
          
            entity.Property(church => church.Foundationdate)
                .HasColumnName("foundationdate");
          
            entity.Property(church => church.Cnpj)
                .HasColumnName("cnpj");
          
            entity.Property(church => church.Phone)
                .HasColumnName("phone");
        });
        
        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(member => member.Id);


            entity.Property(member => member.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
  
            entity.Property(member => member.ChurchId)
                .HasColumnName("church_id");


            entity.HasOne(member => member.Church)
                .WithMany(church => church.Members)
                .HasForeignKey(member => member.ChurchId)
                .OnDelete(DeleteBehavior.SetNull);
  
            entity.Property(member => member.Role)
                .HasColumnName("Role");
  
            entity.Property(member => member.Status)
                .HasColumnName("Status");
  
            entity.Property(member => member.BaptismDate)
                .HasColumnName("BaptismDate");
  
            entity.Property(member => member.Admission)
                .HasColumnName("Admission");
  
            entity.Property(member => member.Name)
                .HasColumnName("Name");
  
            entity.Property(member => member.Gender)
                .HasColumnName("Gender");
  
            entity.Property(member => member.Birthdate)
                .HasColumnName("Birthdate");
  
            entity.Property(member => member.Address)
                .HasColumnName("Address");
  
            entity.Property(member => member.State)
                .HasColumnName("State");
  
            entity.Property(member => member.Occupation)
                .HasColumnName("Occupation");
            
        });
        
        modelBuilder.Entity<Study>(entity =>
        {
            entity.HasKey(study => study.Id);


            entity.Property(study => study.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
          
            entity.Property(study => study.TheDate)
                .HasColumnName("thedate");
          
            entity.Property(study => study.Subject)
                .HasColumnName("subject");
          
            entity.Property(study => study.Description)
                .HasColumnName("description");
          
            entity.Property(study => study.Notes)
                .HasColumnName("notes");


        });
        
        modelBuilder.Entity<Occasion>(entity =>
        {
            entity.HasKey(occasion => occasion.Id);


            entity.Property(occasion => occasion.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
          
            entity.Property(occasion => occasion.Name)
                .HasColumnName("name");
          
            entity.Property(occasion => occasion.Description)
                .HasColumnName("description");
          
            entity.Property(occasion => occasion.Start)
                .HasColumnName("start");
          
            entity.Property(occasion => occasion.End)
                .HasColumnName("end");


        });
        
           modelBuilder.Entity<Pray>(entity =>
               {
                   entity.HasKey(pray => pray.Id);
        
        
                   entity.Property(pray => pray.Id)
                       .HasColumnName("id")
                       .ValueGeneratedOnAdd();
                  
                   entity.Property(pray => pray.Reason)
                       .HasColumnName("reason");
                  
                   entity.Property(pray => pray.Description)
                       .HasColumnName("description");
                  
                   entity.Property(pray => pray.Priority)
                       .HasColumnName("priority");
                  
                   entity.Property(pray => pray.Status)
                       .HasColumnName("status");
        
        
               });
           
               modelBuilder.Entity<Financial>(entity =>
               {
                   entity.HasKey(financial => financial.Id);


                   entity.Property(financial => financial.Id)
                       .HasColumnName("id")
                       .ValueGeneratedOnAdd();
          
                   entity.Property(financial => financial.Type)
                       .HasColumnName("type");
          
                   entity.Property(financial => financial.Amount)
                       .HasColumnName("amount")
                       .HasColumnType("decimal(18,2)"); // <- Importante para dinheiro
          
                   entity.Property(financial => financial.TheDate)
                       .HasColumnName("thedate");
          
                   entity.Property(financial => financial.PaymentMethod)
                       .HasColumnName("paymentmethod");
          
                   entity.Property(financial => financial.Description)
                       .HasColumnName("description");


               });










    


        

    }

    
}