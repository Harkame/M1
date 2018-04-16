using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RecipeShare
{
    [ServiceContract]
    public interface InterfaceRecipeService
    {
        [OperationContract]
        int Authentificate();

        [OperationContract]
        void Disconnect(int p_user_id);

        [OperationContract]
        void AddRecipe(Recipe p_recipe_to_add);

        [OperationContract]
        ICollection<Recipe> GetRecipes(int p_user_id);

        [OperationContract]
        ICollection<Recipe> GetRecipesByIngredient(int p_user_id, string p_ingredient);

        [OperationContract]
        ICollection<Recipe> GetCurrentSelection(int p_user_id);

        [OperationContract]
        ICollection<Recipe> GetHistory(int p_user_id);

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
