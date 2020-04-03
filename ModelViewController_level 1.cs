1. Show view to view DropdownList.

    index.cshtml:=

    Html.DropDownList("Department",
                       new List<SelectListItem> { new SelectListItem {  Text= "IT", Value = "1",Selected =true },
                                                 new SelectListItem {  Text= "Hr", Value = "2"},
                                                 new SelectListItem {  Text= "PayRoll", Value = "3" }
                                                 },
                       "Select Department")
==================================================================================================================================
    
2. Pass the "DropDownList" data Controller to View.
    HomeController:=

      TestEntities1 db = new TestEntities1();     //database connection
        public ActionResult Index()
        {
            ViewBag.CtrToViewDepartment = new SelectList(db.departmentDbs, "dep_id", "dep_name");

            return View();
        }

       index.cshtml
       @Html.DropDownList("CtrToViewDepartment","Select Department") 
Note : Add Department table in our project model folder Ado.netEntity with two column ("dep_id" &""dep_name)











===================================================================================================================


        public class DropdownListController : Controller
    {
        TestEntities1 db = new TestEntities1();
        // GET: DropdownList
        public ActionResult Index()
        {

            ViewBag.CountryList = new SelectList(GetCountryList(), "Country_id", "Country_name");                
             return View();
        }
        public List<country> GetCountryList()
        { 
            List<country> countries = db.countries.ToList();
            return countries;
        }
        //public List<country> GetStateList(int country_id)
        //{
           
        //    List<state>
        //selectList = db.states.Where(x => x.country_id == country_id).ToList();
        //    return country;
        //    ViewBag.StateList = new SelectList(selectList, "state_id", "state_name");
        //    return PartialView("DisplayState");
        //} 
    }
}


======================================================================================================
    
    @if (ViewBag.CountryList != null)
{
    @Html.DropDownListFor(m => m.Cnty_id, ViewBag.CountryList as SelectList, "Select Country Name --", new { @class = "form-control" })
}

==============================================================================================
 Pass the method in View*();

                    public class CustomerController : Controller     // Practical 4 
                    {
                        // customer/SingleCUstomerData 
                        public ActionResult SingleCUstomerData()
                        {
                            CustomerBal b = new CustomerBal();           //invoke all data from "CustomerBal" to "b"
                            Customer c = b.GetCustomer();                // Pass the "b.GetCustomer" Data to "c"
                            ViewBag.CustomerData = c;                    // pass all customer data of "c" to "ViewBag.CustomerData"
                            return View("SingleCustomerDataView");
                        }
                    }  


@{
    Layout = null;
}

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>SingleCustomerDataView</title>
</head>
<body>
<div>
    Customer Name : @ViewBag.CustomerData.CustomerName
    Customer Address : @ViewBag.CustomerData.Address
    Customer Age : @ViewBag.CustomerData.Age
</div>
</body>
</html>

        

       // 
                        public string MyFirstMethod()                      //Practical 1
                        {
                            return "This is my first string method";
                        }
                                     // https://localhost:44348/Home/myvalue
                                      //   OutPut : this is rakesh

                        // EmployeeFunction/MyFirstViewMethod
                        public ActionResult MyFirstViewMethod()            //Practical 2
                        {
                            return View("MyFirstView");
                        }

            
                        // EmployeeFunction/MySecondtViewMethod
                        public ActionResult MySecondtViewMethod()            //Practical 3
                        {
                            string CustomerName = "Mr. Vbm";
                            ViewData["MyData"] = CustomerName;
                            ViewBag.MyData = CustomerName;
                            return View("MySecondView");
                        }

                            


                        //  Do the program find the even and odd number 
                        // EmployeeFunction/EvenAndOddNumber
                        public ActionResult EvenAndOddNumber()
                        {
                            return View();
                        }
                        [HttpPost]
                        public ActionResult EvenAndOddNumber(EmployeeModel employeemodel)
                        {
                            ViewBag.empmod = employeemodel;
                            return View();
                        } 
                                           
                                       
                                //EvenAndOddNumber.cshtml
                                           <div>
                                                if (ViewBag.empmod % 2 ==0 )
                                                {
                                                <h2>this is even number </h2>
                                                } 
                                                else
                                                {
                                                <h2>this is odd number </h2>
                                                }
                                            </div>


