using RecipeShare;
using System.Collections.Generic;
using System.Text;

namespace RecipeService
{
    public class RecipeService : InterfaceRecipeService
    {
        public static List<Recipe> Recipes = new List<Recipe>(new Recipe[]
{
            new Recipe("Cookie", new string[]{ "Chocolat", "Yeast", "Salt", "Flour", "Sugar", "Eggs", "Butter" }),
            new Recipe("Couscous", new string[]{ "Semolina", "Sausage", "Chickpea"}),
            new Recipe("Kebab", new string[]{ "Kebab's breed", "Chicken's meat", "Tomatos", "Salad", "Algerian sauce"}),
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
                if (t_recipe.Ingredients.Contains(p_ingredient))
                    r_recipes.Add(t_recipe);

            return r_recipes;
        }
    }
}
