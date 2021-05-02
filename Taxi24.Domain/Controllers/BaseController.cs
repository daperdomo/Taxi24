using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Taxi24.Domain.Controllers
{
    [Route("[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork = _unitOfWork ?? (IUnitOfWork)this.HttpContext.RequestServices.GetService(typeof(IUnitOfWork));
            }
        }

        private IMapper _mapper;

        protected IMapper mapper
        {
            get
            {
                return _mapper = _mapper ?? this.HttpContext.RequestServices.GetService<IMapper>();
            }
        }
    }
}