==============================================================================================
 


						namespace DropDownHelper.Controllers
						{
							public class HomeController : Controller
							{
								public ActionResult Index()
								{
									return View();
								}

								public ActionResult About() 
								{
									ViewBag.Message = "Your application description page.";

									return View();
								}

								public ActionResult Contact()
								{
									ViewBag.Message = "Your contact page.";

									return View();
								}

								public ActionResult Test()
								{
									var list = new List<string>() {"India", "Janan", "Us", "Uk","China"};
									ViewBag.list = list;

									Employee emp = new Employee()
									{
										Country = "China"
									};
									return View(emp); 									
													//test.cshtml
													<div class="col-md-10">
														@Html.DropDownListFor(model => model.Country, new SelectList(ViewBag.list),"Select Your Country", new { @class = "form-control"} )
														@*@Html.EditorFor(model => model.Country, new {htmlAttributes = new {@class = "form-control"}})*@
														@Html.ValidationMessageFor(model => model.Country, "", new {@class = "text-danger"})
													</div>
								}
								[HttpPost]
								public ActionResult Test(Employee emp)
								{
									if (ModelState.IsValid)
									{
										return RedirectToAction("Test"); 
									}
								   
									var list = new List<string>() { "India", "Janan", "Us", "Uk" };
									ViewBag.list = list;
									return View();
								}




								public ActionResult TestTwo()
								{
									var countries = new List<Country>
									{
										new Country { Id = 1, Name = "India"},
										new Country { Id = 1, Name = "China"},
										new Country { Id = 1, Name = "UK"},
										new Country { Id = 1, Name = "US"}
									};

									ViewBag.list = countries;

									Employee emp = new Employee()
									{
										CountryTwo = 1
									};

									return View(emp);
								}
												//TestTwo.cshtml								
												<div class="col-md-10">
													@Html.DropDownListFor(model => model.Country, new SelectList(ViewBag.list,"Id","Name"), "Select Your Country" , new { @class = "form-control" })
													@*@Html.EditorFor(model => model.Country, new {htmlAttributes = new {@class = "form-control"}})*@
													@Html.ValidationMessageFor(model => model.Country, "", new { @class = "text-danger" })
												</div>
								[HttpPost]
								public ActionResult TestTwo(Employee emp)
								{
									if (ModelState.IsValid)
									{
										return RedirectToAction("Test");
									}

									var countries = new List<Country>
									{
										new Country { Id = 1, Name = "India"},
										new Country { Id = 1, Name = "China"},
										new Country { Id = 1, Name = "UK"},
										new Country { Id = 1, Name = "US"}
									};
									ViewBag.list = countries;
									return View();
								}

								class Country
								{
									public int Id { get; set; }
									public string Name { get; set; }
								}
							}
						}
						
						
						

==============================================================================================
 

namespace DropdownProject.Controllers
{
    public class HomeController : Controller
    {
        TestEntities db = new TestEntities(); 
        // GET: Home
        public ActionResult Index()
        {
            List<country> AllCountry = db.countries.ToList();
            ViewBag.AllCountry = new SelectList(AllCountry, "country_id", "country_name");
            return View();
        }

