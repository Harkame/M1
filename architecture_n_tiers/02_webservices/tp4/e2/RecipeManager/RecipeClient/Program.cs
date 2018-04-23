using RecipeShare;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace RecipeClient
{
    class Program
    {
        private static RecipeShare.RecipeServiceInterface g_proxy;

        static void Main(string[] args)
        {
            g_proxy = new ChannelFactory<RecipeShare.RecipeServiceInterface>("RecipeService").CreateChannel();

            StringBuilder t_actions = new StringBuilder();
            t_actions.Append("1 : AddRecipes");
            t_actions.Append(Environment.NewLine);
            t_actions.Append("2 : GetRecipes");
            t_actions.Append(Environment.NewLine);
            t_actions.Append("3 : GetRecipesByIngredient");
            t_actions.Append(Environment.NewLine);
            t_actions.Append("4 : GetCurrentSelection");
            t_actions.Append(Environment.NewLine);
            t_actions.Append("5 : GetHistory");
            t_actions.Append(Environment.NewLine);
            t_actions.Append("6 : AlterCurrentSelection");
            t_actions.Append(Environment.NewLine);
            t_actions.Append("7 : Exit");
            t_actions.Append(Environment.NewLine);

            string t_ingredient;


            int t_user_id = g_proxy.Authentificate();

            Console.WriteLine("Connected as : " + t_user_id);

            while (true)
            {
                Console.WriteLine(t_actions.ToString());
                Console.Write("Action : ");
                int t_action = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (t_action)
                {
                    case 1: //AddRecipe
                        Console.Write("Recipe name : ");
                        String t_recipe_name = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Ingredient(s) : (end to stop list)");


                        t_ingredient = "none"; //Reset
                        List<string> t_ingredients = new List<string>();

                        while(!t_ingredient.Equals("end"))
                        {
                            t_ingredients.Add(t_ingredient);
                            Console.Write("Ingredient (" + t_ingredients.Count + ") : ");
                            t_ingredient = Console.ReadLine();
                        }

                        g_proxy.AddRecipe(new Recipe(t_recipe_name, t_ingredients.ToArray()));

                        break;

                    case 2: //GetRecipes
                        foreach (Recipe t_recipe in g_proxy.GetRecipes(t_user_id))
                            Console.WriteLine(t_recipe.ToString());
                        break;

                    case 3: //GetCurrentSelection
                        Console.Write("Ingredient : ");

                        t_ingredient = Console.ReadLine();

                        Console.WriteLine("");

                        foreach (Recipe t_recipe in g_proxy.GetRecipesByIngredient(t_user_id, t_ingredient))
                            Console.WriteLine(t_recipe.ToString());

                        break;

                    case 4: //GetHistory
                        foreach (Recipe t_recipe in g_proxy.GetCurrentSelection(t_user_id))
                            Console.WriteLine(t_recipe.ToString());

                        break;

                    case 5: //GetRecipesByIngredient
                        foreach (Recipe t_recipe in g_proxy.GetHistory(t_user_id))
                            Console.WriteLine(t_recipe.ToString());
                        break;

                    case 6: //AlterCurrentSelection
                        List<Recipe> t_altered_current_selection = g_proxy.GetCurrentSelection(t_user_id);

                        foreach (Recipe t_recipe in g_proxy.GetCurrentSelection(t_user_id))
                        {
                            Console.WriteLine(t_recipe.ToString());

                            Console.WriteLine("");

                            Console.WriteLine("Do you want to remove this recipe from the current selection ? (y/n)");

                            switch(Console.ReadKey().KeyChar)
                            {
                                case 'y':
                                    t_altered_current_selection.Remove(t_recipe);
                                    Console.WriteLine("Removed : " + t_altered_current_selection.Count);
                                break;

                                case 'n':
                                default:
                                    break;
                            }
                        }

                        g_proxy.AlterCurrentSelection(t_user_id, t_altered_current_selection);

                        break;

                    case 7: //Quit the program
                        goto end_of_loop;
                }   
            }

            end_of_loop: { } //To quit the loop
        }
    }
}
