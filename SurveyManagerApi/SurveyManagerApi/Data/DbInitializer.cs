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
            var survey_dogs = new Survey { Name = "Dogs Survey", Details = "Survey about your favorite dog breeds!" };
            var survey_cats = new Survey { Name = "Cats Survey", Details = "Survey about your favorite cat breeds!" };

            surveys.Add(survey_dogs);
            surveys.Add(survey_cats);


            context.Surveys.AddRange(surveys);
            context.SaveChanges();


            if (context.Questions.Any())
            {
                return;   // DB has been seeded
            }
            var questions = new List<Question>();

            questions.Add(new Question { SurveyId = 1, Text = "What is your favorite dog breed?" });
            questions.Add(new Question { SurveyId = 1, Text = "Do you have a dog?" });

            context.Questions.AddRange(questions);
            context.SaveChanges();

            if (context.Options.Any())
            {
                return; // DB has been seeded
            }

          
            var options = new List<Option>();


            options.Add(new Option { QuestionId = 1, Text = "Husky"});
            options.Add(new Option { QuestionId = 1, Text = "Golden Retriever" });
            options.Add( new Option { QuestionId = 1, Text = "Airdale Terrier" });

            options.Add(new Option { QuestionId = 2, Text = "Yes" });
            options.Add(new Option { QuestionId = 2, Text = "No" });

           
            context.Options.AddRange(options);
            context.SaveChanges();
            
        }
    }
}