        public JsonResult GetstateList(int CountryId) 
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<state> AllState = db.states.Where(x=>x.country_id == CountryId).ToList();
            return Json(AllState, JsonRequestBehavior.AllowGet);
        }
    }
}   
				// Home.cshtml
				@model DropdownProject.Models.model

				@{
					ViewBag.Title = "Index";
				}

				 
				<div class="container">
					<div class="form-group">
						@if (ViewBag.AllCountry != null)
						{
							@Html.DropDownListFor(x=>x.CountryId,ViewBag.AllCountry as SelectList,"-- Select Country List--",new {@class ="form-control"})
						}
					</div>
					<div>
						@Html.DropDownListFor(x => x.StateId,new SelectList(""),"-- Select State List--", new { @class = "form-control" })
				   </div>
					
				</div>
				<script src="~/Scripts/jquery-3.3.1.min.js"></script>

				<script>
					$(document).ready(function () {
						$("#CountryId").change(function () {
							$.get("/Home/GetstateList", { CountryId: $("#CountryId").val() }, function(data) {
								$.each(data, function (index, row) {
									$("StateId").append("<option value ='" + row.state_id + "'>" + row.state_name + "</option>")
								});
							});
						})
					});

				</script>
				
				

===============================================================================================================

namespace jQueryAjaxInAsp.NETMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll() 
        {
            return View(GetAllEmployee());
        }

        IEnumerable<Employee> GetAllEmployee() 
        {
            using (DbModel db = new DbModel())
            {
                return db.Employees.ToList<Employee>();
            }
        }

        public ActionResult AddorEdit(int id=0)
        {
            Employee emp = new Employee();
            if (id != 0)
            {
                using (DbModel db = new DbModel())
                {
                    emp = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddorEdit(Employee emp)
        {
            try
            {

                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                using (DbModel db = new DbModel())
                {
                    if (emp.EmployeeID == 0)
                    {
                        db.Employees.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
               return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
=============
@model jQueryAjaxInAsp.NETMVC.Models.Employee

@{
    ViewBag.Title = "AddorEdit";
    Layout = null;
}

@using (Html.BeginForm("AddorEdit","Employee",FormMethod.Post,new { enctype ="multipart/form-data", onSubmit = "return jQueryAjaxPost(this);",data_restUrl = Url.Action("AddorEdit","Employee",new { id = 0}) }))//data-resetUrl
{
	<div class="col-md-10">
		<img src="@Url.Content(Model.ImagePath)" style="margin:10px" height="200" width="200" id="imagePreview" />
		<input type="file" name="ImageUpload" value="" accept="image/jpeg, image/png" onchange="ShowImagePreview(this,document.getElementById('imagePreview'))" />                        
	</div>
	
}

==============
@{
    ViewBag.Title = "Index";
}

<ul class="nav nav-tabs">
    <li ><a data-toggle="tab" href="#firstTab">View All</a></li>
    <li class="active"><a data-toggle="tab" href="#secondTab">Add New</a></li>    
</ul>
<div class="tab-content">
    <div id="firstTab"class="tab-pane fade in">@Html.Action("ViewAll")</div>
    <div id="secondTab" class="tab-pane fade in active">@Html.Action("AddorEdit")</div> 
</div>     

@*if field is blank then you are going to click submit button then it will show Validation error*@

@section  scripts{
    @Scripts.Render("~/bundles/jqueryval")
} 

===========
@model IEnumerable<jQueryAjaxInAsp.NETMVC.Models.Employee>

@{
    ViewBag.Title = "ViewAll";
} 
<table class="table table-striped table-condensed">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.Name)
        </th>
	</tr>	
	
	@foreach (var item in Model) {
			<tr>
				<td>
					@Html.DisplayFor(modelItem => item.Name)
				</td>
			</tr>
		}

</table>
=============
function ShowImagePreview(ImageUploader, previewImage ) {
    if (ImageUploader.files && ImageUploader.files[0]){
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(ImageUploader.files[0])  
    }
}

function jQueryAjaxPost(form)
{
    $.validator.unobtrusive.parse(form);
    if ($(form).valid())
    {                       
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                if (response.success) {
                    $("#firstTab").html(responce.html)
                    refreshAddNewTab($(form).attr('data-restUrl'), true);
                    // success message from notify.js file
                    $.notify(responce.message, "success");
                }
                else
                {   
                    //error message
                    $.notify(responce.message, "error");
                }
            }    
        }
        if($(form).attr('enctype') == "multipart/form-data"){   
                ajaxConfig["contentType"] = false;
                ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);        
    }
    return false;
}

function refreshAddNewTab(resetUrl,showViewTab) {
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (responce) {
            $("#secondTab").html(responce);
            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
            if (showViewTab) {
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
            }
        }
    });
}

function Edit(url) {
    $.ajax({
        type:'GET', 
        url :url,
        success: function (responce) {
            $("#secondTab").html(responce);
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');           
            $('ul.nav.nav-tabs a:eq(1)').tab('show');            
        }
    });
}
    


 ==================================================================================
namespace MovieCustomers.Controllers
{
    public class MoviesDataController : Controller
    {
        // GET: MoviesData
        public ActionResult Movies()
        {

            var movie = new List<Movie>
            {
                new Movie{ Name = "The Dark Night"},
                new Movie{ Name ="Hunted House"}
            };

            var movies = new MovieCustomer
            {
                Movies = movie
            };
            return View(movies);
        }

        public ActionResult Customers()
        {

            var customer = new List<Customer>
            {
                new Customer{ Name = "Tylor Droff"},
                new Customer{ Name ="Helmon Horff"}
            };

            var customers = new MovieCustomer
            {
                Customers = customer
            };
            return View(customers);
        }
    }

}

=====
@using System.Security.Cryptography
@using MovieCustomers.Models

@{
    ViewBag.Title = "Customers";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Customer List</h2>
 

@{
    if(Model.Customers.Count == 0)
    {
        <h2> Customer Not Found</h2>
    }
    else 
    {

        foreach (var customer in Model.Customers)
        {
            <li>@customer.Name</li>
        }

    }

}

@using MovieCustomers.Models
@model MovieCustomers.MovieCustomerModel.MovieCustomer
@{
    ViewBag.Title = "Movies";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Movies List</h2> 
@{
    if (Model.Movies.Count == 0)
    {
        <h2> Movies Not Found</h2>
    }
    else
    { 
        foreach (var movie in Model.Movies)
        {
            <li>@movie.Name</li>
        }
    }
}


========================================================================================


using MyLoginForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyLoginForm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        xallerEntities db = new xallerEntities();
        public ActionResult Mylogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Mylogin(LoginaMdl model)
        {
            string myuser = model.user_username;
            string pass = model.password;

            using (db)
            {
                string status;
                var usr = (from e in db.login_tbl where e.user_username == myuser && e.password == pass select e).FirstOrDefault();
                //select * from login_tbl where user_username = user and passw
                if (myuser !=  null)
                {
                    Session["MyUser"] = usr.user_username.ToString();
                    status = "1";
                }
                else
                {
                    status = "3";
                }
                return new JsonResult { Data = new { status = status } };
            }

            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Mylogin", "Login");
        }
        public ActionResult Login2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login2(Registrationmdl regmdl)
        {
            return View();
        }

        public ActionResult Login3()
        {

            var myQuestion = db.registration_question.ToList();
            ViewBag.MyQestion = new SelectList(myQuestion, "question_id", "question_ask");
            return View();
        }
        [HttpPost]
        public ActionResult Login3(Registrationmdl regmdl)
        {
            return View();
        }
        public ActionResult login4()
        {             
            return View();
        }
        [HttpPost]
        public ActionResult login4(Registrationmdl regmdl)
        {
            return View();
        }
    }
}
 
 ============
 
 
 @model MyLoginForm.Models.Registrationmdl
@{
    ViewBag.Title = "Login2";
    Layout = "~/Views/Shared/_LayoutRegister.cshtml";



}

<div class="container register">
    <div class="row">
        <div class="col-md-3 register-left">
            <img src="https://image.ibb.co/n7oTvU/logo_white.png" alt="" />
            <h3>Grant Program Registration</h3>
            <p>Welcome to the Tech for Web development Application</p>
            <input type="submit" name="" value="Login" onclick="login()" /><br />
        </div>
        <div class="col-md-9 register-right">
            <ul class="nav nav-tabs nav-justified" id="myTab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Employee</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Hirer</a>
                </li>
            </ul>
            <form id="frm-registration" name="frm-registration">
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                        <h3 class="register-heading">Student Registration Form</h3>
                        <div class="row register-form">
                            <div class="col-md-6">
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_firstname, new { htmlAttributes = new {@class="form-control", placeholder = "First Name" } })
                                     @*<input type="text" class="form-control" placeholder="First Name" value="" id="reg_firstname" name="reg_firstname" />*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_lastname, new { htmlAttributes = new {@class="form-control", placeholder = "Last Name" } })
                                    @*<input type="text" class="form-control" placeholder="Last Name *" value="" id="reg_lastname" name="reg_lastname" />*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_password, new { htmlAttributes = new {@class="form-control", placeholder = "Password" } })
                                    @*<input type="password" class="form-control" placeholder="Password *" value="" id="reg_password" name="reg_password" />*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_confirmpassword,new { htmlAttributes = new {@class="form-control", placeholder = "Confirm Password" } })
                                    @*<input type="password" class="form-control" placeholder="Confirm Password *" value="" id="reg_confirmpassword" name="reg_confirmpassword" />*@
                                </div>
                                <div class="form-group">
                                    <div class="maxl" name="reg_gender">
                                        <label class="radio inline">
                                            @Html.RadioButtonFor(model => Model.reg_gender,"Male", new { htmlAttributes = new {@class="form-control", placeholder = "Last Name",name ="gender" } })
                                            @*<input type="radio" name="gender" value="male" id="reg_gender">*@
                                            <span> Male </span>
                                        </label>
                                        <label class="radio inline">
                                            @Html.RadioButtonFor(model => model.reg_gender, "Female", new { htmlAttributes = new {@class="form-control", placeholder = "Last Name",name ="gender" } })
                                            @*<input type="radio" name="gender" value="female" id="reg_gender">*@
                                            <span>Female </span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_email, new { htmlAttributes = new { @class="form-control", placeholder = "Your Email"} })
                                    @*<input type="email" class="form-control" placeholder="Your Email *" value="" id="reg_email" = name="reg_email" />*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(modle => Model.reg_phone, new {htmlattributes = new{@class ="form-control", placeholder ="Your Phone"}})
                                    @*<input type="text" minlength="10" maxlength="10" name="reg_phone" class="form-control" placeholder="Your Phone *" value="" id="reg_phone" />*@
                                </div>
                                <div class="form-group">
                                    @Html.DropDownListFor(model => model.req_question, ViewBag.MyQestion as SelectList, "-- Select country __", new { @class = "form-control" })
                                    @*<select class="form-control" id="req_question" >
                                        <option class="hidden" selected disabled>Please select your Sequrity Question</option>
                                        <option value="3">What is your Birthdate?</option>
                                        <option value="2" >What is Your old Phone Number</option>
                                        <option value="1" id="req_question">What is your Pet Name?</option>
                                    </select>*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(model =>model.req_answer, new{ htmlattributes = new{@class= "form-control", placeholder= "Enter Your Answer" }})
                                    @*<input type="text" class="form-control" placeholder="Enter Your Answer *" value="" id="req_answer" name="req_answer"/>*@
                                </div>
                                <input type="button" class="btnRegister" value="Register" onclick="Registration()" />
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>


