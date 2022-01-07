using EnesCanUyar_Odev2_TrashManagement.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashManagementApi_Data;
using TrashManagementApi_Data.UoW;

namespace EnesCanUyar_Odev2_TrashManagement.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        // Custom messages
        private static readonly string NotRightObjectMessage = "Not right object.";
        private static readonly string ProcessSuccessfulMessage = "Process is successful.";
        private static readonly string VehicleIsNotFoundMessage = "Vehicle is not found.";
        private static readonly string ProcessErrorMessage = "Process is not successfull.";

        //I am using dto to not to expose the data models
        public VehicleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var allVehicles = await unitOfWork.Vehicle.GetAll();

            IEnumerable<VehicleDto> vehicles = from b in allVehicles
                                               select new VehicleDto()
                                               {
                                                   Id = b.Id,
                                                   VehicleName = b.VehicleName,
                                                   VehiclePlate = b.VehiclePlate
                                               };

            //if we have no vehicle show nocontent message otherwise show them
            if (vehicles == null)
            {
                return NoContent();
            }

            return Ok(vehicles);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleDto vehicleDto)
        {
            // i will show badrequest when vehicle is null.
            if (vehicleDto != null)
            {
                Vehicle_DataModel vehicle_dm = new()
                {
                    Id = vehicleDto.Id,
                    VehicleName = vehicleDto.VehicleName,
                    VehiclePlate = vehicleDto.VehiclePlate
                };

                await unitOfWork.Vehicle.Add(vehicle_dm);
                unitOfWork.Complete();

                return Ok(ProcessSuccessfulMessage);
            }
            return BadRequest(NotRightObjectMessage);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] VehicleDto vehicleDto)
        {
            //convert dto to real data model
            var vehicleDataModel = await unitOfWork.Vehicle.GetById(vehicleDto.Id);

            if (vehicleDto == null)
            {
                return BadRequest(NotRightObjectMessage);
            }

            if (vehicleDataModel == null)
            {
                return NotFound(VehicleIsNotFoundMessage);
            }

            vehicleDataModel.VehicleName = vehicleDto.VehicleName;
            vehicleDataModel.VehiclePlate = vehicleDto.VehiclePlate;

            //update method returns tru or false based on if update is successfull
            var isChanged = unitOfWork.Vehicle.Update(vehicleDataModel);

            if (isChanged == true)
            {
                unitOfWork.Complete();
                return Ok(ProcessSuccessfulMessage);
            }

            return NotFound(ProcessErrorMessage);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle([FromQuery] long id)
        {
            var vehicleDM = await unitOfWork.Vehicle.GetById(id);

            if (vehicleDM == null)
            {
                return NotFound(VehicleIsNotFoundMessage);
            }

            unitOfWork.Vehicle.DeleteWithContainerInfo(vehicleDM.Id);
            unitOfWork.Complete();

            return Ok(ProcessSuccessfulMessage);
        }


        //this method can be seperated to Vehicle/Container Repository but I created in the controller
        [HttpGet]
        [Route("containerGroup")]
        public async Task<IActionResult> GetAllByVehicleId([FromQuery] long vehicleId, int groupCount)
        {
            List<ContainerGroup> containerGroups = new();

            var containers = await unitOfWork.Container.GetAll();
            var chosenContainers = containers.Where(x => x.VehicleId == vehicleId);
            int chosenContainersCount = chosenContainers.Count();

            //this shows how many containers does a group have
            int containerGroupItemCount = chosenContainersCount / groupCount;

            //if can not be divided equally create a one more group
            if (chosenContainersCount % groupCount != 0)
            {
                containerGroupItemCount += 1;
            }

            //keep track of where should start to get elements
            int pointer = 0;


            for (int i = 0; i < groupCount; i++)
            {
                ContainerGroup c = new()
                {
                    ContainerGroupId = i + 1,
                    VehicleId = vehicleId
                };

                for (int j = 0; j < containerGroupItemCount; j++)
                {
                    Container_DataModel nextContainerDataModel = chosenContainers.Skip(pointer).Take(1).FirstOrDefault();

                    //when group size is not equal, nextContainerDataModel will be null so we will exit from loop
                    if (nextContainerDataModel == null)
                    {
                        break;
                    }

                    //convert server object to dto
                    ContainerDto nextContainerDto = new()
                    {
                        Id = nextContainerDataModel.Id,
                        ContainerName = nextContainerDataModel.ContainerName,
                        Latitude = nextContainerDataModel.Latitude,
                        Longitude = nextContainerDataModel.Longitude,
                        VehicleId = nextContainerDataModel.VehicleId
                    };
                    pointer++;

                    //send container into container group
                    c.Containers.Add(nextContainerDto);
                }

                //send container group into list of container groups
                containerGroups.Add(c);
            }


            return Ok(containerGroups);
        }
    }
}
