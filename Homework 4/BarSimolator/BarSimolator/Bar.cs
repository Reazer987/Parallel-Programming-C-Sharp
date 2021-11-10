using System;
using System.Collections.Generic;
using System.Threading;

namespace DBarSimulator
{
    class Bar
    {
        private Random rnd = new Random();

        List<Student> students = new List<Student>();
        Semaphore semaphore = new Semaphore(10,10);

        public void Enter(Student student)
        {
            semaphore.WaitOne();

            int randomNum = rnd.Next(0, 10);
           
            
            lock (students)
            {
                students.Add(student);
            }
        }

        public void Leave(Student student)
        {
            lock (students)
            {
                students.Remove(student);
            }
            semaphore.Release();
        }
    }
}