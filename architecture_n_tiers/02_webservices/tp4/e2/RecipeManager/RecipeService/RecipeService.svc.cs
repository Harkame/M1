using RecipeShare;
using System.Collections.Generic;

namespace RecipeService
{
    public class RecipeServiceImplementation : RecipeServiceInterface
    {
        private static int G_ID = 0;

        public static List<Recipe> Recipes = new List<Recipe>(new Recipe[]
        {
            new Recipe("cookie", new string[]{ "chocolat", "yeast", "salt", "flour", "sugar", "eggs", "butter" }),
            new Recipe("couscous", new string[]{ "semolina", "sausage", "chickpea"}),
            new Recipe("kebab", new string[]{ "kebab's breed", "chicken's meat", "tomatos", "salad", "algerian sauce"}),
            new Recipe("diabet", new string[]{ "sugar" }),
        });

        public static IDictionary<int, List<Recipe>> Selections = new Dictionary<int, List<Recipe>>();

        public static IDictionary<int, List<Recipe>> History = new Dictionary<int, List<Recipe>>();

        public int Authentificate()
        {
            int r_user_id = G_ID++;

            Selections.Add(r_user_id, new List<Recipe>());
            History.Add(r_user_id, new List<Recipe>());

            return r_user_id;
        }

        public void Disconnect(int p_user_id)
        {
            Selections.Remove(p_user_id);
            History.Remove(p_user_id);
        }

        public void AddRecipe(Recipe p_recipe_to_add)
        {
            Recipes.Add(p_recipe_to_add);
        }

        public ICollection<Recipe> GetRecipes(int p_user_id)
        {
            Selections[p_user_id] = new List<Recipe>(Recipes);

            History[p_user_id].AddRange(Recipes);

            return Recipes;
        }

        public ICollection<Recipe> GetRecipesByIngredient(int p_user_id, string p_ingredient)
        {
            ICollection<Recipe> r_recipes = new List<Recipe>();

            foreach (Recipe t_recipe in Recipes)
                if (t_recipe.Ingredients.Contains(p_ingredient.ToLower()))
                    r_recipes.Add(t_recipe);

            Selections[p_user_id] = new List<Recipe>(r_recipes);

            History[p_user_id].AddRange(r_recipes);

            return r_recipes;
        }

        public ICollection<Recipe> GetCurrentSelection(int p_user_id)
        {
            List<Recipe> r_current_selection = null;

            Selections.TryGetValue(p_user_id, out r_current_selection);

            return r_current_selection;
        }

        public ICollection<Recipe> GetHistory(int p_user_id)
        {
            List<Recipe> r_current_selection = null;

            History.TryGetValue(p_user_id, out r_current_selection);

            return r_current_selection;
        }
    }
}