@section scripts{
    <script src="~/Scripts/jquery-3.3.1.js"></script>
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <script>

        var status = null;

        function Registration()
        {
            var data = $("#frm-registration").serialize();
            var mydata = data;

            $.ajax({
                type: 'post',
                url: '/Login/Login3',
                data: data,
                dataType: 'JSON',
                success: function (data)
                {
                    status = data.status
                    if (status == 1) {
                        window.location.href = '@Url.Action("Index","Home")';
                    }
                    else if (status == 3)
                    {
                        $('#err').hide().html("User name and password do not blank").fadeIn('slow');
                    }
                }
            });
        }
    </script>

}
 
 
 
 =======================Way 2
 @model MyLoginForm.Models.Registrationmdl
@{
    ViewBag.Title = "Login2";
    Layout = "~/Views/Shared/_LayoutRegister.cshtml";



}

<div class="container register">
    <div class="row">
        <div class="col-md-3 register-left">
            <img src="https://image.ibb.co/n7oTvU/logo_white.png" alt="" />
            <h3>Grant Program Registration</h3>
            <p>Welcome to the Tech for Web development Application</p>
            <input type="submit" name="" value="Login" onclick="login()" /><br />
        </div>
        <div class="col-md-9 register-right">
            <ul class="nav nav-tabs nav-justified" id="myTab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Employee</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Hirer</a>
                </li>
            </ul>
            <form id="frm-registration" name="frm-registration">
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                        <h3 class="register-heading">Student Registration Form</h3>
                        <div class="row register-form">
                            <div class="col-md-6">
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_firstname, new { htmlAttributes = new {@class="form-control", placeholder = "First Name" } })
                                     @*<input type="text" class="form-control" placeholder="First Name" value="" id="reg_firstname" name="reg_firstname" />*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_lastname, new { htmlAttributes = new {@class="form-control", placeholder = "Last Name" } })
                                    @*<input type="text" class="form-control" placeholder="Last Name *" value="" id="reg_lastname" name="reg_lastname" />*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_password, new { htmlAttributes = new {@class="form-control", placeholder = "Password" } })
                                    @*<input type="password" class="form-control" placeholder="Password *" value="" id="reg_password" name="reg_password" />*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_confirmpassword,new { htmlAttributes = new {@class="form-control", placeholder = "Confirm Password" } })
                                    @*<input type="password" class="form-control" placeholder="Confirm Password *" value="" id="reg_confirmpassword" name="reg_confirmpassword" />*@
                                </div>
                                <div class="form-group">
                                    <div class="maxl" name="reg_gender">
                                        <label class="radio inline">
                                            @Html.RadioButtonFor(model => Model.reg_gender,"Male", new { htmlAttributes = new {@class="form-control", placeholder = "Last Name",name ="gender" } })
                                            @*<input type="radio" name="gender" value="male" id="reg_gender">*@
                                            <span> Male </span>
                                        </label>
                                        <label class="radio inline">
                                            @Html.RadioButtonFor(model => model.reg_gender, "Female", new { htmlAttributes = new {@class="form-control", placeholder = "Last Name",name ="gender" } })
                                            @*<input type="radio" name="gender" value="female" id="reg_gender">*@
                                            <span>Female </span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    @Html.EditorFor(model => model.reg_email, new { htmlAttributes = new { @class="form-control", placeholder = "Your Email"} })
                                    @*<input type="email" class="form-control" placeholder="Your Email *" value="" id="reg_email" = name="reg_email" />*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(modle => Model.reg_phone, new {htmlattributes = new{@class ="form-control", placeholder ="Your Phone"}})
                                    @*<input type="text" minlength="10" maxlength="10" name="reg_phone" class="form-control" placeholder="Your Phone *" value="" id="reg_phone" />*@
                                </div>
                                <div class="form-group">
                                    @Html.DropDownListFor(model => model.req_question, ViewBag.MyQestion as SelectList, "-- Select country __", new { @class = "form-control" })
                                    @*<select class="form-control" id="req_question" >
                                        <option class="hidden" selected disabled>Please select your Sequrity Question</option>
                                        <option value="3">What is your Birthdate?</option>
                                        <option value="2" >What is Your old Phone Number</option>
                                        <option value="1" id="req_question">What is your Pet Name?</option>
                                    </select>*@
                                </div>
                                <div class="form-group">
                                    @Html.EditorFor(model =>model.req_answer, new{ htmlattributes = new{@class= "form-control", placeholder= "Enter Your Answer" }})
                                    @*<input type="text" class="form-control" placeholder="Enter Your Answer *" value="" id="req_answer" name="req_answer"/>*@
                                </div>
                                <input type="button" class="btnRegister" value="Register" onclick="Registration()" />
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>


