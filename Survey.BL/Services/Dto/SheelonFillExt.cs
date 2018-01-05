using KF.Primitives.NonPersistent;
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
    public partial class SFillDtoService
    {
        public TSFill GetSheelonToFill(int sheelonId, int respId, string langCode = "he")
        {
            var ctx = DataManager.GetDBContext();

            // find the relevent Sheelon release
            var sr = SheelonService.GetSheelonReleaseByDate(ctx, sheelonId, DateTime.Now.Date);
            if (sr == null)
            {
                // error

            };

            TSFill dto = new TSFill();
            dto.Id = 0;
            dto.name = sr.name;
            dto.openning = "";
            dto.sReleaseId = sr.Id;

            TPage page = new TPage();
            dto.pages.Add(page);

            page.pageNo = 1;
            page.name = "";

            // get all questions
            var questions = ctx.GetAll<View_SQRelease>().Where(s => s.sReleaseId == sr.Id).OrderBy(s=> s.sortOrder);

            foreach(var question in questions)
            {
                TQuestion questionDto = new TQuestion();
                questionDto.FromQuestion(question);

                var options = ctx.GetAll<View_QReleaseOption>().Where(s => s.qReleaseId == question.qReleaseId).OrderBy(s => s.sortOrder);
                foreach(var opt in options)
                {
                    TQOption tQOption = new TQOption();
                    tQOption.FromOption(opt);

                    questionDto.qOptions.Add(tQOption);
                }

                page.questions.Add(questionDto);
            }

            return dto;
        }
    } 
    #endregion

    public class TSFill : TBaseEntity
    {
        public TSFill()
        {
            pages = new List<TPage>();
        }
        public int sReleaseId { get; set; }

        public string openning { get; set; }
        public string name { get; set; }


        public List<TPage> pages { get; set; }
    }

    public class TPage
    {
        public TPage()
        {
            questions = new List<TQuestion>();
        }
        public int pageNo { get; set; }
        public string name { get; set; }

        public List<TQuestion> questions { get; set; }
    }

    public class TQuestion : TBaseEntity
    {
        public TQuestion()
        {
            texts = new QTextDto();
            qOptions = new List<TQOption>();
        }
        public int qReleaseId { get; set; }

          
        public bool isMandatory { get; set; }
        public int sortOrder { get; set; }

        public QTextDto texts { get; set; }

        public int maxOptCount { get; set; }
        public int minSelections { get; set; }
        public int qTypeId { get; set; }
        public List<TQOption> qOptions { get; set; }
        // answer
        public List<object> anserValue { get; set; }

        public void FromQuestion(View_SQRelease sqr)
        {
            qReleaseId = sqr.qReleaseId;
            isMandatory = sqr.isMandatory;
            sortOrder = sqr.sortOrder;
            texts = new QTextDto() { text = sqr.text, textLong = sqr.textLong };
            maxOptCount = sqr.maxOptCount;
            minSelections = sqr.minSelections;
            qTypeId = sqr.qTypeId;
        }
    }
    public class TQOption : TBaseEntity
    {
        public int sortOrder { get; set; }
        public double value { get; set; }
        public string text { get; set; }
        public string picture { get; set; }

        public void FromOption(View_QReleaseOption opt)
        {
            text = opt.text;
            picture = opt.picture;
            sortOrder = opt.sortOrder;
            value = opt.value;
        }

    }
}
