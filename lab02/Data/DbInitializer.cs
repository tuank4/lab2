using lab02.Models;
using Microsoft.EntityFrameworkCore;

namespace lab02.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Courses>(a =>
            {
                a.HasData(new Courses
                {
                    CId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                    CName = "J.K. Rowling",
                    Desciption = "Harry Potter's life is miserable. His parents are dead and he's stuck with his heartless relatives, who force him to live in a tiny closet under the stairs."
                });
                a.HasData(new Courses
                {
                    CId = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"),
                    CName = "Walter Isaacson",
                    Desciption = "Harry Potter's life is miserable. His parents are dead"
                });
            });

            _builder.Entity<Student>(b =>
            {
                b.HasData(new Student
                {
                    StId = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                    Name = "Harry Potter and the Sorcerer's Stone"
                });
                b.HasData(new Student
                {
                    StId = new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"),
                    Name = "Harry Chamber "
                });
                b.HasData(new Student
                {
                    StId = new Guid("150c81c6-2458-466e-907a-2df11325e2b8"),
                    Name = "Steve Jobs"
                });
            });
            _builder.Entity<StudentCourse>(c =>
            {
                c.HasData(new StudentCourse
                {
                    CId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                    StId = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb")
                });
                c.HasData(new StudentCourse
                {
                    CId = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"),
                    StId = new Guid("150c81c6-2458-466e-907a-2df11325e2b8")
                });

            });
        }
    }
}
