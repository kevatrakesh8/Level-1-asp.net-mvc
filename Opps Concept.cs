 
 
 
 
 
 Pro1_IEmployee_Interface
 
 // what is the interface 
 //// interface method (does not have a body)(Totally public and abstract method)
// interface contains the properties , method, delegates or events. only declaration no implementation. 	
// interface class contains default type of  public and abstract method.
// when we inheritate the class of interface then we have to must call that all method
// We can not create object of interface (that is instantiated )but can only inhertate classes by other classes.
// interface cannot have field.
// public and abstract is modifire or memeber 
// if your are using more then one public then it called "explicit"
// implementing the class means inheriting the class 
using System;
			
interface IEmployee{               // int id = 10 .....we can not declare field.
	void show();                  // void is signature and this show() method is defalult public and abstract method.
}

class PartTimeEmployee : IEmployee
{
	public void show(){                                                  // this method should be defalut public modifier
	Console.WriteLine("this is the method of IEmployee interface !");	 // should be intialised some values.
	}
}
public class Program
{
	public static void Main()
	{
		PartTimeEmployee pte = new PartTimeEmployee();
		pte.show();		
		Console.ReadLine();
	 
	}
}


=================================================================================================
Pro2_One_Interface_inheritate_3_Class

using System;

interface IAniamalInterface          //we cannot implement object of interface.
{
 void Animalsound();      // we cannot intialized the value;
}

public class Dog : IAniamalInterface
{
	public void Animalsound()
	{
	 Console.WriteLine("The Dog Bark");    // we initialized the value here.
	}
}

public class Lion : IAniamalInterface
{
	public void Animalsound()
	{
	 Console.WriteLine("The Lion Roars");
	}
}
public class Tiger : IAniamalInterface
{
	public void Animalsound()
	{
	 Console.WriteLine("The makes Sound grrrr");
	}
}
public class InterfaceProgram
{
	public static void Main()
	{
		Dog dg = new Dog();	
		dg.Animalsound();
		
		Lion ln = new Lion();
		ln.Animalsound();
		
		Tiger tg = new Tiger();
		tg.Animalsound();
	}
}

=============================================================================================

Pro3_Two_Interface_Inherited_In_OneClass

using System;


interface IMobile
{
	void dualSim();
};

interface SmartPhone
{
	void Camera();
};

public class MobileFeature : IMobile , SmartPhone    // implement two interface.
{
	public void dualSim()
	{
	Console.WriteLine("this Device Support Two Sim");
	}
	
	public void Camera()
	{
	Console.WriteLine("this Device Support 24px Camera");
	}
}
 
public class Program
{
	public static void Main(string[] args)
	{
		MobileFeature mf = new MobileFeature();
		{
			mf.dualSim();
			mf.Camera();
		};
	}
}

==========================================================================================================

Pro4_abstact_method_in_Employee_Class

// abstract method : it is used only necessary and essential feature of an object to outside the word.
// asbstract method : Means Display only necessary and ecapsualte the unnecessary thing to the outside the World. Hidding can be achived "privte" access modifier.

using System;					

public class AEmployee{
	public int EmpId;
	public string EName;
	public double GrossPay;  //25000  // rent 5000 // convence allowance 4000
	double TaxDedection = 0.1;
	double NetSalary;
	
	public AEmployee(int EmpId, string EName, double Egrosspay){
		this.EmpId = EmpId;
		this.EName = EName;
		this.GrossPay = Egrosspay;
	}
	void CalculateSalary(){                           // this is hide private modifier 
		if( GrossPay >= 30000){                       // this is abstract method
			NetSalary = GrossPay -( TaxDedection * GrossPay);
			Console.WriteLine("Your Salary is {0}", NetSalary);
		}
		else{
			Console.WriteLine("Your Salary is {0}", GrossPay);
		}
	}
	public void ShowEmployee(){     
		this.CalculateSalary();      //this is abstract fuction 
	}
}

public class AbstractProgram{
	public static void Main(string[] args){
		AEmployee emp1 = new AEmployee(1,"Rakesh",80000);
		AEmployee emp2 = new AEmployee(1,"Rakesh",15000);
		emp1.ShowEmployee();
		emp2.ShowEmployee();
	}
}		
 

