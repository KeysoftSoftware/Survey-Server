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

            var optYes = GetOption(ctx, us, "YES", "כן", 1, msgs);
            var optNo = GetOption(ctx, us, "NO", "לא", 1, msgs);
            var optOpt1 = GetOption(ctx, us, "OPT1", "בחירה 1", 1, msgs);
            var optOpt2 = GetOption(ctx, us, "OPT2", "בחירה 2", 1, msgs);
            var optOpt3 = GetOption(ctx, us, "OPT3", "בחירה 3", 1, msgs);



            var code = "Q1";
            var q1 = ctx.GetByCode<Question>(code);
            if (q1 == null)
            {
                var q1Dto = srvQuest.CreateInternal();
                q1Dto.categoryId = cat.Id;
                q1Dto.Code = "Q1";
                q1Dto.maxAnswerCount = 1;
                q1Dto.name = "שאלת בחירה: בחירה אחת";
                //q1Dto.qTypeId

                srvQuest.SaveInternal(q1Dto, msgs);
                if (msgs.hasAnyError)
                {
                    // error
                    return;
                }

                var qtxt = srvQText.CreateInternal();
                qtxt.langCode = "he";
                qtxt.text = "האם אתם אוהבים תה?";
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




            }




        }

        private static QOption GetOption(DataManager.DataContext ctx, UserSession us,
            string code, string text , double value, ReportedMsgs msgs)
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
