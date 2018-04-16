﻿using RecipeShare;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace RecipeClient
{
    class Program
    {
        private static RecipeServiceReference.InterfaceRecipeService g_proxy = new ChannelFactory<RecipeServiceReference.InterfaceRecipeService>("BasicHttpBinding").CreateChannel();

        static void Main(string[] args)
        {
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
            t_actions.Append("6 : Exit");
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

                    case 6: //Quit the program
                        goto end_of_loop;
                }   
            }

            end_of_loop: { } //To quit the loop
        }
    }
}
