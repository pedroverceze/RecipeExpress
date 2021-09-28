using AutoFixture;
using RecipeExpressDomain.Recipes.Documents;
using System;
using System.Collections.Generic;

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
        => _fixture.Build<RecipeDocument>()
            .With(r => r.Id, _recipeId)
            .Create();

        protected IEnumerable<RecipeDocument> CreateRecipeListDocument()
        => _fixture.Build<RecipeDocument>()
            .With(r => r.Id, _recipeId)
            .CreateMany();
    }
}
