using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class InternetDateTimeFormat : IPattern
    {
        private readonly IPattern pattern;

        public InternetDateTimeFormat()
        {
            var digit = new Range('0', '9');
            var colon = new Character(':');
            var minusSign = new Character('-');

            var dateFullyear = new Sequence(digit, digit, digit, digit);
            var dateMonth = new Sequence(digit, digit);
            var dateMday = new Sequence(digit, digit);

            var timeHour = new Sequence(digit, digit);
            var timeMinute = new Sequence(digit, digit);
            var timeSecond = new Sequence(digit, digit);
            var timeSecfrac = new Sequence(new Character('.'), digit, digit);
            var timeNumoffset = new Sequence(new Choice(new Character('+'), minusSign), timeHour, colon, timeMinute);
            var timeOffset = new Choice(new Character('Z'), timeNumoffset);

            var partialTime = new Sequence(timeHour, colon, timeMinute, colon, timeSecond, new Optional(timeSecfrac));
            var fullDate = new Sequence(dateFullyear, minusSign, dateMonth, minusSign, dateMday);
            var fullTime = new Sequence(partialTime, timeOffset);

            var dateTime = new Sequence(fullDate, new Character('T'), fullTime);
            pattern = dateTime;

        }
         
        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
