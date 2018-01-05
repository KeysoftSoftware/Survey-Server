using Survey.BL.Services.Persistene;
using Survey.Model;
using Survey.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BL.Services.Dto
{
    #region SheelonFillDtoService
    public partial class SheelonFillDtoService
    {
        public void GetSheelonToFill(int sheelonId, int respId, string langCode = "he")
        {
            var ctx = DataManager.GetDBContext();

            // find the relevent Sheelon release
            var sr = SheelonService.GetSheelonReleaseByDate(ctx, sheelonId, DateTime.Now.Date);
            if (sr == null)
            {
                // error

            };

            // get all questions
            var questions = ctx.GetAll<View_SQRelease>().Where(s => s.sReleaseId == sr.Id);

            foreach(var question in questions)
            {
                
            }





        }



    } 
    #endregion
}