@section scripts{
    <script src="~/Scripts/jquery-3.3.1.js"></script>
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <script>

        var status = null;

        function Registration()
        {
            var data = $("#frm-registration").serialize();
            var mydata = data;

            $.ajax({
                type: 'post',
                url: '/Login/Login3',
                data: data,
                dataType: 'JSON',
                success: function (data)
                {
                    status = data.status
                    if (status == 1) {
                        window.location.href = '@Url.Action("Index","Home")';
                    }
                    else if (status == 3)
                    {
                        $('#err').hide().html("User name and password do not blank").fadeIn('slow');
                    }
                }
            });
        }
    </script>

}

==================way 3
 
@{
    ViewBag.Title = "Login2";
    Layout = "~/Views/Shared/_LayoutRegister.cshtml";



}

<div class="container register">
    <div class="row">
        <div class="col-md-3 register-left">
            <img src="https://image.ibb.co/n7oTvU/logo_white.png" alt="" />
            <h3>Grant Program Registration</h3>
            <p>Welcome to the Tech for Web development Application</p>
            <input type="submit" name="" value="Login" onclick="login()" /><br />
        </div>
        <div class="col-md-9 register-right">
            <ul class="nav nav-tabs nav-justified" id="myTab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Employee</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Hirer</a>
                </li>
            </ul>
            <form id="frm-registration" name="frm-registration">
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                        <h3 class="register-heading">Student Registration Form</h3>
                        <div class="row register-form">
                            <div class="col-md-6">
                                <div class="form-group">

                                 <input type="text" class="form-control" placeholder="First Name *" value="" id="reg_firstname" name="reg_firstname" />
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" placeholder="Last Name *" value="" id="reg_lastname" name="reg_lastname" />
                                </div>
                                <div class="form-group">
                                    <input type="password" class="form-control" placeholder="Password *" value="" id="reg_password" name="reg_password" />
                                </div>
                                <div class="form-group">
                                    <input type="password" class="form-control" placeholder="Confirm Password *" value="" id="reg_confirmpassword" name="reg_confirmpassword" />
                                </div>
                                <div class="form-group">
                                    <div class="maxl"  name="reg_gender">
                                        <label class="radio inline" >
                                            <input type="radio" name="gender" value="male" id="reg_gender">
                                            <span> Male </span>
                                        </label>
                                        <label class="radio inline">
                                            <input type="radio" name="gender" value="female"id="reg_gender">
                                            <span>Female </span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <input type="email" class="form-control" placeholder="Your Email *" value="" id="reg_email" name="reg_email" />
                                </div>
                                <div class="form-group">
                                    <input type="text" minlength="10" maxlength="10" name="reg_phone" class="form-control" placeholder="Your Phone *" value="" id="reg_phone" />
                                </div>
                                <div class="form-group" id="req_question">
                                    <select class="form-control">
                                        <option class="hidden" selected disabled>Please select your Sequrity Question</option>
                                        <option value="3">What is your Birthdate?</option>
                                        <option value="2">What is Your old Phone Number</option>
                                        <option value="1" id="req_question">What is your Pet Name?</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" placeholder="Enter Your Answer *" value="" id="req_answer" name="req_answer" />
                                </div> 
                                <input type="button" class="btnRegister" value="Register" onclick="Registration()" />
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div> 
@section scripts{
    <script src="~/Scripts/jquery-3.3.1.js"></script>
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <script>

        var status = null;

        function Registration()
        {            
            var data = $("#frm-registration").serialize();
            var mydata = data; 

            $.ajax({
                type: 'post',
                url: '/Login/Login2',
                data: data,
                dataType: 'JSON',
                success: function (data)
                {
                    status = data.status
                    if (status == 1) {
                        window.location.href = '@Url.Action("Index","Home")';
                    }
                    else if (status == 3)
                    {
                        $('#err').hide().html("User name and password do not blank").fadeIn('slow');
                    }
                }
            });
        }
    </script>

}

