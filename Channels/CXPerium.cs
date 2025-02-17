using Microsoft.AspNetCore.Mvc;
using QSoft.CxPerium.Models;
using QSoft.CxPerium.Webhook;

namespace CxPerium.BotTemplate.Channels
{
    [Route("api/cxlive/webhook")]
    [Route("api/cxperium/webhook")]
    public class CXPerium : CxPeriumHook
    {
        /// <summary>
        /// Method triggered when a user answers a survey question.
        /// This method is invoked when the specified <paramref name="contact"/> responds to a survey question.
        /// The <paramref name="conversation"/> parameter contains the current conversation state.
        /// The <paramref name="survey"/> parameter provides information about the related survey.
        /// The <paramref name="answer"/> parameter represents the user's response to the survey question.
        /// It calls the base class's <see cref="OnSurveyQuestionAnswered"/> method to ensure the base functionality is executed.
        /// </summary>
        /// <param name="contact">The object containing information about the person or customer who answered the survey question.</param>
        /// <param name="conversation">The object representing the current conversation state.</param>
        /// <param name="survey">The object containing information about the related survey.</param>
        /// <param name="answer">The object containing the user's response to the survey question.</param>
        protected override void OnSurveyQuestionAnswered(Contact contact, ConversationState conversation, SurveyCx survey, SurveyQuestionReplyCx answer)
        {
            base.OnSurveyQuestionAnswered(contact, conversation, survey, answer);
        }

        /// <summary>
        /// Method triggered when a survey is completed by the user.
        /// This method is invoked when the survey associated with the specified <paramref name="contact"/> is completed.
        /// The <paramref name="conversation"/> parameter contains the current conversation state.
        /// The <paramref name="survey"/> parameter provides information about the completed survey.
        /// It calls the base class's <see cref="OnSurveyComplated"/> method to ensure the base functionality is executed.
        /// </summary>
        /// <param name="contact">The object containing information about the person or customer who completed the survey.</param>
        /// <param name="conversation">The object representing the current conversation state.</param>
        /// <param name="survey">The object containing information about the completed survey.</param>
        protected override void OnSurveyComplated(Contact contact, ConversationState conversation, SurveyCx survey)
        {
            base.OnSurveyComplated(contact, conversation, survey);
        }

        /// <summary>
        /// Method triggered when the user's chatbot session times out or is terminated.
        /// This method is invoked when the chatbot session associated with the specified <paramref name="contact"/> ends.
        /// The <paramref name="conversation"/> parameter contains the current conversation state.
        /// It calls the base class's <see cref="OnSessionTimeOut"/> method to ensure the base functionality is executed.
        /// </summary>
        /// <param name="contact">The object containing information about the person or customer whose chatbot session has ended.</param>
        /// <param name="conversation">The object representing the current conversation state.</param>
        protected override void OnSessionTimeOut(Contact contact, ConversationState conversation)
        {
            base.OnSessionTimeOut(contact, conversation);
        }

        /// <summary>
        /// Method triggered when a live chat session is closed or terminated.
        /// This method is invoked when the live chat session with the specified <paramref name="contact"/> is ended.
        /// It calls the base class's <see cref="OnClosingLiveChat"/> method to ensure the base functionality is executed.
        /// </summary>
        /// <param name="contact">The object containing information about the person or customer whose live chat session is being closed.</param>
        protected override void OnClosingLiveChat(Contact contact)
        {
            base.OnClosingLiveChat(contact);
        }
    }
}
