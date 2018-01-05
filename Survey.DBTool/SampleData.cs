using KF.Primitives;
using KF.Services;
using Survey.BL;
using Survey.BL.Common;
using Survey.BL.Services.Dto;
using Survey.BL.Services.Persistent;
using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DBTool
{
    class SampleData
    {
        public static ReportedMsgs CreateSampleData(UserSession us)
        {
            ReportedMsgs msgs = new ReportedMsgs();

            AddQuestions(us, msgs);

            return msgs;
        }

        public static void AddQuestions(UserSession us, ReportedMsgs msgs)
        {

            var ctx = DataManager.GetDBContext();

            var srvLov = us.GetService<LOVService>();


            var cat = srvLov.GetLovByCode(Constants.Lovs.QCAT, Constants.Qqat.SURVEYS);

            var srvQuest = us.GetService<QuestionDtoService>();
            var srvQuestRel = us.GetService<QReleaseDtoService>();
            var srvQText = us.GetService<QTextDtoService>();
            var srvQOpt = us.GetService<QOptionDtoService>();
            var srvQRO = us.GetService<QReleaseOptDtoService>();

            var srvQType = us.GetService<QTypeDtoService>();


            var optYes = GetOption(ctx, us, "YES", "כן", 1, msgs);
            var optNo = GetOption(ctx, us, "NO", "לא", 2, msgs);
            var optOpt1 = GetOption(ctx, us, "OPT1", "כדורגל", 1, msgs);
            var optOpt2 = GetOption(ctx, us, "OPT2", "כדורסל", 2, msgs);
            var optOpt3 = GetOption(ctx, us, "OPT3", "כדורעף", 3, msgs);



            var code = "Q1";
            var q1 = ctx.GetByCode<Question>(code);
            if (q1 == null)
            {
                var q1Dto = srvQuest.CreateInternal();
                q1Dto.categoryId = cat.Id;
                q1Dto.Code = "Q1";
                q1Dto.name = "האם אתם אוהבים ספורט?";
                q1Dto.qOptCount = 3;
                //q1Dto.qTypeId

                srvQuest.SaveInternal(q1Dto, msgs);
                if (msgs.hasAnyError)
                {
                    // error
                    return;
                }

                var qtxt = srvQText.CreateInternal();
                qtxt.langCode = "he";
                qtxt.text = "האם אתם אוהבים ספורט?";
                srvQText.SaveInternal(qtxt, msgs);
                if (msgs.hasAnyError)
                {
                    // error
                    return;
                }



                var q1r = srvQuestRel.CreateInternal();
                q1r.fromDate = new DateTime(2017, 1, 1);
                q1r.minSelections = 1;
                q1r.questionId = q1Dto.Id;
                q1r.qTextId = qtxt.Id;


                srvQuestRel.SaveInternal(q1r, msgs);
                if (msgs.hasAnyError)
                {
                    // error
                    return;
                }

                var qro = srvQRO.CreateInternal();
                qro.questionReleaseId = q1r.Id;
                qro.qOptionId = optYes.Id;
                qro.sortOrder = 1;
                srvQRO.SaveInternal(qro, msgs);


                qro = srvQRO.CreateInternal();
                qro.questionReleaseId = q1r.Id;
                qro.qOptionId = optNo.Id;
                qro.sortOrder = 2;
                srvQRO.SaveInternal(qro, msgs);

                q1 = ctx.GetByCode<Question>(code);
            }


            code = "Q2";
            var q2 = ctx.GetByCode<Question>(code);
            if (q2 == null)
            {
                var q2Dto = srvQuest.CreateInternal();
                q2Dto.categoryId = cat.Id;
                q2Dto.Code = code;
                q2Dto.name = "שאלת בחירה: בחירה שניה";
                q2Dto.qOptCount = 1;
                //q1Dto.qTypeId

                srvQuest.SaveInternal(q2Dto, msgs);
                if (msgs.hasAnyError)
                {
                    // error
                    return;
                }

                var qtxt = srvQText.CreateInternal();
                qtxt.langCode = "he";
                qtxt.text = "סמנו לפחות בחירה אחת";
                srvQText.SaveInternal(qtxt, msgs);
                if (msgs.hasAnyError)
                {
                    // error
                    return;
                }



                var q2r = srvQuestRel.CreateInternal();
                q2r.fromDate = new DateTime(2017, 1, 1);
                q2r.minSelections = 1;
                q2r.questionId = q2Dto.Id;
                q2r.qTextId = qtxt.Id;


                srvQuestRel.SaveInternal(q2r, msgs);
                if (msgs.hasAnyError)
                {
                    // error
                    return;
                }

                var qro = srvQRO.CreateInternal();
                qro.questionReleaseId = q2r.Id;
                qro.qOptionId = optOpt1.Id;
                qro.sortOrder = 1;
                srvQRO.SaveInternal(qro, msgs);


                qro = srvQRO.CreateInternal();
                qro.questionReleaseId = q2r.Id;
                qro.qOptionId = optOpt2.Id;
                qro.sortOrder = 2;
                srvQRO.SaveInternal(qro, msgs);

                qro = srvQRO.CreateInternal();
                qro.questionReleaseId = q2r.Id;
                qro.qOptionId = optOpt3.Id;
                qro.sortOrder = 3;
                srvQRO.SaveInternal(qro, msgs);

                q2 = ctx.GetByCode<Question>(code);
            }


            var srvSheelon = us.GetService<SheelonDtoService>();
            var srvSheelonRelease = us.GetService<SheelonReleaseDtoService>();
            var srvSheelonQuestion = us.GetService<SheelonQuestionDtoService>();
            var srvSheelonQHiding = us.GetService<SheelonQHidingDtoService>();


            code = "S1";
            var s1 = ctx.GetByCode<Sheelon>(code);
            if (s1 == null)
            {
                var dto = srvSheelon.CreateInternal();
                dto.Code = code;
                dto.name = "שאלון תחביבים";
                dto.loginManagerId = 1;
                dto.openning = "";
                dto.shared = true;
                dto.userId = 1;
                srvSheelon.SaveInternal(dto, msgs);
                

                var dtoRel = srvSheelonRelease.CreateInternal();
                dtoRel.fromDate = new DateTime(2017, 1, 1);
                dtoRel.name = dto.name;
                dtoRel.releaseVersion = "1.0.0";
                dtoRel.sheelonId = dto.Id;
                srvSheelonRelease.SaveInternal(dtoRel, msgs);

                var sq = srvSheelonQuestion.CreateInternal();
                sq.isMandatory = true;
                sq.pageNo = 1;
                sq.questionId = q1.Id;
                sq.sheelonId = dto.Id;
                sq.sortOrder = 1;
                srvSheelonQuestion.SaveInternal(sq, msgs);

                sq = srvSheelonQuestion.CreateInternal();
                sq.isMandatory = false;
                sq.pageNo = 1;
                sq.questionId = q2.Id;
                sq.sheelonId = dto.Id;
                sq.sortOrder = 2;
                srvSheelonQuestion.SaveInternal(sq, msgs);

                var sqh = srvSheelonQHiding.CreateInternal();
                sqh.hideFlag = true;
                sqh.sheelonId = dto.Id;
                sqh.sourceQuestionId = q1.Id;
                sqh.targetQuestionId = q2.Id;
                sqh.sourceQuestionAnswer = 2;
                srvSheelonQHiding.SaveInternal(sqh, msgs);

            }

        }

        private static QOption GetOption(DataManager.DataContext ctx, UserSession us,
            string code, string text, double value, ReportedMsgs msgs)
        {
            var obj = ctx.GetByCode<QOption>(code);
            if (obj == null)
            {
                var srvQText = us.GetService<QTextDtoService>();
                var srvQOpt = us.GetService<QOptionDtoService>();

                var dtoText = srvQText.CreateInternal();
                dtoText.text = text;
                srvQText.SaveInternal(dtoText, msgs);

                var dto = srvQOpt.CreateInternal();
                dto.Code = code;
                dto.value = value;
                dto.qTextId = dtoText.Id;
                srvQOpt.SaveInternal(dto, msgs);
                us.SaveChanges();

                obj = ctx.GetByCode<QOption>(code);
            }

            return obj;
        }
    }
}
