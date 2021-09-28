using AutoFixture;
using RecipeExpressDomain.Recipes.Documents;
using System;

namespace RecipeExpress.Test.Recipes
{
    public abstract class BaseRecipeTest
    {
        private Fixture _fixture;
        protected Guid _recipeId;

        public BaseRecipeTest()
        {
            _fixture = new Fixture();
            _recipeId = _fixture.Create<Guid>();
        }

        protected RecipeDocument CreateRecipeDocument()
        => _fixture.Create<RecipeDocument>();
    }
}
