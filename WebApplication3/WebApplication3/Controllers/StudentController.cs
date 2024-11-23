using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        MyDb db = new MyDb();
        public IActionResult Add()
        {
            ViewBag.students = db.students.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(string std_name , string std_email)
        {
            var s1 = new Student();
            s1.std_name = std_name;
            s1.std_email = std_email;
            db.students.Add(s1);
            db.SaveChanges();
            TempData["mess"] = "Student Added";
            return RedirectToAction("Add");
        }

        public IActionResult Delete(int data)
        {
            var student = db.students.Where(x => x.std_id == data).First();
            db.students.Remove(student);
            db.SaveChanges();
            TempData["mess"] = "Student Deleted";
            return RedirectToAction("Add");
        }
        public IActionResult Update(int data)
        {
            ViewBag.students = db.students.ToList();
            var student = db.students.FirstOrDefault(x => x.std_id == data);
            if (student == null)
            {
                TempData["mess"] = "Student not found";
                return View("update");
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(int std_id, string std_name, string std_email)
        {
            var student = db.students.FirstOrDefault(x => x.std_id == std_id);
            if (student == null)
            {
                TempData["mess"] = "Student not found";
                return RedirectToAction("Add");
            }

       
            student.std_name = std_name;
            student.std_email = std_email;
            db.SaveChanges();

            ViewBag.Student = student;


            TempData["mess"] = "Student updated successfully";
            return View("Update", student); 
        }
    }
}
