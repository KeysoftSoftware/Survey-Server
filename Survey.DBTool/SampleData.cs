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
            Test(us, msgs);
            AddQuestions(us, msgs);
            
            return msgs;
        }

        public static void Test(UserSession us, ReportedMsgs msgs)
        {
            var srv = us.GetService<SFillDtoService>();
            var dto = srv.GetSheelonToFill(1, 1);
        }

        public static void AddQuestions(UserSession us, ReportedMsgs msgs)
        {

            var ctx = DataManager.GetDBContext();

            var srvLov = us.GetService<LOVService>();


            var cat = srvLov.GetLovByCode(Constants.Lovs.QCAT, Constants.Qqat.SURVEYS);


            var startDate = new DateTime(2017,1,1);
            var endDate = new DateTime(2019,1,1);


            var optYes = GetOption(ctx, us, "YES", "כן", 1, msgs);
            var optNo = GetOption(ctx, us, "NO", "לא", 2, msgs);
            var opt1 = GetOption(ctx, us, "OPT1", "כדורגל", 1, msgs);
            var opt2 = GetOption(ctx, us, "OPT2", "כדורסל", 2, msgs);
            var opt3 = GetOption(ctx, us, "OPT3", "כדורעף", 3, msgs);

            // Question 1
            var q1 = GetQuestion(ctx, us, "Q1", "האם אתם אוהבים ספורט?", cat.Id, msgs);
            var q1Release = GetQuestionRelease(ctx, us, q1.name, new QReleaseDto() { Code = "Q1R", fromDate = startDate, maxOptCount = 1, minSelections = 1, questionId = q1.Id, toDate = endDate }, msgs);
            GetQReleaseOption(ctx, us, q1Release, optYes, 1, msgs);
            GetQReleaseOption(ctx, us, q1Release, optNo, 2, msgs);

            // Question 2
            var q2 = GetQuestion(ctx, us, "Q2", "שאלת בחירה: בחירה שניה", cat.Id, msgs);
            var q2Release = GetQuestionRelease(ctx, us, q2.name, new QReleaseDto() { Code = "Q2R", fromDate = startDate, maxOptCount = 3, minSelections = 1, questionId = q2.Id, toDate = endDate }, msgs);
            GetQReleaseOption(ctx, us, q2Release, opt1, 1, msgs);
            GetQReleaseOption(ctx, us, q2Release, opt2, 2, msgs);
            GetQReleaseOption(ctx, us, q2Release, opt3, 3, msgs);

 
            var srvSheelon = us.GetService<SheelonService>();
            var srvSheelonRelease = us.GetService<SReleaseService>();
            var srvSQRelease = us.GetService<SQReleaseService>();
            var srvSheelonQHiding = us.GetService<SQHidingService>();


            var code = "S1";
            var s1 = ctx.GetByCode<Sheelon>(code);
            if (s1 == null)
            {
                var sheelon = srvSheelon.CreateInternal();
                sheelon.Code = code;
                sheelon.name = "שאלון תחביבים";
                sheelon.loginManagerId = 1;
                sheelon.openning = "";
                sheelon.shared = true;
                sheelon.userId = 1;
                srvSheelon.SaveInternal(sheelon, msgs);
                us.FlushChanges();

                var sheelonRelease = srvSheelonRelease.CreateInternal();
                sheelonRelease.fromDate = new DateTime(2017, 1, 1);
                sheelonRelease.name = sheelon.name;
                sheelonRelease.releaseVersion = "1.0.0";
                sheelonRelease.sheelonId = sheelon.Id;
                srvSheelonRelease.SaveInternal(sheelonRelease, msgs);
                us.FlushChanges();

                var sq = srvSQRelease.CreateInternal();
                sq.isMandatory = true;
                sq.pageNo = 1;
                sq.qReleaseId = q1Release.Id;
                sq.sReleaseId = sheelonRelease.Id;
                sq.sortOrder = 1;
                sq.isMandatory = true;
                srvSQRelease.SaveInternal(sq, msgs);
                us.FlushChanges();

                sq = srvSQRelease.CreateInternal();
                sq.isMandatory = true;
                sq.pageNo = 1;
                sq.qReleaseId = q2Release.Id;
                sq.sReleaseId = sheelonRelease.Id;
                sq.sortOrder = 2;
                sq.isMandatory = false;
                srvSQRelease.SaveInternal(sq, msgs);
                us.FlushChanges();

                var sqh = srvSheelonQHiding.CreateInternal();
                sqh.hideFlag = true;
                sqh.sheelonId = sheelon.Id;
                sqh.sourceQuestionId = q1.Id;
                sqh.targetQuestionId = q2.Id;
                sqh.sourceQuestionAnswer = 2;
                srvSheelonQHiding.SaveInternal(sqh, msgs);
                us.SaveChanges();
            }

        }

        #region GetQReleaseOption
        private static QReleaseOption GetQReleaseOption(DataManager.DataContext ctx, UserSession us, QRelease qr, QOption option, int sortOrder, ReportedMsgs msgs)
        {
            var opt = ctx.GetAll<QReleaseOption>().Where(s => s.qReleaseId == qr.Id && s.qOptionId == option.Id).FirstOrDefault();
            if (opt == null)
            {
                var srv = us.GetService<QReleaseOptionService>();
                opt = srv.CreateInternal();
                opt.qOptionId = option.Id;
                opt.qReleaseId = qr.Id;
                opt.sortOrder = sortOrder;
                srv.SaveInternal(opt, msgs);
                us.SaveChanges();
                return opt;
            }

            return opt;
        }
        #endregion

        #region GetQuestionRelease
        private static QRelease GetQuestionRelease(DataManager.DataContext ctx, UserSession us, string text, QReleaseDto dto, ReportedMsgs msgs)
        {
            var obj = ctx.GetByCode<QRelease>(dto.Code);
            if (obj == null)
            {
                var srvQText = us.GetService<QTextService>();
                var dtoText = srvQText.CreateInternal();
                dtoText.text = text;
                srvQText.SaveInternal(dtoText, msgs);
                us.SaveChanges();

                var srv = us.GetService<QReleaseService>();
                obj = srv.CreateInternal();
                dto.To(obj);
                obj.qTextId = dtoText.Id;
                srv.SaveInternal(obj, msgs);
                us.SaveChanges();
                return obj;
            }

            return obj;
        }
        #endregion

        #region GetQuestion
        private static Question GetQuestion(DataManager.DataContext ctx, UserSession us,
    string code, string name, int categoryId, ReportedMsgs msgs)
        {
            var obj = ctx.GetByCode<Question>(code);
            if (obj == null)
            {
                var srv = us.GetService<QuestionService>();
                obj = srv.CreateInternal();
                obj.Code = code;
                obj.categoryId = categoryId;
                obj.name = name;
                srv.SaveInternal(obj, msgs);
                us.SaveChanges();
                return obj;
            }

            return obj;
        }
        #endregion

        #region GetOption
        private static QOption GetOption(DataManager.DataContext ctx, UserSession us,
          string code, string text, double value, ReportedMsgs msgs)
        {
            var obj = ctx.GetByCode<QOption>(code);
            if (obj == null)
            {
                var srvQText = us.GetService<QTextService>();
                var srvQOpt = us.GetService<QOptionService>();

                var dtoText = srvQText.CreateInternal();
                dtoText.text = text;
                srvQText.SaveInternal(dtoText, msgs);
                us.FlushChanges();

                obj = srvQOpt.CreateInternal();
                obj.Code = code;
                obj.value = value;
                obj.qTextId = dtoText.Id;
                srvQOpt.SaveInternal(obj, msgs);
                us.SaveChanges();

                return obj;
            }

            return obj;
        } 
        #endregion
    }
}
