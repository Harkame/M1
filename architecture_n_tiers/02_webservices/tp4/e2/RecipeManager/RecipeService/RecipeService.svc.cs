using RecipeShare;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeService
{
    public class RecipeService : InterfaceRecipeService
    {
        public static List<Recipe> Recipes = new List<Recipe>(new Recipe[]
{
            new Recipe("cookie", new string[]{ "chocolat", "yeast", "salt", "flour", "sugar", "eggs", "butter" }),
            new Recipe("couscous", new string[]{ "semolina", "sausage", "chickpea"}),
            new Recipe("kebab", new string[]{ "kebab's breed", "chicken's meat", "tomatos", "salad", "algerian sauce"}),
            new Recipe("diabet", new string[]{ "sugar" }),
        });

        public void AddRecipe(Recipe p_recipe_to_add)
        {
            Recipes.Add(p_recipe_to_add);
        }

        public List<Recipe> GetRecipes()
        {
            return Recipes;
        }

        public List<Recipe> GetRecipesByIngredient(string p_ingredient)
        {
            List<Recipe> r_recipes = new List<Recipe>();

            foreach (Recipe t_recipe in Recipes)
                if (t_recipe.Ingredients.Contains(p_ingredient.ToLower()))
                    r_recipes.Add(t_recipe);

            return r_recipes;
        }
    }
}
