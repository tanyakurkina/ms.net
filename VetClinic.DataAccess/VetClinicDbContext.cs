﻿using Microsoft.EntityFrameworkCore;
using VetClinic.DataAccess.Entities;

namespace VetClinic.DataAccess;

public class VetClinicDbContext : DbContext
{
    public VetClinicDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<Pet>().HasKey(x => x.Id);
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.User)
            .WithMany(u => u.Pets)
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<Role>().HasKey(x => x.Id);
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(Role => Role.Users)
            .HasForeignKey(p => p.RoleId);
        
        modelBuilder.Entity<Appointment>().HasKey(x => x.Id);
        modelBuilder.Entity<Appointment>() //со стороны много
            .HasOne(p => p.User)
            .WithMany(u => u.Appointments)
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<MedicalRecord>().HasKey(x => x.Id);
        modelBuilder.Entity<MedicalRecord>() //со стороны много
            .HasOne(p => p.Pet)
            .WithMany(u => u.MedicalRecords)
            .HasForeignKey(p => p.PetId);
        
        modelBuilder.Entity<Service>().HasKey(x => x.Id);
        modelBuilder.Entity<Service>() //со стороны много
            .HasOne(p => p.Appointment)
            .WithMany(u => u.Services)
            .HasForeignKey(p => p.AppointmentId);
        
        modelBuilder.Entity<Payment>().HasKey(x => x.Id);
        modelBuilder.Entity<Payment>() //со стороны много
            .HasOne(p => p.Appointment)
            .WithMany(u => u.Payments)
            .HasForeignKey(p => p.AppointmentId);
        
    }
}