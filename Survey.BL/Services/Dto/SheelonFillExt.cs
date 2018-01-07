using KF.Primitives.NonPersistent;
using KF.Services;
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
        public void GetSheelonToFillCall(APICall call)
        {
            var sheelonId = call.GetParameters<int>("sheelonId");
            var respId = call.GetParameters<int>("respId");

            var res = GetSheelonToFill(1, 1);
            call.callResult.Add("data", res);
            call.isSuccess = true;
        }

        public TSFill GetSheelonToFill(int sheelonId, int respId, string langCode = "he")
        {
            var ctx = DataManager.GetDBContext();

            // find the relevent Sheelon release
            var sr = SheelonService.GetSheelonReleaseByDate(ctx, sheelonId, DateTime.Now.Date);
            if (sr == null)
            {
                // error

            };

            var hidings = ctx.GetAll<SQHiding>().Where(s => s.sheelonId == sr.sheelonId);

            TSFill dto = new TSFill();
            dto.Id = 0;
            dto.name = sr.name;
            dto.openning = string.Format("{0} <strong>{1}</strong> {2}", "זהו שאלון אשר מלמד על", "התחביבים", "שלכם");
            dto.sReleaseId = sr.Id;

            TPage page = new TPage();
            dto.pages.Add(page);

            page.pageNo = 1;
            page.name = "עמוד 1";

            // get all questions
            var questions = ctx.GetAll<View_SQRelease>().Where(s => s.sReleaseId == sr.Id).OrderBy(s => s.sortOrder);

            foreach (var question in questions)
            {
                TQuestion questionDto = new TQuestion();
                questionDto.FromQuestion(question);
                questionDto.visible = true;

                var options = ctx.GetAll<View_QReleaseOption>().Where(s => s.qReleaseId == question.Id).OrderBy(s => s.sortOrder);
                foreach (var opt in options)
                {
                    TQOption tQOption = new TQOption();
                    tQOption.FromOption(opt);

                    questionDto.qOptions.Add(tQOption);
                }

                // hidings
                var qHidings = hidings.Where(s => s.sourceQuestionId == question.Id);
                foreach(var hide in qHidings)
                {
                    TQuestionHiding tHiding = new TQuestionHiding();
                    tHiding.answer = hide.sourceQuestionAnswer;
                    tHiding.targetQuestionId = hide.targetQuestionId;
                    questionDto.hidings.Add(tHiding);
                }

                page.questions.Add(questionDto);
            }

            return dto;
        }
    }
    #endregion

    #region TSFill
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
    #endregion

    #region TPage
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
    #endregion

    public class TQuestion : TBaseEntity
    {
        public TQuestion()
        {
            texts = new QTextDto();
            qOptions = new List<TQOption>();
            hidings = new List<TQuestionHiding>();
        }
        public int questionId { get; set; }
        public bool visible { get; set; }

        public bool isMandatory { get; set; }
        public int sortOrder { get; set; }

        public QTextDto texts { get; set; }

        public int maxOptCount { get; set; }
        public int minSelections { get; set; }
        public int qTypeId { get; set; }
        public List<TQOption> qOptions { get; set; }
        // answer
        public List<object> anserValue { get; set; }

        public List<TQuestionHiding> hidings { get; set; }

        public void FromQuestion(View_SQRelease sqr)
        {
            Id = sqr.Id;
            questionId = sqr.questionId;
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

    public class TQuestionHiding
    {
        public double answer { get; set; }
        public int targetQuestionId { get; set; }
    }
}
