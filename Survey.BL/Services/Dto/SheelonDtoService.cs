using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KF.Interfaces;
using KF.Services;
using Survey.BL.Services.Persistent;
using Survey.Model;
using Unclassified.FieldLog;

namespace Survey.BL.Services.Dto
{
    #region SheelonDtoService
    public partial class SheelonDtoService
    {
        protected override void OnSaveNonPersistentEntity(SheelonDto entity, IReportedMsgs msgs)
        {
            try
            {
                var container = new PipeContainer();
                container.Add("dto", entity);

                var ap = new ActionPipe<PipeContainer>(container, _UserSession, "", msgs);
                ap.AddInstruction(ValidateEntry);
                ap.AddInstruction(AddSheelon);
                var result = ap.Process();
                if (!result)
                {
                    _UserSession.RollBack();
                }

            }
            catch (Exception e)
            {
                // TODO: handle fall of ap
                FL.Error(e);
            }
        }

        private void ValidateEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as SheelonDto;
        }

        private void AddSheelon(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as SheelonDto;
            var srvSheelon = _UserSession.GetService<SheelonService>();

            var sheelon = srvSheelon.CreateInternal();

            dto.To(sheelon);

            srvSheelon.SaveInternal(sheelon, msgs);

            if (msgs.hasAnyError)
            {
                inst.Cancel = true;
                return;
            }

            _UserSession.FlushChanges();

        }

    }
    #endregion

    #region QTypeDtoService
    public partial class QTypeDtoService
    {

    } 
    #endregion
}
