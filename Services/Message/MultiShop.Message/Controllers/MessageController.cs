using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MultiShop.Message._UnitOfWork;
using MultiShop.Message.DTOs;
using MultiShop.Message.Services.Abstractions;
using Et=MultiShop.Message.DataAccess.Entityes;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMessageServices messageServices;
        private readonly IMapper mapper;

        public MessageController(IUnitOfWork unitOfWork,IMessageServices messageServices,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.messageServices = messageServices;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            return Ok(await unitOfWork.Repository<Et.Message>().GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {

            return Ok(await unitOfWork.Repository<Et.Message>().GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageDTO request)
        {
            await unitOfWork.Repository<Et.Message>().CreateAsync(mapper.Map<Et.Message>(request));
            return Ok(await unitOfWork.SaveAsync()>0);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMessageDTO request)
        {
            await unitOfWork.Repository<Et.Message>().UpdateAsync(mapper.Map<Et.Message>(request));
            return Ok(await unitOfWork.SaveAsync() > 0);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await unitOfWork.Repository<Et.Message>().DeleteAsync(id);
            return Ok(await unitOfWork.SaveAsync() > 0);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetSenderMessage(string senderId)
        {
            //todo tokenden gelen claim id almaq sender idini
            return Ok(await messageServices.GetSenderMessageAsync(senderId));
        }

        [HttpGet]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> GetInboxMessage(string receiverId)
        {
            //todo tokenden gelen claim id almaq receiverId idini
            return Ok(await messageServices.GetInboxMessageAsync(receiverId));
        }

    }
}
