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

        public override IFormLayout OnAfterLoadLayout(IFormLayout layout, IAPICall call)
        {

            var ctx = DataManager.GetDBContext();

            //var dgc = new IFormItem("F1");
            //dgc.caption = "F1";
            //dgc.allowEditing = true;

            layout.items.AddSelect("P1", "P1label");

            var items = layout.items as KF.Primitives.ControlsList;
            var item = KF.Services.DynamicFormService.findFormItem(items, "P1");
            item.editorOptions["dataSourceName"] = "TDs";
            item.editorOptions["valueExpr"] = "name";
            item.editorOptions["displayExpr"] = "name";

            return base.OnAfterLoadLayout(layout, call);
        }

        #region OnLoadNonPersistentEntity
        protected override void OnLoadNonPersistentEntity(int id, string code, SheelonDto entity)
        {
            using (var ctx = DataManager.GetDBContext())
            {
                var obj = ctx.GetById<Sheelon>(id);
                entity.From(obj);
                entity.name = "test";
                entity.P1 = 3;

            }

        }
        #endregion


        #region OnSaveNonPersistentEntity
        protected override void OnSaveNonPersistentEntity(SheelonDto entity, IReportedMsgs msgs)
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

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as SheelonDto;
            var srv = _UserSession.GetService<SheelonService>();

            var obj = srv.LoadInternal(dto.Id); // if id == 0 then srv do create internal

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

    #region SheelonReleaseDtoService
    public partial class SReleaseDtoService
    {
        #region OnSaveNonPersistentEntity
        protected override void OnSaveNonPersistentEntity(SReleaseDto entity, IReportedMsgs msgs)
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
            var dto = inst.data["dto"] as SReleaseDto;
        }

        private void SaveEntry(Instruction<PipeContainer> inst)
        {
            var msgs = inst.Msgs;
            var dto = inst.data["dto"] as SReleaseDto;
            var srv = _UserSession.GetService<SReleaseService>();

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

    //#region SheelonQuestionDtoService
    //public partial class SQuestionDtoService
    //{
    //    protected override void OnSaveNonPersistentEntity(SQuestionDto entity, IReportedMsgs msgs)
    //    {
    //        try
    //        {
    //            var container = new PipeContainer();
    //            container.Add("dto", entity);

    //            var ap = new ActionPipe<PipeContainer>(container, _UserSession, "", msgs);
    //            ap.AddInstruction(ValidateEntry);
    //            ap.AddInstruction(SaveEntry);
    //            var result = ap.Process();
    //            if (!result)
    //            {
    //                _UserSession.RollBack();
    //            }

    //        }
    //        catch (Exception e)
    //        {
    //            // TODO: handle fall of ap
    //            FL.Error(e);
    //        }
    //    }

    //    private void ValidateEntry(Instruction<PipeContainer> inst)
    //    {
    //        var msgs = inst.Msgs;
    //        var dto = inst.data["dto"] as SheelonQuestionDto;
    //    }

    //    private void SaveEntry(Instruction<PipeContainer> inst)
    //    {
    //        var msgs = inst.Msgs;
    //        var dto = inst.data["dto"] as SheelonQuestionDto;
    //        var srv = _UserSession.GetService<SheelonQuestionService>();

    //        var obj = srv.CreateInternal();

    //        dto.To(obj);

    //        srv.SaveInternal(obj, msgs);

    //        if (msgs.hasAnyError)
    //        {
    //            inst.Cancel = true;
    //            return;
    //        }

    //        _UserSession.SaveChanges();
    //        dto.Id = obj.Id;
    //    }
    //}
    //#endregion


    //#region SheelonQHidingDtoService
    //public partial class SheelonQHidingDtoService
    //{
    //    protected override void OnSaveNonPersistentEntity(SheelonQHidingDto entity, IReportedMsgs msgs)
    //    {
    //        try
    //        {
    //            var container = new PipeContainer();
    //            container.Add("dto", entity);

    //            var ap = new ActionPipe<PipeContainer>(container, _UserSession, "", msgs);
    //            ap.AddInstruction(ValidateEntry);
    //            ap.AddInstruction(SaveEntry);
    //            var result = ap.Process();
    //            if (!result)
    //            {
    //                _UserSession.RollBack();
    //            }

    //        }
    //        catch (Exception e)
    //        {
    //            // TODO: handle fall of ap
    //            FL.Error(e);
    //        }
    //    }

    //    private void ValidateEntry(Instruction<PipeContainer> inst)
    //    {
    //        var msgs = inst.Msgs;
    //        var dto = inst.data["dto"] as SheelonQHidingDto;
    //    }

    //    private void SaveEntry(Instruction<PipeContainer> inst)
    //    {
    //        var msgs = inst.Msgs;
    //        var dto = inst.data["dto"] as SheelonQHidingDto;
    //        var srv = _UserSession.GetService<SheelonQHidingService>();

    //        var obj = srv.CreateInternal();

    //        dto.To(obj);

    //        srv.SaveInternal(obj, msgs);

    //        if (msgs.hasAnyError)
    //        {
    //            inst.Cancel = true;
    //            return;
    //        }

    //        _UserSession.SaveChanges();
    //        dto.Id = obj.Id;
    //    }
    //}
    //#endregion


}