===================================================================================================

Pro5_AbstractClass _Person_teacher&Student

Abstraction in C# is the process to hide the internal details and showing only the functionality.

using System;
			

abstract class person                          // we cannot create object of  abstract class;
{
	public string FirstName;
	public string LastName;
	public int age;
	public long phoneNumber;
	public abstract void PrintDetails();	 // when  inherite this abstract call it will auto call this method in another class. 
}
class student : person {
	
    public int RollNo;
	public 	int Fees;
	
	public override void PrintDetails(){    // this method is must be called when you are inherited person abstract class
    string name = this.FirstName + "" + this.LastName;
	Console.WriteLine("Student Name is {0}",name);
	Console.WriteLine("Student Age is {0}",this.age);
	Console.WriteLine("Student Phone Number is {0}",this.phoneNumber);
	Console.WriteLine("Student Roll No is {0}",this.RollNo);
	Console.WriteLine("Student Fees is {0}",this.Fees);
		
	}	 	
}
class teacher : person{
	
	public string Qualification;
	public int Salary;
	
	public override void PrintDetails(){      // this method is must be called when you are inherited person abstract class	
	string name = this.FirstName + "" + this.LastName;
	Console.WriteLine("Teacher Name is {0}",name);
	Console.WriteLine("Teacher Age is {0}",this.age);
	Console.WriteLine("Teacher Phone Number is {0}",this.phoneNumber);
	Console.WriteLine("Teacher Qualification is {0}",this.Qualification);
	Console.WriteLine("Teacher Salary is {0}",this.Salary);
	
	}
}
public class Program
{
	public static void Main()
	{
		student st = new student();
		st.FirstName = "Rakesh";            //Assign the value in the project.
		st.LastName = "Kevat";
		st.age = 24;
		st.phoneNumber = 9152723040;
		st.RollNo = 245;
		st.Fees = 25000;
		st.PrintDetails();
		
		teacher te = new teacher();
		te.FirstName = "Seema";          // Assign the value in the teacher project.
		te.LastName = "Mam";
		te.age = 54;
		te.phoneNumber = 9324528712;
		te.Qualification = "Post Graduate";
		te.Salary = 50000;
		te.PrintDetails();
		
		
		
	}
}


===============================================================================================


Pro6_MethodOverLoading_Or_FunctionOverloading_AddMethod


// we can call Numbers of method as same name but parameter(Signature) Must be different. ex.
using System;

public class Method_Overloading
{
	public void Add()
	{
	int a = 20;
    int b = 30;
	int c = a + b;
	Console.WriteLine(c);
	}
		
	//public void Add()     //this will show error because paramer(Signature of the same)
	//{
	//int a = 20;
    //int b = 30;
	//int c = a+b;
	//Console.WriteLine(c);
	//}
	
	public void Add(int a , int b)   // it will be work difference parameter.
	{
	int c = a + b;
	Console.WriteLine(c);
	}
	
	public void Add(string a , string b)   // it will be work difference parameter.
	{
	string c = a +" "+ b;
	Console.WriteLine(c);
	}
	
	
	public void Add(float a , float b)   // it will be work difference parameter.
	{
	float c = a + b;
	Console.WriteLine(c);
	}
}

					
public class Program
{
	public static void Main()
	{
		Method_Overloading md = new Method_Overloading();         // method name should be same but parameter will be diffrent.
		md.Add();
		md.Add(10,20);
		md.Add("rakesh","kevat");
		md.Add(10.5f,20.5f);
	}
}


======================================================================================================================================
Pro7_MethodOverride_child_implementation_called 


// method override : there is not need to parameter and name of method change if it's same then also work.
// but in the methodoverride must have to (parent class as "vartual") and (child method must be "override") keyword 
using System;
public class parent{
	public virtual void print()
	{
		Console.WriteLine("This is the method of PARENT class");	
	}
}	

public class Child : parent {            //child is derived class 
	public override void print()
	{   
		//   base.print();                // it is used for called the parent method or hide the child override
		Console.WriteLine("This is the method of CHILD class");	
	}
}
public class Program
{
	public static void Main()
	{ 
		parent p = new Child();
		p.print();
		
		Child c = new Child();
		c.print();
	}
}


