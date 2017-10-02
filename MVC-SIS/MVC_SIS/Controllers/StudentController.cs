﻿using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var s = StudentRepository.Get(id);
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());
            viewModel.Student = s;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM aStudent)
        {
            if (ModelState.IsValid)
            {
                aStudent.SelectedCourseIds =
                aStudent.CourseItems.Where(c => c.Selected).Select(c => int.Parse(c.Value)).ToList();

                aStudent.Student.Courses = new List<Course>();

                foreach (var id in aStudent.SelectedCourseIds)
                    aStudent.Student.Courses.Add(CourseRepository.Get(id));

                aStudent.Student.Major = MajorRepository.Get(aStudent.Student.Major.MajorId);
                aStudent.Student.Address.State = StateRepository.Get(aStudent.Student.Address.State.StateName);

                StudentRepository.Edit(aStudent.Student);

                return RedirectToAction("List");
            }
            else
            {
                var s = StudentRepository.Get(aStudent.Student.StudentId);
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                viewModel.SetStateItems(StateRepository.GetAll());
                viewModel.Student = s;

                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var s = StudentRepository.Get(id);
            return View(s);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student aStudent)
        {
            StudentRepository.Delete(aStudent.StudentId);
            return RedirectToAction("List");
        }
    }
}