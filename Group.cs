using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp39
{
    public class Group
    {
        // композиция List<Student>
        List<Student> students = new();
        Special special;

        public Group()
        {// композиция ITSpecial
            special = new ITSpecial();
        }
        // агрегация Student
        public void AddStudent(Student student)
        {
            students.Add(student); 
        }
        
    }

    abstract class Special
    { 
    
    }

    class ITSpecial : Special
    { 
    
    }
}