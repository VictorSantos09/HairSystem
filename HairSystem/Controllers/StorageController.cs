using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly StorageService _storageService;
        private readonly StorageRepository _storageRepository;

        public StorageController(StorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
            _storageService = new StorageService(_storageRepository);
        }
        [HttpGet]
        [Route("StorageManagement")]

    }
}
