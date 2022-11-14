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

            context.Surveys.AddRange(surveys);
            context.SaveChanges();


            if (context.Questions.Any())
            {
                return;   // DB has been seeded
            }


            var questions = new List<Question>();

            var question1_dogs = new Question { Text = "What is your favorite dog breed?" };

            var option1_q1 = new Option { Text = "Husky" };
            var option2_q1 = new Option { Text = "Golden Retriever" };
            var option3_q1 = new Option { Text = "Airdale Terrier" };

            question1_dogs.Options.Add(option1_q1);
            question1_dogs.Options.Add(option2_q1);
            question1_dogs.Options.Add(option3_q1);

            var question2_dogs = new Question { Text = "Do you have a dog?" };
            var option1_q2 = new Option { Text = "Yes" };
            var option2_q2 = new Option { Text = "No" };

            question2_dogs.Options.Add(option1_q2);
            question2_dogs.Options.Add(option2_q2);

            questions.Add(question1_dogs);
            questions.Add(question2_dogs);

            context.Questions.AddRange(questions);
            context.SaveChanges();
        }
    }
}
