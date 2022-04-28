using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentClientClass studentClientClass = new StudentClientClass(new StudentService());
            /* Here the Service class (dependency of Client class) is 
             * being injected into the Client class */
            Console.ReadKey();
        }
    }


    /*public class Student
    {
        DataService dataService = new DataService();
        public void Get()
        {
            dataService.GetName();
        }
    }
    public class DataService
    {
        public void GetName()
        {

        }
    }*/
    /* Here is an example of tight-coupling
     in which the "Student" Class is dependent upon "DataService" class
    meaning, if we change the name/implementation of "GetName" function in "DataService"
    then, we will have to make the same change in the "Student" class as well. */


    
    /*The problem of tight-coupling can be solved with Dependency Injection*/
    /* We make 3 classes for Dependency Injection: 
      Client class, Service Class, Injector Class */

    //Client class: It is a class that depends on Service class
    public class StudentClientClass
    {
        private IDataService dataService;
        /*
          3 Types of Dependency Injections:
	        a. Constructor Dependency Injection
	        b. Method Dependency Injection
	        c. Setter Dependency Injection  
         */
        /* This is an example of "Constructor Dependency Injection" */
        public StudentClientClass (IDataService _dataService)
        {
            this.dataService = _dataService;
            this.dataService.GetName();
        }
    }

    //Service class: It is a class that provides service to Client class
    public class StudentService : IDataService
    {
        public void GetName()
        {
            Console.WriteLine("Student's Name:::");
        }
    }

    //Injector class: It injects the Service class object into Client class
    public interface IDataService
    {
        void GetName();
    }

}
