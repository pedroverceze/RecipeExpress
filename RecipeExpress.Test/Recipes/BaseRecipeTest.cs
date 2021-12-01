using AutoFixture;
using Moq;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Repositories;
using RecipeExpressDomain.Recipes.Services;
using System;
using System.Collections.Generic;

namespace RecipeExpress.Test.Recipes
{
    public abstract class BaseRecipeTest 
    {
        private Fixture _fixture;
        protected Guid _recipeId;
        protected Mock<IRecipeMongoRepository> _recipeMongoRepository;
        protected RecipeService _recipeService;

        public BaseRecipeTest()
        {
            _fixture = new Fixture();
            _recipeId = _fixture.Create<Guid>();
            _recipeMongoRepository = new Mock<IRecipeMongoRepository>();
            _recipeService = new RecipeService(_recipeMongoRepository.Object);
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
