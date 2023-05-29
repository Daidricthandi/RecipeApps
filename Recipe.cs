using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
   
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double originalQuantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    class Step
    {
        public string Description { get; set; }

    }
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }


        //private static List<Recipe> recipes = new List<Recipes>();
        static List<Recipe> recipes = new List<Recipe>();

        public void EnterDetails()
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

            Console.WriteLine("\nRecipe details entered successfully!");
        }


        public void DisplayRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipe found!");
                Console.WriteLine();

                //return;
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
           // Console.WriteLine($"Total Calories: {CalculateTotalCalories()}");

          //  if (CalculateTotalCalories() > 300)
          //  {
          //      Console.WriteLine("WARNING! The recipe exceeds 300 calories");
         //   }
           // Console.WriteLine("*********************");

        }

        public void ChooseRecipe()
        {

            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipe found!");
                Console.WriteLine();

                //return;
            }

            Console.WriteLine("\nPlease choose a recipe : ");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1} {recipes[i].Name}");
            }

            Console.WriteLine("\nPlease enetr the recipe number to choose:");
            int number = int.Parse(Console.ReadLine()) - 1;

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
                    "Calories : " + ingredient.Calories + "\n" + "Food Group : " + ingredient);
            }

            Console.WriteLine("STEPS");
            for (int i = 0; i < chosenRecipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1} {chosenRecipe.Steps[i].Description}");
            }

        }

        public void ScaleRecipe()
        {

            Console.Write("\nPlease enter the scale factor (0.5, 2 0r 3): ");
            double factor = Convert.ToDouble(Console.ReadLine());

            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= ingredient.Quantity;
            }
            Console.WriteLine("\nRecipe scaled successfully!");
        }


        public void ResetQuantities()
        {
            Console.Write("\nPlease enter the scale factor (0.5, 2 0r 3): ");
            double factor = Convert.ToDouble(Console.ReadLine());

            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity /= ingredient.Quantity;
            }
            Console.WriteLine("\nRecipe scaled successfully!");
        }

        
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        

        public void ClearRecipe()
        {
            //clearing all the data that was stored previously stored
            Ingredients.Clear();
            Steps.Clear();

            Console.WriteLine("Recipe cleared. Please enter a new recipe ");

            //calling the enterDetails method for the user to enter a new recipe
            EnterDetails();

        }

    }

}


