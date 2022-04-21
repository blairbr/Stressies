//Notes - TODO:

gitignore:  include .vs files
change default browser back to chrome
add a healthcheck page

    _ check private methods in Repo/Controller

    -Error Handling
    -Add validation
    
Dapper / ORM what is this project using/not why/why not?

put versus patch

data entity?

Be able to explain
1)Async/await
2)Dependency Injection - if you use an interface you can remove the dependency ***
3)Interfaces
4)Service Classes - contain logic/data manipulation, call repo class, meant to separate concerns
5)Error Handling
6)Validation
7)IActionResult
8)Routes/Routing with IDs etc, header vs Body
9)Example of Encapsulation
    AKA data hiding; data is hidden from other classes, so it is also known as data-hiding.
    Declaring all the variables in the class as private and using C# Properties in the class to set and get the values of variables.
10)Example of base class/polymorphism
11) EntityFRAMEWORk ORM - dapper, what is being used in this project??

Repository/Service pattern

This is using Dapper which is a Micro ORM "a simple object mapper framework which helps map the query output to a domain class/C# class"



//Questions

1. Why would you declare ID as a string rather than an int?
//guid vs int (int is good for entity framework)
2. When would be a good use case for a contract with a private set?
//whenever you dont want reassign a value outside of the contructor
3. What is good to put in the .git ignore file and how to files like .dtbchach and Server\sqlite3 .suo etc get into the changes?
//Return types on Controllers should be IActionResult.
4. Why was it better to throw a bad request rather than argument null exception in the controller add product method?
Bc you want to handle this in the controller by returning a status code w a message, not throw an exception. 

go over the database
Is there any protection against duplicate products? Like return the ID and if it's already in there then dont let it in again?
No, but this would be easy enough to add by checking if a column like Name is unique.

//when do you use [] in SQL and when not?
The brackets are required if you use keywords, spaces, hyphens or special chars in the column names or identifiers. Using square brackets in SQL Statements allow the names to be parsed correctly. 
So it might be a good idea if it's possible that a script or something will insert a reserved keyword and wont be able to parse through it. It might be better to just have better naming conventions, however.

//Q) why query single instead of query in Product Repo add method? A) bc QueryAsync<> returns Task<IEnumerable<>> of a type whereas QuerySingle returns a single Task or Task<>
when do you use a const string versus a string
    Const is a constant variable - one that doesnt change at runtime. These should be declared as constant (const), both to avoid mistakes in the code and to enable compiling optimizations.

