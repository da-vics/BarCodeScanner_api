using BarCodeScanner_api.DataProfiles;
using BarCodeScanner_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BarCodeScanner_api.Data
{
    public class SqlCommandRepo
    {
        #region PrivateProps
        private readonly apiDBContext _commandDbContext;
        #endregion

        #region Constructor
        public SqlCommandRepo(apiDBContext commandDbContext)
        {
            _commandDbContext = commandDbContext;
        }
        #endregion

        #region CreateNewFieldDevice

        public async Task<string> CreateFieldDevice(FieldRegisterProfile fieldRegister)
        {
            if (fieldRegister == null)
                return string.Empty;

            var check = (fieldRegister.MasterKey == "SMARTERDATA") ? true : false;  //temp..

            if (check != false)
            {
                var newfieldDevice = new DeviceSetupModel();
                var result = await _commandDbContext.SetupModels.AddAsync(newfieldDevice);
                _ = await this.SaveChanges();

                return result.Entity.Id.ToString();
            }

            return string.Empty;
        }

        #endregion

        #region AddUserServiceData

        public async Task<bool> AddUserServiceData(FieldDataUploadProfile DataUpload)
        {
            var confirmID = await _commandDbContext.SetupModels.FirstOrDefaultAsync(id => id.Id == DataUpload.DeviceId);

            if (confirmID == null)
                return false;

            var userServiceData = new ProductRecords();

            #region setDataFields
            userServiceData.DeviceId = DataUpload.DeviceId;
            userServiceData.BarCodeData = DataUpload.Data;
            userServiceData.DataInsertDat = DateTime.UtcNow;
            #endregion

            await _commandDbContext.ProductRecords.AddAsync(userServiceData);
            _ = await this.SaveChanges();

            return true;
        }

        #endregion


        #region Save Changes to DataBase
        private async Task<bool> SaveChanges()
        {
            int bb = 0;
            try
            {
                bb = await _commandDbContext.SaveChangesAsync();
            }

            catch (NullReferenceException)
            {
                throw;
            }

            bool a = (bb > 0) ? true : false;
            return a;
        }
        #endregion

    }
}
