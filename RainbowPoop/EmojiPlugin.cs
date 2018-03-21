using System.Linq;
using System.Text.RegularExpressions;

namespace RainbowPoop
{
    public class EmojiPlugin
    {
        public static string InsertEmoji(string subject)
        {
            var regEx = new Regex(@":\w*\:");
            var emojiPlaceHolders = regEx.Matches(subject);
            var emojiTag = string.Empty;

            if(emojiPlaceHolders.Count > 0)
            {
                for (int i = 0; i < emojiPlaceHolders.Count; i++)
                {
                    emojiTag = emojiPlaceHolders[i].Value.ToString().Replace(":", string.Empty).ToLower();

                    var emoji = GetEmojiByTagName(emojiTag);

                    if (emoji == null)
                        subject = subject.Replace(emojiPlaceHolders[i].Value, "");
                    else
                        subject = subject.Replace(emojiPlaceHolders[i].Value, emoji.ToString());
                }
            }
            
            return subject;
        }

        public static object GetEmojiByTagName(string emojiTagName)
        {
            var emoji = typeof(Centvrio.Emoji.FacePositive).Assembly.GetTypes()
                .SelectMany(x => x.GetFields())
                .FirstOrDefault(x => x.Name.ToLower() == emojiTagName);

            if (emoji != null)
            {
                return emoji.GetValue(null);
            }
            return null;
        }
    }
}
