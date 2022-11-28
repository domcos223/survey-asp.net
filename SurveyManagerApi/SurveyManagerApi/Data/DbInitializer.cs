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
            var survey_dogs = new Survey { Id = "Survey1", Name = "Dogs Survey", Details = "Survey about your favorite dog breeds!", OptionType="1" };
            var survey_cats = new Survey { Id = "Survey2", Name = "Cats Survey", Details = "Survey about your favorite cat breeds!", OptionType= "2"};

            surveys.Add(survey_dogs);
            surveys.Add(survey_cats);


            context.Surveys.AddRange(surveys);
            context.SaveChanges();


            if (context.Questions.Any())
            {
                return;   // DB has been seeded
            }
            var questions = new List<Question>();

            questions.Add(new Question { Id="Question1", SurveyId = "Survey1", Text = "What is your favorite dog breed?" });
            questions.Add(new Question { Id = "Question2", SurveyId = "Survey1", Text = "Do you have a dog?" });

            context.Questions.AddRange(questions);
            context.SaveChanges();

            if (context.Options.Any())
            {
                return; // DB has been seeded
            }

          
            var options = new List<Option>();


            options.Add(new Option { Id="Question1_1", QuestionId = "Question1", Text = "Husky"});
            options.Add(new Option { Id = "Question1_2", QuestionId = "Question1", Text = "Golden Retriever" });
            options.Add( new Option { Id = "Question1_3", QuestionId = "Question1", Text = "Airdale Terrier" });

            options.Add(new Option { Id = "Question2_1", QuestionId = "Question2", Text = "Yes" });
            options.Add(new Option { Id = "Question2_2", QuestionId = "Question2", Text = "No" });

           
            context.Options.AddRange(options);
            context.SaveChanges();
            
        }
    }
}
