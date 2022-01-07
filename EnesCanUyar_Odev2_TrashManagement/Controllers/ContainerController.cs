using EnesCanUyar_Odev2_TrashManagement.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TrashManagementApi_Data;
using TrashManagementApi_Data.UoW;

namespace EnesCanUyar_Odev2_TrashManagement.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        // Custom messages
        private static readonly string NotRightObjectMessage = "Not right object.";
        private static readonly string ProcessSuccessfulMessage = "Process is successful.";
        private static readonly string ContainerIsNotFoundMessage = "Container is not found.";
        private static readonly string ProcessErrorMessage = "Process is not successfull.";

        //I am using dto to not to expose the data models
        public ContainerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContainers()
        {
            var allContainers = await unitOfWork.Container.GetAll();

            //converted system model to dto
            var allContainersDto = from c in allContainers
                                   select new ContainerDto()
                                   {
                                       Id = c.Id,
                                       Latitude = c.Latitude,
                                       Longitude = c.Longitude,
                                       VehicleId = c.VehicleId
                                   };

            // i used -1 to unbounded containers
            return Ok(allContainersDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddContainer([FromBody] ContainerDto containerDto)
        {
            // i will show badrequest when container is null.
            if (containerDto != null)
            {
                Container_DataModel container_dm = new()
                {
                    Id = containerDto.Id,
                    ContainerName = containerDto.ContainerName,
                    Latitude = containerDto.Latitude,
                    Longitude = containerDto.Longitude,
                    VehicleId = containerDto.VehicleId
                };

                await unitOfWork.Container.Add(container_dm);
                unitOfWork.Complete();

                return Ok(ProcessSuccessfulMessage);
            }
            return BadRequest(NotRightObjectMessage);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContainer([FromBody] ContainerDto containerDto)
        {
            //convert dto to real data model
            var containerDataModel = await unitOfWork.Container.GetById(containerDto.Id);

            if (containerDto == null)
            {
                return BadRequest(NotRightObjectMessage);
            }

            if (containerDataModel == null)
            {
                return NotFound(ContainerIsNotFoundMessage);
            }

            //even if user send vehicleId, I will not update the id
            containerDataModel.ContainerName = containerDto.ContainerName;
            containerDataModel.Latitude = containerDto.Latitude;
            containerDataModel.Longitude = containerDto.Longitude;


            //update method returns tru or false based on if update is successfull
            var isChanged = unitOfWork.Container.Update(containerDataModel);

            if (isChanged == true)
            {
                unitOfWork.Complete();
                return Ok(ProcessSuccessfulMessage);
            }

            return NotFound(ProcessErrorMessage);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContainer([FromQuery] long id)
        {
            var containerDM = await unitOfWork.Container.GetById(id);

            if (containerDM == null)
            {
                return NotFound(ContainerIsNotFoundMessage);
            }

            unitOfWork.Container.Delete(containerDM.Id);
            unitOfWork.Complete();

            return Ok(ProcessSuccessfulMessage);
        }

        [HttpGet]
        [Route("byVehicle")]
        public async Task<IActionResult> GetAllByVehicleId([FromQuery] long id)
        {

            var containers = await unitOfWork.Container.GetAll();
            var chosenContainers = containers.Where(x => x.VehicleId == id);

            if (chosenContainers == null)
            {
                return NoContent();
            }

            return Ok(chosenContainers);
        }
    }
}