===========================================================================================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreProcedurePracticle.Models;

namespace StoreProcedurePracticle.Controllers
{
    public class studentsController : Controller
    {
        private TestEntities db = new TestEntities();
        private TestEntities sqldb = new TestEntities();

        // GET: students

        public ActionResult mylist()
        {
            return View();
        }

        //Write action for return database data 
        public ActionResult loaddata()
        {

            //var data = dc.Users.OrderBy(a => a.FirstName).ToList();
            var data = db.students.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(student st)
        {
            var MystudentName =  1;  
            //  var data = sqldb.students.SqlQuery("select * from student ").ToList();
            // var data = sqldb.students.SqlQuery("exec SelectStudent").ToList();
             var data = sqldb.students.SqlQuery("spOneparameter @MystudentName", new SqlParameter("MystudentName", MystudentName)).ToList();
            return View(data); 
        }
            
        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "student_id,student_name,student_mail")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "student_id,student_name,student_mail")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult mylistWithHtml()
        {
            return View();
        }

        //Write action for return database data 
        public ActionResult loaddataHtml()
        {

            //var data = dc.Users.OrderBy(a => a.FirstName).ToList();
            var data = db.students.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);

        }
    }
} 
//Alter Procedure spOneparameter
//@MystudentName nvarchar(50)
// As
// Begin

