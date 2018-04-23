using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RecipeShare
{
    [ServiceContract]
    public interface RecipeServiceInterface
    {
        [OperationContract]
        int Authentificate();

        [OperationContract]
        void Disconnect(int p_user_id);

        [OperationContract]
        void AddRecipe(Recipe p_recipe_to_add);

        [OperationContract]
        List<Recipe> GetRecipes(int p_user_id);

        [OperationContract]
        List<Recipe> GetRecipesByIngredient(int p_user_id, string p_ingredient);

        [OperationContract]
        List<Recipe> GetCurrentSelection(int p_user_id);

        [OperationContract]
        List<Recipe> GetHistory(int p_user_id);

        [OperationContract]
        void AlterCurrentSelection(int p_user_id, List<Recipe> p_new_current_selection);
    }

    [DataContract]
    public class Recipe
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<string> Ingredients { get; set; }

        public Recipe(string p_name, string[] p_ingredients)
        {
            Name = p_name;

            Ingredients = new List<string>();

            foreach (string t_ingredient in p_ingredients)
                Ingredients.Add(t_ingredient);
        }

        public override bool Equals(Object p_object)
        {
            if (p_object == null)
                return false;

            Recipe t_recipe = p_object as Recipe;

            return Ingredients.SequenceEqual<string>(t_recipe.Ingredients);
        }

        public override int GetHashCode()
        {
            int r_hashcode = 890651037;

            r_hashcode = r_hashcode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            r_hashcode = r_hashcode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Ingredients);

            return r_hashcode;
        }

        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();

            r_to_string.Append("Name : ");
            r_to_string.Append(Name);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Ingredients :");
            r_to_string.Append(Environment.NewLine);

            foreach (string t_ingredient in Ingredients)
            {
                r_to_string.Append(" - ");
                r_to_string.Append(t_ingredient);
                r_to_string.Append(Environment.NewLine);
            }

            return r_to_string.ToString();
        }
    }
}
