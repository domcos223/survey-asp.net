using SurveyManagerApi.Models;

namespace SurveyManagerApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SurveyManagerContext context)
        {
            if (context.Surveys.Any())
            {
                return; //DB has been seeded
            }

            var surveys = new List<Survey>();
            var survey_dogs = new Survey { Id = "Survey1", Name = "Dogs Survey", Details = "Survey about dogs!", OptionType = "1" };
            var survey_cats = new Survey { Id = "Survey2", Name = "Cats Survey", Details = "Survey about cats!", OptionType = "2" };

            surveys.Add(survey_dogs);
            surveys.Add(survey_cats);


            context.Surveys.AddRange(surveys);
            context.SaveChanges();


            if (context.Questions.Any())
            {
                return;   // DB has been seeded
            }
            var questions = new List<Question>
            {
                new Question { Id = "Question1", OrderId = 1, SurveyId = "Survey1", Text = "Test Question 1", MostAnsweredOp = "" },
                new Question { Id = "Question2", OrderId = 2, SurveyId = "Survey1", Text = "Test Question 2", MostAnsweredOp = "" },
                new Question { Id = "Question3", OrderId = 1, SurveyId = "Survey2", Text = "Test Question 3", MostAnsweredOp = "" },
                new Question { Id = "Question4", OrderId = 2, SurveyId = "Survey2", Text = "Test Question 4", MostAnsweredOp = "" }
            };

            context.Questions.AddRange(questions);
            context.SaveChanges();

            if (context.Options.Any())
            {
                return; // DB has been seeded
            }


            var options = new List<Option>
            {
                new Option { Id = "Question1_1", OrderId = 1, QuestionId = "Question1", Text = "Test Option 1" },
                new Option { Id = "Question1_2", OrderId = 2, QuestionId = "Question1", Text = "Test Option 2" },
                new Option { Id = "Question1_3", OrderId = 3, QuestionId = "Question1", Text = "Test Option 3" },

                new Option { Id = "Question2_1", OrderId = 1, QuestionId = "Question2", Text = "Test Option 1" },
                new Option { Id = "Question2_2", OrderId = 2, QuestionId = "Question2", Text = "Test Option 2" },

                new Option { Id = "Question3_1", OrderId = 1, QuestionId = "Question3", Text = "Test Option 1" },
                new Option { Id = "Question3_2", OrderId = 2, QuestionId = "Question3", Text = "Test Option 2" },
                new Option { Id = "Question3_3", OrderId = 3, QuestionId = "Question3", Text = "Test Option 3" },

                new Option { Id = "Question4_1", OrderId = 1, QuestionId = "Question4", Text = "Test Option 1" },
                new Option { Id = "Question4_2", OrderId = 2, QuestionId = "Question4", Text = "Test Option 2" },
                new Option { Id = "Question4_3", OrderId = 3, QuestionId = "Question4", Text = "Test Option 3" },
            };


            context.Options.AddRange(options);
            context.SaveChanges();

        }
    }
}