//    Select* from student where student_id like '%'+ @MystudentName + '%'
// End

// Declare   @MystudentName nvarchar(50)
// Exec spOneparameter 1
// print @MystudentName


@model IEnumerable<StoreProcedurePracticle.Models.student>

@{
    ViewBag.Title = "Index";
}

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.student_name)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.student_mail)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.student_name)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.student_mail)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.student_id }) |
            @Html.ActionLink("Details", "Details", new { id=item.student_id }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.student_id })
        </td>
    </tr>
}

</table>



===========================================================================================================================================
 compamy.cs 
       public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
	
Employee.cs 
			public class Employee
			{
				public int Id { get; set; }
				public string Name { get; set;}
				public int Salary { get; set; }
			}
public ActionResult EmployeeList()
        {
            var company = new Company {Name = "Microsoft"};
            var employee = new List<Employee>
            {
                new Employee {Name = "Employee 1 ", Salary = 1000},
                new Employee {Name = "Employee 2 ", Salary = 2500}
            };

            var viewallmodel = new ViewModelRandom
            {
                  Companys = company,
                  Employees = employee
            };
            return View(viewallmodel);
        }
   
			   
			EmployeeList.cshtml   
			@model WebApplication1.ViewAllModel.ViewModelRandom
			@{
				ViewBag.Title = "EmployeeList";
			}

			<h2>EmployeeList</h2>
			@{
				var classname = Model.Employees.Count > 5 ? "popular" : null;
			}

			<h2 class ="@classname">@Model.Companys.Name</h2>
			@{
				if(Model.Employees.Count == 0)
				{
					<text> No One has rented in this Company</text>
				}
				else
				{
					<ul>
						@foreach (var employee in Model.Employees)
						{
							<li>@employee.Name</li>
						} 
					</ul>
				}

			}
		
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================
===========================================================================================================================================