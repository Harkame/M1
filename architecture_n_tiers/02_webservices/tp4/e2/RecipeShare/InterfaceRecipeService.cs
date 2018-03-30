namespace RecipeShare
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [ServiceContract]
    public interface InterfaceRecipeService
    {
        [OperationContract]
        List<Recipe> GetCommonRecipes(String p_ingredient);

        [OperationContract]
        void AddRecipe(Recipe p_recipe);
    }

    [DataContract]
    public class Recipe
    {
        [DataMember]
        public List<string> Ingredients
        {
            get
            {
                return Ingredients;
            }
            set
            {
                Ingredients = value;
            }
        }

        [DataMember]
        public List<string> Steps
        {
            get
            {
                return Steps;
            }
            set
            {
                Steps = value;
            }
        }

        public static void Main(string[] args)
        {
        }
    }
}