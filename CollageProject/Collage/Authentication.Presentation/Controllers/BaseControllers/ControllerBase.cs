using AutoMapper;
using Collage.Domain.Commons;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity, TDto> : ControllerBase where TEntity : BaseEntity where TDto : BaseDto
    {
        protected readonly IBaseBusiness<TEntity> _unitOfWork;

        protected IMapper _mapper;

        protected readonly IValidator<TEntity> _validator;

        public BaseController(IBaseBusiness<TEntity> unitOfWork, IMapper mapper, IValidator<TEntity> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            TEntity entity = await _unitOfWork.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
            return Ok(_mapper.Map<TDto>(entity));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok((await _unitOfWork.ReadAllAsync()).Select((TEntity product) => _mapper.Map<TDto>(product)));
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            TEntity source = await _unitOfWork.ReadByIdAsync(id);
            TDto value = _mapper.Map<TDto>(source);
            return Ok(value);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto entityViewModel)
        {
            TEntity entity = _mapper.Map<TEntity>(entityViewModel);
            ValidationResult validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select((ValidationFailure e) => e.ErrorMessage));
            }

            entity = await _unitOfWork.CreateAsync(entity);
            try
            {
                await _unitOfWork.SaveAsync();
                return CreatedAtAction("Get", new
                {
                    id = entity.Id
                }, entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TDto dto)
        {
            TEntity val = _mapper.Map<TEntity>(dto);
            ValidationResult validationResult = _validator.Validate(val);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select((ValidationFailure e) => e.ErrorMessage));
            }

            await _unitOfWork.Update(val);
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(_mapper.Map<TDto>(dto));
        }
    }
}
