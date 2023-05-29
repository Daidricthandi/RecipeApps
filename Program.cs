using System;

namespace RecipeApp
{
    public delegate void RecipeCaloriesExceededEventHandler(string recipeName, double totalCalories);

    class Program
    {
        static List<Recipe> recipes = new List<Recipe>();

        //Event for notifying when a recipe exceeds 300
        // static void RecipeCaloriesExceededEventHandler(string recipeName, double totalCalories);
        // {
        //  Console.WriteLine("WARNING! The recipe '{recipeName}' exceeds 300 calories. Total Calories: {totalCalories}");
        // }

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE RECIPE APPLICATION!");
            Console.WriteLine("************************************");

            List<Recipe> recipes = new List<Recipe>();

            //creating an object of the recipe class
            Recipe recipe = new Recipe();

            bool exit = false;

            //loop until user exits the program
            while (!exit)
            {
                Console.WriteLine("\nPlease choose an option below : ");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Dispaly all recipes");
                Console.WriteLine("3. Choose a recipe to display");
                Console.WriteLine("4. Scale recipe");
                Console.WriteLine("5. Reset quantities");
                Console.WriteLine("6. Clear recipe");
                Console.WriteLine("7. Exit application");

                Console.WriteLine();

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.EnterDetails();
                        break;

                    case 2:
                        recipe.DisplayRecipe();
                        break;

                    case 3:
                        recipe.ChooseRecipe();
                        break;

                    case 4:
                        recipe.ScaleRecipe();
                        break;

                    case 5:
                        recipe.ResetQuantities();
                        break;

                    case 6:
                        recipe.ClearRecipe();
                        break;

                    case 7:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;

                }
            }
            Console.WriteLine("Thank you for using our application!");
        }
       static void EnterDetails()
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("\nPlease enter the name of recipe : ");
            recipe.Name = Console.ReadLine();

            recipe.Ingredients = new List<Ingredient>();
            Console.WriteLine("\nPlease enter the number of ingredients : ");
            int numIngredients = Convert.ToInt32(Console.ReadLine());

            //looping through each ingredient to get the name, quantity, and the unit of measurement from the user
            for (int i = 0; i < numIngredients; i++)
            {
                Ingredient ingredient = new Ingredient();

                Console.WriteLine($"\nINGREDIENT");
                Console.WriteLine("*********************");
                Console.WriteLine("Please enter the name of ingredient " + (i + 1) + " : ");
                ingredient.Name = Console.ReadLine();

                Console.WriteLine("\nPlease enter the quantity of " + ingredient.Name + " : ");
                ingredient.Quantity = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nPlease enter the unit of measurement for " + ingredient.Name + " :  ");
                ingredient.Unit = Console.ReadLine();

                Console.WriteLine("\nPlease enter the number of calories for " + ingredient.Name + " :  ");
                ingredient.Calories = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("\nPlease enter the food group for " + ingredient.Name + " :  ");
                ingredient.FoodGroup = Console.ReadLine();


                recipe.Ingredients.Add(ingredient);
                Console.WriteLine("*********************");
            }

            recipe.Steps = new List<Step>();
            Console.WriteLine("\nPlease enter the number of steps : ");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            //looping through each step to get the user's description
            for (int i = 0; i < numSteps; i++)
            {
                Step step = new Step();

                Console.WriteLine("\nSTEP.");
                Console.WriteLine("*********************");
                Console.WriteLine("Enter the description for step " + (i + 1) + " : ");
                step.Description = Console.ReadLine();

                Console.WriteLine("*********************");

                recipe.Steps.Add(step);
            }
            recipes.Add(recipe);

            Console.WriteLine("\nRecipe details entered successfully!");
        }

        static void DisplayRecipe()
        {
            if (recipes.Count == 0)
            { 
                Console.WriteLine("No recipe found!");
                Console.WriteLine();

                return;
            }

            //Displaying the recipe
            Console.WriteLine("\nRECIPE ");
            Console.WriteLine("*********************");
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
            Console.WriteLine("*********************");

            //calculate the total calories
            int totalCalories = 0;
            Console.WriteLine($"Total Calories:");

             if (totalCalories > 300)
             {
                Console.WriteLine("WARNING! The recipe exceeds 300 calories");
              }
           
        }

        static void ChooseRecipe() 
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipe found!");
                Console.WriteLine();

                return;
            }

            Console.WriteLine("\nPlease choose a recipe : ");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1} {recipes[i].Name}");
            }

            Console.WriteLine("\nPlease enetr the recipe number to choose:");
            int number = int.Parse(Console.ReadLine())-1;

            if (number < 0 || number >= recipes.Count)
            {
                Console.WriteLine("Invalid recipe number");
                return;
            }

            Recipe chosenRecipe = recipes[number];

            Console.WriteLine("Below is the chosen recipe : ");
            Console.WriteLine($"Name of the recipe : {chosenRecipe.Name}");
            Console.WriteLine("The ingredeints of the recipe : ");
            foreach (Ingredient ingredient in chosenRecipe.Ingredients)
            {
                Console.WriteLine($"Quantity :" + ingredient.Quantity + "\n" + "Units : " + ingredient.Unit + " of " + ingredient.Name + "\n" + 
                    "Calories : " + ingredient.Calories + "\n" + "Food Group : " + ingredient.FoodGroup);
            }

            Console.WriteLine("STEPS");
            for (int i = 0; i < chosenRecipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1} {chosenRecipe.Steps[i].Description}");
            }
        }

       



    }
}
