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
        #region OnSaveNonPersistentEntity
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
                else
                {

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

            var obj = srvSheelon.CreateInternal();

            dto.To(obj);

            srvSheelon.SaveInternal(obj, msgs);

            if (msgs.hasAnyError)
            {
                inst.Cancel = true;
                return;
            }

            _UserSession.FlushChanges();
            dto.Id = obj.Id;
        } 
        #endregion

    }
    #endregion

    #region SheelonReleaseDtoService
    public partial class SheelonReleaseDtoService
    {
        #region OnSaveNonPersistentEntity
        protected override void OnSaveNonPersistentEntity(SheelonReleaseDto entity, IReportedMsgs msgs)
        {
            try
            {
                var container = new PipeContainer();
                container.Add("dto", entity);

                var ap = new ActionPipe<PipeContainer>(container, _UserSession, "", msgs);
                ap.AddInstruction(ValidateEntry);
                ap.AddInstruction(SaveEntry);
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
            var dto = inst.data["dto"] as SheelonReleaseDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as SheelonReleaseDto;
            var srv = _UserSession.GetService<SheelonReleaseService>();

            var obj = srv.CreateInternal();

            dto.To(obj);

            srv.SaveInternal(obj, msgs);

            if (msgs.hasAnyError)
            {
                inst.Cancel = true;
                return;
            }

            _UserSession.SaveChanges();
            dto.Id = obj.Id;
        } 
        #endregion
    }
    #endregion

    #region SheelonQuestionDtoService
    public partial class SheelonQuestionDtoService
    {
        protected override void OnSaveNonPersistentEntity(SheelonQuestionDto entity, IReportedMsgs msgs)
        {
            try
            {
                var container = new PipeContainer();
                container.Add("dto", entity);

                var ap = new ActionPipe<PipeContainer>(container, _UserSession, "", msgs);
                ap.AddInstruction(ValidateEntry);
                ap.AddInstruction(SaveEntry);
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
            var dto = inst.data["dto"] as SheelonQuestionDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as SheelonQuestionDto;
            var srv = _UserSession.GetService<SheelonQuestionService>();

            var obj = srv.CreateInternal();

            dto.To(obj);

            srv.SaveInternal(obj, msgs);

            if (msgs.hasAnyError)
            {
                inst.Cancel = true;
                return;
            }

            _UserSession.SaveChanges();
            dto.Id = obj.Id;
        }
    }
    #endregion


    #region SheelonQHidingDtoService
    public partial class SheelonQHidingDtoService
    {
        protected override void OnSaveNonPersistentEntity(SheelonQHidingDto entity, IReportedMsgs msgs)
        {
            try
            {
                var container = new PipeContainer();
                container.Add("dto", entity);

                var ap = new ActionPipe<PipeContainer>(container, _UserSession, "", msgs);
                ap.AddInstruction(ValidateEntry);
                ap.AddInstruction(SaveEntry);
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
            var dto = inst.data["dto"] as SheelonQHidingDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as SheelonQHidingDto;
            var srv = _UserSession.GetService<SheelonQHidingService>();

            var obj = srv.CreateInternal();

            dto.To(obj);

            srv.SaveInternal(obj, msgs);

            if (msgs.hasAnyError)
            {
                inst.Cancel = true;
                return;
            }

            _UserSession.SaveChanges();
            dto.Id = obj.Id;
        }
    }
    #endregion


}
