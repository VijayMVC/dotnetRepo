using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StudentManager.Data;
using StudentManager.Models;
using System.IO;

namespace SystemIO.Tests
{
    public class RepositoryTests
    {
        private const string _filepath = @"C:\Repos\dotnet-jake-ganser\Data\SystemIO\StudentTest.txt";
        private const string _originalData = @"C:\Repos\dotnet-jake-ganser\Data\SystemIO\StudentTestSeed.txt";

        [SetUp]
        public void setup()
        {
            if(File.Exists(_filepath))
            {
                File.Delete(_filepath);
            }
            File.Copy(_originalData, _filepath);
        }

        [Test]
        public void CanReadDataFromFile()
        {
            StudentRepository repo = new StudentRepository(_filepath);

            List<Student> students = repo.List();

            Assert.AreEqual(4, students.Count());

            Student check = students[2];

            Assert.AreEqual("Jane", check.FirstName);
            Assert.AreEqual("Doe", check.LastName);
            Assert.AreEqual("Computer Science", check.Major);
            Assert.AreEqual(4.0M, check.GPA);
        }

        [Test]
        public void CanAddStudentToFile()
        {
            StudentRepository repo = new StudentRepository(_filepath);

            Student newStudent = new Student();
            newStudent.FirstName = "Testy";
            newStudent.LastName = "Testerson";
            newStudent.Major = "Testing";
            newStudent.GPA = 4.0M;

            repo.Add(newStudent);

            List<Student> students = repo.List();

            Assert.AreEqual(5, students.Count());

            Student check = students[4];

            Assert.AreEqual("Testy", check.FirstName);
            Assert.AreEqual("Testerson", check.LastName);
            Assert.AreEqual("Testing", check.Major);
            Assert.AreEqual(4.0M, check.GPA);
        }

        [Test]
        public void canDeleteStudent()
        {
            StudentRepository repo = new StudentRepository(_filepath);
            repo.Delete(0);

            List<Student> students = repo.List();

            Assert.AreEqual(3, students.Count);

            Student check = students[0];

            Assert.AreEqual("Mary", check.FirstName);
            Assert.AreEqual("Jone", check.LastName);
            Assert.AreEqual("Business", check.Major);
            Assert.AreEqual(3.0M, check.GPA);
        }

        [Test]
        public void canEditStudent()
        {
            StudentRepository repo = new StudentRepository(_filepath);
            List<Student> students = repo.List();

            Student editedStudent = students[0];
            editedStudent.GPA = 3.0M;
            repo.Edit(editedStudent,0);

            

            Assert.AreEqual(4, students.Count);

            students = repo.List();
            Student check = students[0];

            Assert.AreEqual("Joe", check.FirstName);
            Assert.AreEqual("Smith", check.LastName);
            Assert.AreEqual("Computer Science", check.Major);
            Assert.AreEqual(3.0M, check.GPA);
        }
    }
}
