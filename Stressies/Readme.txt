//Notes - TODO:

1. anything referring to customer ID needs to be reworked, renamed to Id rather than customer Id
2.        //Todo look at athe check box for the gitignore and include .vs files
check that output is returning object from the DB.
change default browser back to chrome
add a healthcheck page

//Questions

1. Why would you declare ID as a string rather than an int?
//guid vs int (int is good for entity framework)
2. When would be a good use case for a contract with a private set?
//whenever you dont want reassign a value outside of the contructor
3. What is good to put in the .git ignore file and how to files like .dtbchach and Server\sqlite3 .suo etc get into the changes?
//Return types on Controllers should be IActionResult?
Why was it better to throw a bad request rather than argument null exception in the controller add product method?

go over the database
Is there any protection against duplicate products? Like return the ID and if it's already in there then dont let it in again? orrr... how does that work bc Henrietta should be unique?

//when do you use [] in SQL and when not?
Return type on AddProduct in the repo?? dynamic object? Doesnt seem right

                //why query single instead of query in Product Repo add method?

sample product to Add

explain async await

Dapper / ORM what is this project using/not why/why not?

put versus patch

data entity?

when do you use a const string versus a string
    Const is a constant variable - one that doesnt change at runtime. These should be declared as constant (const), both to avoid mistakes in the code and to enable compiling optimizations.