=========================================================================================================

Pro8_Ecapsulation

// avoid duplication variable again and again call used epasualtion.  
// Declare the variable of the class as Private.
//Provide 	public setter and getter method or property of modifier and view the variable values;

// The Field of the class can be made read-only or Write only.
//A class can be have total control over what is stored in its fields.
// for protect the direct used of variable we need to create ecapsulation. with the help of the function we can access that all variables .
using System;

class Person
{
	private string Name;
	private int Age;
	public void setName(string Name)
	{
		if(string.IsNullOrEmpty(Name) == true)
		{
			Console.WriteLine("Name is Required");
		}
		else
		{
			this.Name = Name;
		}
	}
	public void getName()
	{
		if(string.IsNullOrEmpty(this.Name) == true)
		{
		}
		else
		{			
			Console.WriteLine("Your Name is : " + this.Name);
		}
	}
	public void setAge( int Age)
	{
		if(Age > 0)
		{
			this.Age = Age;
		}
		else
		{
		  Console.WriteLine("Age Should be not negative or Zero : " + this.Age);	
		}
	}
	public void getAge()
	{
		if(Age > 0)
		{
			Console.WriteLine("Age Should be not negative or Zero : " + this.Age);
		}
		else
		{
		  	
		}
				
	}
}
					
public class Program
{
	public static void Main(string[] args)
	{
		Person p = new Person();
		
		p.setName("rakesh");
		p.getName();
		
		p.setAge(-27);
		p.getAge();
	}
}


==============================================================================================================================

            //-- What is different between function and method

            //    In programming langauages we have two concepts functions and methods. functions are defined in structural language and methods are defined in object oriented langauge. The difference between both is given below :

            //Functions
            //Functions have independent existence means they can be defined outside of the class. Ex:- main() function in C, C++ Language

            //Functions are defined in structured languages like Pascal, C and object-based language like javaScript

            //Functions are called independently.

            //Functions are a self-describing unit of code.

            //function main in C
            void main()
            {
             int a,b,c;
             a=5;
             b=6;
             c=a+b;
             printf("Sum is : %d",c);
            } 
            //Methods
            //Methods do not have independent existence they are always defined within a class. Ex:- main() method in C# Language that is defined within a class

            //Methods are defined in object-oriented languages like C#, Java

            //Methods are called using instance or object.

            //Methods are used to a manipulate the instance variable of a class.

             //method sum in C#
            class demo
            {
            int a,b,c;
            public void sum()
            {
             a=5;
             b=6;
             c=a+b;
             Console.WriteLine("Sum is : {0}",c);
             }
            } 


======================================================================================================================
 //What is difference between ViewBag and VieData and Tempdata Program

    ViewData Example 
   //Controller Code  
                        public ActionResult Index()  
                        {  
                              List<string> Student = new List<string>();  
                              Student.Add("Jignesh");  
                              Student.Add("Tejas");  
                              Student.Add("Rakesh");  
   
                              ViewData["Student"] = Student;  
                              return View();  
                        }  
                        //page code  
                        <ul>  
                            <% foreach (var student in ViewData["Student"] as List<string>)  
                                { %>  
                            <li><%: student%></li>  
                            <% } %>  
                        </ul> 



ViewBag Data : 
                    //Controller Code  
                    public ActionResult Index()  
                    {  
                          List<string> Student = new List<string>();  
                          Student.Add("Jignesh");  
                          Student.Add("Tejas");  
                          Student.Add("Rakesh");  
   
                          ViewBag.Student = Student;  
                          return View();  
                    }   
                    //page code  
                    <ul>  
                        <% foreach (var student in ViewBag.Student)  
                            { %>  
                        <li><%: student%></li>  
                        <% } %>  
                    </ul>


TempData Example : 
                    //Controller Code  
                public ActionResult Index()  
                {  
                    List<string> Student = new List<string>();  
                    Student.Add("Jignesh");  
                    Student.Add("Tejas");  
                    Student.Add("Rakesh");  
   
                    TempData["Student"] = Student;  
                    return View();  
                }  
                //page code  
                <ul>  
                    <% foreach (var student in TempData["Student"] as List<string>)  
                        { %>  
                    <li><%: student%></li>  
                    <% } %>  
                </ul> 



    
