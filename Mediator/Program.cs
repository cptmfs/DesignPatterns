using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
     class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator= new Mediator();  

            Teacher engin= new Teacher(mediator);
            engin.Name = "Engin";
            mediator.Teacher= engin;
            Student ferit = new Student(mediator);
            ferit.Name = "Ferit";
            Student seyma = new Student(mediator);
            seyma.Name = "Şeyma";
            mediator.Students = new List<Student> { ferit,seyma };
            engin.SendNewImageUrl("slide1.jpg");
            engin.ReceiveQuestion("is it true?", seyma);
            Console.ReadLine();
        }
    }

   abstract class CourseMember
    {
        protected Mediator Mediator;
        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void ReceiveQuestion(string question, Student stundet)
        {
            Console.Write("Teacher received a question from {0},{1}",stundet.Name,question);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion (string answer,Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name, answer);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string  Name { get;  set; }

        internal void ReceiveImage(string url)
        {
            Console.WriteLine("{1} received image : {0}",url,Name);
        }

        internal void ReceiveAnswer(string answer)
        {
            Console.WriteLine("{1} received answer : {0}",answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }
        public void SendQuestion(string question,Student student)
        {
            Teacher.ReceiveQuestion(question,student);
        }
        public void SendAnswer(string answer,Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }

}
