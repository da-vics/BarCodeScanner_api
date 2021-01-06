using BarCodeScanner_api.Data;
using BarCodeScanner_api.DataProfiles;
using BarCodeScanner_api.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BarCodeScanner_api.Controllers
{
    [Route("fieldadmin/api")]
    [ApiController]
    public class FieldCommandsController : ControllerBase
    {
        private readonly SqlCommandRepo _sqlCommandRepo;

        public FieldCommandsController()
        {
            _sqlCommandRepo = new SqlCommandRepo(new apiDBContext());
        }

        [HttpGet]

        public ActionResult SmartAdminTest()
        {
            return Content("Smart Controller");
        }

        #region AddNewDevice
        [HttpPost]
        [Route("RegisterFieldDevice")]
        public async Task<IActionResult> AdminLogin([FromBody]FieldRegisterProfile fieldRegister)
        {
            if (string.IsNullOrEmpty(fieldRegister.MasterKey))
                return StatusHandler.NotFound("null Parameter Detected", "error");

            string result = string.Empty;
            try
            {
                result = await _sqlCommandRepo.CreateFieldDevice(fieldRegister);
            }

            catch (ArgumentException args)
            {
                return StatusHandler.NotFound(args.Message, "error");
            }

            catch (NullReferenceException args)
            {
                return StatusHandler.NotFound(args.Message, "error");
            }

            if (string.IsNullOrEmpty(result))
                return StatusHandler.NotFound("access denied", "error");

            else
                return new OkObjectResult(new { DeviceID = result, status = "success" });
        }

        #endregion


        #region UserUploadServiceData

        [HttpPost]
        [Route("dataupload")]
        public async Task<IActionResult> UploadUserServiceData([FromBody] FieldDataUploadProfile DataUpload)
        {
            if (DataUpload == null || DataUpload.Data == null)
                return StatusHandler.NotFound("Null Parameter Detected", "error");

            bool checkResult = false;
            try
            {
                checkResult = await _sqlCommandRepo.AddUserServiceData(DataUpload);
            }

            catch (NullReferenceException args)
            {
                return StatusHandler.NotFound(args.Message, "error");
            }

            catch (DbUpdateException args)
            {
                return StatusHandler.NotFound(args.Message, "error");
            }

            if (checkResult == false)
                return StatusHandler.NotFound("Service Error", "error");

            else
            {
                return StatusHandler.okResult($"new serviceData Added For {DataUpload.DeviceId}", "success");
            }
        }

        #endregion

    }

}