======================================================================================================================
 //What is difference between ViewBag and VieData and Tempdata
  //In Asp.Net MVC there are three ways to pass/store data between the controllers and views.

                
        ViewData => ViewData is used to pass data from controller to view
                    It is derived from ViewDataDictionary class
                    It is available for the current request only
                    Requires typecasting for complex data type and checks for null values to avoid error
                    If redirection occurs, then its value becomes null
                   
       ViewBag   => ViewBag is also used to pass data from the controller to the respective view
                    ViewBag is a dynamic property that takes advantage of the new dynamic features in C# 4.0
                    It is also available for the current request only
                    If redirection occurs, then its value becomes null
                    Doesn’t require typecasting for complex data type

       TempData  => TempData is derived from TempDataDictionary class
                    TempData is used to pass data from the current request to the next request
                    It keeps the information for the time of an HTTP Request. This means only from one page to another. It helps to maintain the data when we move from one controller to another controller or from one action to another action
                    It requires typecasting for complex data type and checks for null values to avoid error. Generally, it is used to store only one time messages like the error messages and validation messages
 
    
 ======================================================================================================================
// How to pass data one controller to another controller (one method to another method) 


  HomeController          : public ActionResult Index()  
                            {  
                            Customer data = new Customer()  
                            {  
                            CustomerID = 1,CustomerName = "Abcd",Country = "USA" };  
                            TempData["mydata"] = data;  
                            return RedirectToAction("Index", "Home2");  
                            }

MyHomeController            : public ActionResult Index()   
                            {  
                            Customer data = TempData["mydata"] as Customer;  
                            return View(data);  
                            }
                            
======================================================================================================================
// What is diff betweek tempData[""], tempData.keep(),  TempData.peek(); 
       Pass the limitation request from one method or controller to other.

                1>     TempData["value"] = "someValueForNextRequest";
                       //second request, read value and is marked for deletion
                       object value = TempData["value"];

                       //third request, value is not there as it was deleted at the end of the second request
                       TempData["value"] == null

                   2>           //second request, PEEK value so it is not deleted at the end of the request
                                object value = TempData.Peek("value");

                                //third request, read value and mark it for deletion
                                object value = TempData["value"];

                                      3>    //second request, get value marking it from deletion
                                            object value = TempData["value"];
                                            //later on decide to keep it
                                            TempData.Keep("value");

                                            //third request, read value and mark it for deletion
                                            object value = TempData["value"];

======================================================================================================================
//  What is difference between ID and name attributes 

                ID     :   The ID of a form Element nothing to do just an identification and nothing to do with the data contained within the element. 
                Name   :   The NAME attribute is used in the "HTTP request" sent by browser to the server as a variable name

======================================================================================================================
 
                                <input type="text" class="form-control" placeholder="First Name" value="" id="reg_firstname" name="reg_firstname" />
                                <div class="form-group">
                                        <select class="form-control" id="req_question" name="req_question" >
                                            <option class="hidden" selected disabled>Please select your Sequrity Question</option>
                                            <option value="3">What is your Birthdate?</option>
                                            <option value="2" >What is Your old Phone Number</option>
                                            <option value="1">What is your Pet Name?</option>
                                       </select>
                                </div>
                                <div class="form-group">
                                    <div class="maxl">
                                        <label class="radio inline">
                                           <input type="radio" name="reg_gender" value="male" >
                                            <span> Male </span>
                                        </label>
                                        <label class="radio inline">
                                           <input type="radio" name="reg_gender" value="female" >   // PASS THE VALUE HTTPOST
                                            <span>Female </span>
                                        </label>
                                    </div>
                                 </div>


======================================================================================================================
// What is app_start folder : 
    
                BundleConfig.RegisterBundles(BundleTable.Bundles);    // used for store   "Bootstrap and js file collection"
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);   // authentification types 
                RouteConfig.RegisterRoutes(RouteTable.Routes);       // used for find the rought of the data.


======================================================================================================================
// What is types of validator 
                 DataAnnotations” assembly has many built-in validation attributes, for example:
                Required.
                Range,
                RegularExpression,
                Compare.
                StringLength.
                Data type.
  
======================================================================================================================
//  
