using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Taxi24.Domain.Controllers
{
    public class CrudBaseController<T, TViewModel> : BaseController where T : class, IBaseEntity where TViewModel : class
    {

        private IRepository<T> _repository;

        protected IRepository<T> repository
        {
            get
            {
                return _repository = _repository ?? this.HttpContext.RequestServices.GetService<IRepository<T>>();
            }
        }

        #region CRUD

        [HttpGet]
        public virtual IActionResult GetAll()
        {
            try
            {
                return Ok(repository.ListAll().Select(m => mapper.Map<TViewModel>(m)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public virtual IActionResult GetById(int Id)
        {
            try
            {
                var entity = mapper.Map<TViewModel>(repository.First(m => m.Id == Id));
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
