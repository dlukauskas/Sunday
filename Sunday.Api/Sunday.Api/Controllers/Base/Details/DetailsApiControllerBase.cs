using AutoMapper;
using Sunday.Core.Entities;
using Sunday.Core.Repositories;
using Sunday.Models.Details;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using System.Data.Entity;

namespace Sunday.Api.Controllers.Base.Details
{
    public class DetailsApiControllerBase<TDetailsModel, TEntity, TEntityRepository> : AuthApiControllerBase
            where TDetailsModel : DetailsModelBase, new()
            where TEntity : class, IEntity<TEntity>
            where TEntityRepository : RepositoryBase<TEntity>, new()
    {
        private readonly TEntityRepository repository;

        public DetailsApiControllerBase()
        {
            this.repository = new TEntityRepository();
        }

        public DetailsApiControllerBase(TEntityRepository repository)
        {
            if (repository == null)
            {
                this.repository = new TEntityRepository();
            }
            else
            {
                this.repository = repository;
            }
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> Get(int id)
        {
            var model = new TDetailsModel();

            var entity = await Repository.GetAsync(id);

            if (entity != null)
            {
                model = Mapper.Map<TDetailsModel>(entity);

                return Ok(model);
            }

            return NotFound();
        }

        [HttpPost]
        public virtual async Task<IHttpActionResult> Save(TDetailsModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            TEntity entity = null;

            if (model.Id != default(int))
            {
                entity = await Repository.GetAsync(model.Id);
            }

            entity = Mapper.Map(model, entity);

            var qq = await repository.Query.Where(entity.ExistsQuery).ToListAsync();

            if (!await Repository.ExistsAsync(entity.ExistsQuery))
            {
                var result = await Repository.SaveAsync(entity);

                if (result.Id != default(int))
                {
                    model = Mapper.Map<TDetailsModel>(result);

                    return Ok(model);
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        public virtual async Task<IHttpActionResult> Delete(int id)
        {
            if (id == default(int))
            {
                return BadRequest();
            }

            var entity = await Repository.GetAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                await Repository.DeleteAsync(id);

                return Ok();
            }
        }

        public TEntityRepository Repository
        {
            get
            {
                return repository;
            }
        }
    }
}