// See https://aka.ms/new-console-template for more information

using BuilderDesignPattern;

MealBuilder mealBuilder = new MealBuilder();
Meal vegMeal = mealBuilder.prepareVegMeal();
Console.WriteLine("Veg Meal");
vegMeal.showItems();
Console.Write("Total Cost: " + vegMeal.getCost());

Meal nonVegMeal = mealBuilder.prepareNonVegMeal();
Console.WriteLine("\n\nNon-Veg Meal");
nonVegMeal.showItems();
Console.Write("Total Cost: " + nonVegMeal.getCost());