1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
Update-Database -Context Online_Bookshop_IdentityContext



5. On the console execute the following command

Update-Database -Context Online_Bookshop_DataContext



6. After migration is successful Run the project 

7 if you login as admin  from the following credentials will be able to see the Readers, Sales  
and Books 

User : admin@books.com
Password: 1qaz2wsX@

8. Also you can login with the following credentials to visit the site as a reader
 will be only able to see Wishlist and books and able to place an order

 User : sam@books.com
Password: 1qaz2wsX@

9 You can sign up as a new reader using the sign up link 

10 if you need to create another shop admin login with the admin credentials on step 7 above and
Click in "Create shop admin"  to register a new admin 



The Authentication and authorization related inofrmtion was obtained from the following links

Role based access control.
https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-3.0

ASP.NET MVC 5 Security And Creating User Role

https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/


