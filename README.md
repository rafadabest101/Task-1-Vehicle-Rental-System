# Task-1-Vehicle-Rental-System
This is my solution for Task 1 of the Prime Holding Internship Assignment. The README file contains a description on what my project does and how it works.

I completed this task using the principles of the object-oriented programming. First up I made an abstract class - Vehicle, and 3 other classes that inherit it - Motorcycle, Car and Cargo Van. I also used a static class called Invoice, which has a single method that prints out the invoice on the console. 

In the Vehicle class, I added 4 public properties, a constructor and 3 abstract methods:
- CalculateRentCost(): it is used to calculate the total rental cost for the whole rental period of the customer;
- CalculateInsuranceCost(): it is used to calculate the total insurance cost for the whole rental period of the customer;
- Calculate Insurance Change(): it is used to calculate the discount/addition to the insurance cost based on the business rules for it.

The Car, Motorcycle and Cargo Van classes all inherit the Vehicle class, so they implement its constructor and abstract methods, but they also have an additional property for each class based on the required information.

The static Invoice class has a single method - Print(), which is used to print out the needed information about the customer and the rented vehicle on the console in the form of an invoice. This method also does calculations for certain values which do not appear in the other classes but must be printed out, such as daily rent and insurance costs, early return discounts, etc.

And lastly we have the Main() method, which can be found in the Program.cs file. This method inquires the user to input information about the customer name, the start of the renting period and details about the rented vehicle. Based on the information from the input, the Main() method calls the Print() method from the Invoice class, which then prints out an invoice to the customer on the renting information.
