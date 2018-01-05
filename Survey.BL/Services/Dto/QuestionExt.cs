using KF.Interfaces;
using KF.Services;
using Survey.BL.Services.Persistent;
using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unclassified.FieldLog;

namespace Survey.BL.Services.Dto
{
    #region QTypeDtoService
    public partial class QTypeDtoService
    {
        protected override void OnSaveNonPersistentEntity(QTypeDto entity, IReportedMsgs msgs)
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
            var dto = inst.data["dto"] as QTypeDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as QTypeDto;
            var srv = _UserSession.GetService<QTypeService>();

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

    #region QuestionDtoService
    public partial class QuestionDtoService
    {
        protected override void OnSaveNonPersistentEntity(QuestionDto entity, IReportedMsgs msgs)
        {
            try
            {
                var container = new PipeContainer();
                container.Add("dto", entity);
                var ctx = DataManager.GetDBContext();
                container.Add("ctx", ctx);

                var ap = new ActionPipe<PipeContainer>(container, _UserSession, "", msgs);
                ap.AddInstruction(ValidateEntry);
                ap.AddInstruction(SaveEntry);
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
            var dto = inst.data["dto"] as QuestionDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as QuestionDto;
            var ctx = inst.data["ctx"] as DataManager.DataContext;

            var srv = _UserSession.GetService<QuestionService>();

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

    #region QuestionReleaseDtoService
    public partial class QReleaseDtoService
    {
        protected override void OnSaveNonPersistentEntity(QReleaseDto entity, IReportedMsgs msgs)
        {
            try
            {
                var container = new PipeContainer();
                container.Add("dto", entity);
                var ctx = DataManager.GetDBContext();
                container.Add("ctx", ctx);

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
            var dto = inst.data["dto"] as QReleaseDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as QReleaseDto;
            var ctx = inst.data["ctx"] as DataManager.DataContext;

            var srv = _UserSession.GetService<QReleaseService>();

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

    #region QReleaseOptDtoService
    public partial class QReleaseOptDtoService
    {
        protected override void OnSaveNonPersistentEntity(QReleaseOptDto entity, IReportedMsgs msgs)
        {
            try
            {
                var container = new PipeContainer();
                container.Add("dto", entity);
                var ctx = DataManager.GetDBContext();
                container.Add("ctx", ctx);

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
            var dto = inst.data["dto"] as QReleaseOptDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as QReleaseOptDto;
            var ctx = inst.data["ctx"] as DataManager.DataContext;

            var srv = _UserSession.GetService<QReleaseOptService>();

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

    #region QTextDtoService
    public partial class QTextDtoService
    {
        protected override void OnSaveNonPersistentEntity(QTextDto entity, IReportedMsgs msgs)
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
            var dto = inst.data["dto"] as QTextDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as QTextDto;
            var srv = _UserSession.GetService<QTextService>();

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

    #region QOptionDtoService
    public partial class QOptionDtoService
    {
        protected override void OnSaveNonPersistentEntity(QOptionDto entity, IReportedMsgs msgs)
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
            var dto = inst.data["dto"] as QOptionDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as QOptionDto;
            var srv = _UserSession.GetService<QOptionService>();

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
